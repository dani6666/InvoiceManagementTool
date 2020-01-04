using InvoiceManagementTool.Core.Model;
using System.Collections.Generic;

namespace InvoiceManagementTool.Core.Interfaces.Services
{
    public interface IEditUsersService
    {
        List<User> GetAllUsers();
        User GetUserByLogin(string userLogin);
        void AddUser(User user);
        void UpdateUser(User user, string lastUserLogin);
    }
}
