using InvoiceManagementTool.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagementTool.Core.Interfaces.Services
{
    public interface ILoginUserService
    {
        Roles? ValidateUser(string login, string password);
    }
}
