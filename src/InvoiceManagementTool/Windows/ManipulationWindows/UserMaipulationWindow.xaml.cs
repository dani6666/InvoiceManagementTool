using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using InvoiceManagementTool.Core.Model.Enums;
using System;
using System.Linq;
using System.Windows;

namespace InvoiceManagementTool.Windows.ManipulationWindows
{
    /// <summary>
    /// Interaction logic for UserMaipulationWindow.xaml
    /// </summary>
    public partial class UserMaipulationWindow : Window, IParametaisedWindow<User>
    {
        private readonly IEditUsersService _editUsersService;
        private string _originalLogin = string.Empty;
        public UserMaipulationWindow(IEditUsersService editUsersService)
        {
            InitializeComponent();

            RoleComboBox.ItemsSource = Enum.GetValues(typeof(Roles));

            _editUsersService = editUsersService;
        }

        public void SetParameter(User parameter)
        {
            Title = "Update user";
            ApplyButton.Content = "Update user";

            _originalLogin = parameter.Login;

            LoginTextBox.Text = parameter.Login;
            PasswordBox.Password = parameter.Password;
            RoleComboBox.SelectedItem = parameter.Role;
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password.Length < 5 ||
                !PasswordBox.Password.Any(char.IsUpper) ||
                !PasswordBox.Password.Any(char.IsDigit))
            {
                MessageBox.Show("Password needs to:" + Environment.NewLine +
                                "Have at least 5 characters" + Environment.NewLine +
                                "Have at least one digit" + Environment.NewLine +
                                "Have at least one upper case letter");
                return;
            }

            var user = new User
            {
                Login = LoginTextBox.Text,
                Password = PasswordBox.Password,
                Role = (Roles)RoleComboBox.SelectedItem
            };

            try
            {
                if (_originalLogin != string.Empty)
                {
                    _editUsersService.UpdateUser(user, _originalLogin);
                }
                else
                {
                    _editUsersService.AddUser(user);
                }
            }
            catch
            {
                MessageBox.Show("Invalid data input");
                return;
            }

            MessageBox.Show("Operation completed");

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
