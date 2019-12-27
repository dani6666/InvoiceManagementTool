using InvoiceManagementTool.Core.Model;
using System.Collections.Generic;

namespace InvoiceManagementTool.WindowManagers.DisplayUsersList
{
    public interface IDisplayUsersListWindowManager
    {
        List<User> GetAllUsers();

        void OpenEditUserWindow(string userLogin);
    }
}
