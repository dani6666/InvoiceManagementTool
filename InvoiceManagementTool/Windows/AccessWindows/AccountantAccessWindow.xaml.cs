using InvoiceManagementTool.Windows.DisplayWindows;
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
    /// Interaction logic for AccountantAccessWindow.xaml
    /// </summary>
    public partial class AccountantAccessWindow : Window
    {
        private readonly IWindowNavigator _windowNavigator;

        public AccountantAccessWindow(IWindowNavigator windowNavigator)
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
    }
}
