using InvoiceManagementTool.Infrastructure;
using InvoiceManagementTool.WindowManagers.Login;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Controls;

namespace InvoiceManagementTool.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly ILoginWindowManager _loginWindowManager;
        public LoginWindow(ILoginWindowManager loginWindowManager)
        {
            InitializeComponent();

            _loginWindowManager = loginWindowManager;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            new SqlDatabaseConnector().SendSelectCommand(new MySqlCommand(), 2);
            if(_loginWindowManager.ExecuteLoginAction(LoginTextBox.Text, PasswordBox.Password))
            {
                Close();
            }
        }
    }
}
