using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model.Enums;
using InvoiceManagementTool.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace InvoiceManagementTool.WindowManagers.Login
{
    public class LoginWindowManager : ILoginWindowManager
    {
        private readonly ILoginUserService _loginAccountService;
        private readonly IWindowNavigator _windowNavigator;
        public LoginWindowManager(ILoginUserService loginAccountService, IWindowNavigator windowNavigator)
        {
            _loginAccountService = loginAccountService;
            _windowNavigator = windowNavigator;
        }

        public bool ExecuteLoginAction(string login, string password)
        {
            if (login.Length > 0 && password.Length > 0)
            {
                var userRole = _loginAccountService.ValidateUser(login, password);

                switch (userRole)
                {
                    case null:
                        MessageBox.Show("Incorrect login attempt");
                        return false;
                    case Roles.Admin:
                        _windowNavigator.Show<AdminAccessWindow>();
                        return true;
                    case Roles.Manager:
                        _windowNavigator.Show<ManagerAccessWindow>();
                        return true;
                    case Roles.Accountant:
                        _windowNavigator.Show<AccountantAccessWindow>();
                        return true;
                    case Roles.Cashier:
                        _windowNavigator.Show<CashierAccessWindow>();
                        return true;
                    default:
                        return false;
                }
            }

            MessageBox.Show("Please input both login and password");
            return false;
        }
    }
}
