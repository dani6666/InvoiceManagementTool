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
            var sqlCommand = new MySqlCommand("CALL getRolePass(@Login, @Pass)");

            sqlCommand.Parameters.AddWithValue("@Login", login);
            sqlCommand.Parameters.AddWithValue("@Pass", password);

            var usersStrings = _sqlDatabaseConnector.SendSelectCommand(sqlCommand, 1);

            if (usersStrings.Count == 0)
            {
                return null;
            }

            var role = Enum.Parse<Roles>(usersStrings[0][0]);

            switch (role)
            {
                case Roles.Admin:
                    _sqlDatabaseConnector.SetUpConnectionString("server=localhost;database=InvoiceManagement" +
                                                                ";uid=IMAdmin;pwd=ceda392467dc055ce0cc55cd5a23e062;");
                    break;

                case Roles.Manager:
                    _sqlDatabaseConnector.SetUpConnectionString("server=localhost;database=InvoiceManagement;" +
                                                                "uid=IMManager;pwd=23f525e04f07113367e233d4d6416b69;");
                    break;

                case Roles.Accountant:
                    _sqlDatabaseConnector.SetUpConnectionString("server=localhost;database=InvoiceManagement;" +
                                                                "uid=IMAccountant;pwd=70905350353b3e6adb4b6a74bdc3f61a;");
                    break;

                case Roles.Cashier:
                    _sqlDatabaseConnector.SetUpConnectionString("server=localhost;database=InvoiceManagement;" +
                                                                "uid=IMCashier;pwd=49778fc3d37abe24eedf7a29882370cd;");
                    break;
            }
            return role;
        }

        public void InitializeConnection()
        {
            _sqlDatabaseConnector.SetUpConnectionString("server=localhost;database=InvoiceManagement;" +
                                                        "uid=IMAccountFetcher;pwd=7d91a80810c0f91caa1a465a80b16ca2;");
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
                                              " WHERE userLogin = @Login");

            sqlCommand.Parameters.AddWithValue("@Login", userLogin);

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
            var sqlCommand = new MySqlCommand("INSERT INTO Credentials (userLogin, userPassword, roleId) VALUES " +
                                              " (@Login, @Pass, " +
                                              "(" +
                                              " SELECT id FROM Roles" +
                                              $" WHERE role = \"{user.Role}\"" +
                                              " LIMIT 1" +
                                              " ))");

            sqlCommand.Parameters.AddWithValue("@Login", user.Login);
            sqlCommand.Parameters.AddWithValue("@Pass", user.Password);

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
        }

        public void UpdateUser(User user, string lastUserLogin)
        {
            var sqlCommand = new MySqlCommand("UPDATE Credentials SET" +
                                              " userLogin=@Login," +
                                              " userPassword=@Pass," +
                                              " roleId= " +
                                              "(" +
                                              " SELECT id FROM Roles" +
                                              $" WHERE role = \"{user.Role}\"" +
                                              " LIMIT 1" +
                                              " )" +
                                              $" WHERE userLogin = @LastLogin");

            sqlCommand.Parameters.AddWithValue("@Login", user.Login);
            sqlCommand.Parameters.AddWithValue("@LastLogin", lastUserLogin);
            sqlCommand.Parameters.AddWithValue("@Pass", user.Password);

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
        }
    }
}