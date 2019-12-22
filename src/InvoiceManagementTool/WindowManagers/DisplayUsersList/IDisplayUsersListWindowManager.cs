using System;
using System.Collections.Generic;
using System.Text;
using InvoiceManagementTool.Core.Model;

namespace InvoiceManagementTool.WindowManagers.DisplayUsersList
{
    public interface IDisplayUsersListWindowManager
    {
        List<User> GetAllUsers();

        void OpenEditUserWindow(string userLogin);
    }
}
