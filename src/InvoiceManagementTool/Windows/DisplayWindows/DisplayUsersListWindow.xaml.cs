using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using InvoiceManagementTool.Core.Model.Enums;
using InvoiceManagementTool.Windows.ManipulationWindows;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InvoiceManagementTool.Windows.DisplayWindows
{
    /// <summary>
    /// Interaction logic for DisplayUsersListWindow.xaml
    /// </summary>
    public partial class DisplayUsersListWindow : Window
    {
        private readonly IEditUsersService _editUsersService;
        private readonly IWindowNavigator _windowNavigator;

        public DisplayUsersListWindow(IEditUsersService editUsersService, IWindowNavigator windowNavigator)
        {
            InitializeComponent();

            _editUsersService = editUsersService;
            _windowNavigator = windowNavigator;

            foreach (var user in _editUsersService.GetAllUsers())
            {
                var panel = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };

                panel.Children.Add(new TextBlock()
                {
                    Text = user.Login,
                    Width = 90
                });
                panel.Children.Add(new TextBlock()
                {
                    Text = Enum.GetName(typeof(Roles), user.Role),
                    Margin = new Thickness(10,0,0,0)
                });
                panel.MouseLeftButtonDown += Row_Click;

                UsersStackPanel.Children.Add(panel);
            }
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            var userLogin = ((TextBlock)((StackPanel)sender).Children[0]).Text;

            var user = _editUsersService.GetUserByLogin(userLogin);

            if (user != null)
            {
                _windowNavigator.ShowDialogWithParam<UserMaipulationWindow, User>(user);
            }
        }
    }
}
