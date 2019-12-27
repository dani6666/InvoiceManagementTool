using InvoiceManagementTool.Windows.DisplayWindows;
using System.Windows;

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
