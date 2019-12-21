using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagementTool.WindowManagers.Login
{
    public interface ILoginWindowManager
    {
        bool ExecuteLoginAction(string login, string password);
    }
}
