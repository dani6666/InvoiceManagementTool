using InvoiceManagementTool.WindowManagers.Login;
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
            try
            {
                if (_loginWindowManager.ExecuteLoginAction(LoginTextBox.Text, PasswordBox.Password))
                {
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Invalid data input");
            }
        }
    }
}
