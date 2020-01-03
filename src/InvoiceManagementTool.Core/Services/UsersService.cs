using InvoiceManagementTool.Core.Interfaces;
using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using InvoiceManagementTool.Core.Model.Enums;
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
            _sqlDatabaseConnector.SetUpConnectionString("constr");
            return Roles.Admin;
        }

        public void InitializeConnection()
        {
            _sqlDatabaseConnector.SetUpConnectionString("constr");
        }

        public List<User> GetAllUsers()
        {
            return null;
        }

        public User GetUserByLogin(string userLogin)
        {
            return null;
        }

        public void AddUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(User user, string lastUserLogin)
        {
            throw new System.NotImplementedException();
        }
    }
}