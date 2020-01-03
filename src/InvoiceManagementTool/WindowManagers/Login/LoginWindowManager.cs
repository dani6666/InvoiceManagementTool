using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model.Enums;
using InvoiceManagementTool.Windows;
using System.Windows;

namespace InvoiceManagementTool.WindowManagers.Login
{
    public class LoginWindowManager : ILoginWindowManager
    {
        private readonly ILoginUserService _loginUserService;
        private readonly IWindowNavigator _windowNavigator;
        public LoginWindowManager(ILoginUserService loginUserService, IWindowNavigator windowNavigator)
        {
            _loginUserService = loginUserService;
            _windowNavigator = windowNavigator;

            _loginUserService.InitializeConnection();
        }

        public bool ExecuteLoginAction(string login, string password)
        {
            if (login.Length > 0 && password.Length > 0)
            {
                var userRole = _loginUserService.ValidateUser(login, password);

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
