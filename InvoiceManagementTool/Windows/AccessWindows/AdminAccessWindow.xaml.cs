using InvoiceManagementTool.Core.Model;
using InvoiceManagementTool.Windows.DisplayWindows;
using InvoiceManagementTool.Windows.ManipulationWindows;
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
    /// Interaction logic for AdminAccessWindow.xaml
    /// </summary>
    public partial class AdminAccessWindow : Window
    {
        private readonly IWindowNavigator _windowNavigator;
        public AdminAccessWindow(IWindowNavigator windowNavigator)
        {
            InitializeComponent();

            _windowNavigator = windowNavigator;
        }

        private void ShowInvoicesButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.Show<DisplayInvoicesListWindow>();
        }

        private void ShowClietsButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.Show<DisplayClientsListWindow>();
        }

        private void ShowProductsButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.Show<DisplayProductsListWindow>();
        }

        private void AddInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.ShowDialogWithParam<InvoiceManipulationWindow, Invoice>(null);
        }

        private void AddClietButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.ShowDialogWithParam<InvoiceManipulationWindow, Invoice>(null);
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.ShowDialogWithParam<ProductManipulationWindow, Product>(null);
        }

        private void ShowUsersButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.Show<DisplayUsersListWindow>();
        }

        private void BackupDatabaseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.ShowDialogWithParam<UserMaipulationWindow, User>(null);
        }

        private void RestoreDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
