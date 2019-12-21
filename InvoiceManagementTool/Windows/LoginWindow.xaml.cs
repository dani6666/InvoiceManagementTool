using InvoiceManagementTool.WindowManagers.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            if(_loginWindowManager.ExecuteLoginAction(LoginTextBox.Text, PasswordBox.Password))
            {
                Close();
            }
        }
    }
}
