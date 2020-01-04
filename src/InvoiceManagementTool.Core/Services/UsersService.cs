using InvoiceManagementTool.Core.Interfaces;
using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using InvoiceManagementTool.Core.Model.Enums;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace InvoiceManagementTool.Core.Services
{
    public class UsersService : ILoginUserService, IEditUsersService
    {
        private readonly ISqlDatabaseConnector _sqlDatabaseConnector;

        public UsersService(ISqlDatabaseConnector sqlDatabaseConnector)
        {
            _sqlDatabaseConnector = sqlDatabaseConnector;
        }

        public Roles? ValidateUser(string login, string password)
        {
            return Roles.Admin;
        }

        public void InitializeConnection()
        {
            _sqlDatabaseConnector.SetUpConnectionString("server=localhost;database=InvoiceManagement;uid=root;pwd=Fredek;");
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            var sqlCommand = new MySqlCommand("SELECT userLogin, role FROM Credentials " +
                                                       "INNER JOIN Roles ON Credentials.roleId = Roles.id");

            var usersStrings = _sqlDatabaseConnector.SendSelectCommand(sqlCommand, 2);

            foreach (var usersString in usersStrings)
            {
                var user = new User
                {
                    Login = usersString[0],
                    Role = Enum.Parse<Roles>(usersString[1])
                };

                users.Add(user);
            }

            return users;
        }

        public User GetUserByLogin(string userLogin)
        {
            return null;
        }

        public void AddUser(User user)
        {
            MySqlCommand sqlCommand = new MySqlCommand("INSERT INTO Credentials (userLogin, userPassword, roleId) VALUES " +
                                                       $" (\"{user.Login}\", \"{user.Password}\", " +
                                                       "(" +
                                                       " SELECT id FROM Roles" +
                                                       " WHERE role = \"" + user.Role +"\"" +
                                                       " LIMIT 1"+
                                                       " ))");

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
        }

        public void UpdateUser(User user, string lastUserLogin)
        {
            throw new System.NotImplementedException();
        }
    }
}