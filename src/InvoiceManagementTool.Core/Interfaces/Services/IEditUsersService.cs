using System;
using System.Collections.Generic;
using System.Text;
using InvoiceManagementTool.Core.Model;

namespace InvoiceManagementTool.Core.Interfaces.Services
{
    public interface IEditUsersService
    {
        List<User> GetAllUsers();

        User GetUserByLogin(string userLogin);
    }
}
