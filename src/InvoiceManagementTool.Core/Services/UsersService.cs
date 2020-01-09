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
            var sqlCommand = new MySqlCommand($"CALL getRolePass({login}, {password})");

            var usersStrings = _sqlDatabaseConnector.SendSelectCommand(sqlCommand, 1);

            if (usersStrings.Count == 0)
            {
                return null;
            }

            Roles role = Enum.Parse<Roles>(usersStrings[0][0]);
            switch (role)
            {
                case Roles.Admin:
                    _sqlDatabaseConnector.SetUpConnectionString("server=localhost;database=InvoiceManagement;uid=root;pwd=Fredek;");
                    break;
                case Roles.Manager:
                    _sqlDatabaseConnector.SetUpConnectionString("server=localhost;database=InvoiceManagement;uid=root;pwd=Fredek;");
                    break;
                case Roles.Accountant:
                    _sqlDatabaseConnector.SetUpConnectionString("server=localhost;database=InvoiceManagement;uid=root;pwd=Fredek;");
                    break;
                case Roles.Cashier:
                    _sqlDatabaseConnector.SetUpConnectionString("server=localhost;database=InvoiceManagement;uid=root;pwd=Fredek;");
                    break;
            }
            return role;
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
            var sqlCommand = new MySqlCommand("SELECT userLogin, userPassword, role FROM Credentials" +
                                              " INNER JOIN Roles ON Credentials.roleId = Roles.id" +
                                              $" WHERE userLogin = \"{userLogin}\"");

            var usersString = _sqlDatabaseConnector.SendSelectCommand(sqlCommand, 3)[0];

            var user = new User
            {
                Login = usersString[0],
                Password = usersString[1],
                Role = Enum.Parse<Roles>(usersString[2])
            };

            return user;
        }

        public void AddUser(User user)
        {
            MySqlCommand sqlCommand = new MySqlCommand("INSERT INTO Credentials (userLogin, userPassword, roleId) VALUES " +
                                                       $" (\"{user.Login}\", \"{user.Password}\", " +
                                                       "(" +
                                                       " SELECT id FROM Roles" +
                                                       $" WHERE role = \"{user.Role}\"" +
                                                       " LIMIT 1" +
                                                       " ))");

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
        }

        public void UpdateUser(User user, string lastUserLogin)
        {
            MySqlCommand sqlCommand = new MySqlCommand("UPDATE Credentials SET" +
                                                       $" userLogin=\"{user.Login}\"," +
                                                       $" userPassword=\"{user.Password}\"," +
                                                       " roleId= " +
                                                       "(" +
                                                       " SELECT id FROM Roles" +
                                                       $" WHERE role = \"{user.Role}\"" +
                                                       " LIMIT 1" +
                                                       " )" +
                                                       $" WHERE userLogin = \"{lastUserLogin}\"");

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
        }
    }
}