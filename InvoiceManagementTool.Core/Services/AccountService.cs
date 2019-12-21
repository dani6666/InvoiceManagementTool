using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagementTool.Core.Services
{
    public class AccountService : ILoginAccountService
    {

        public Roles? ValidateUser(string login, string password)
        {
            return Roles.Admin;
        }
    }
}
