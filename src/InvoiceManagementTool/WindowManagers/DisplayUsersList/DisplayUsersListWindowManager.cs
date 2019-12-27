using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using InvoiceManagementTool.Windows.ManipulationWindows;
using System.Collections.Generic;

namespace InvoiceManagementTool.WindowManagers.DisplayUsersList
{
    public class DisplayUsersListWindowManager : IDisplayUsersListWindowManager
    {
        private readonly IEditUsersService _editUsersService;
        private readonly IWindowNavigator _windowNavigator;

        public DisplayUsersListWindowManager(IEditUsersService editUsersService, IWindowNavigator windowNavigator)
        {
            _editUsersService = editUsersService;
            _windowNavigator = windowNavigator;
        }

        public List<User> GetAllUsers()
        {
            return _editUsersService.GetAllUsers();
        }

        public void OpenEditUserWindow(string userLogin)
        {
            var user = _editUsersService.GetUserByLogin(userLogin);

            if (user != null)
            {
                _windowNavigator.ShowDialogWithParam<UserMaipulationWindow, User>(user);
            }
        }
    }
}
