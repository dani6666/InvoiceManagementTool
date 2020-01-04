using InvoiceManagementTool.Windows.DisplayWindows;
using InvoiceManagementTool.Windows.ManipulationWindows;
using System.Windows;

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
            _windowNavigator.ShowDialog<InvoiceManipulationWindow>();
        }

        private void AddClietButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.ShowDialog<InvoiceManipulationWindow>();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.ShowDialog<ProductManipulationWindow>();
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
            _windowNavigator.ShowDialog<UserMaipulationWindow>();
        }

        private void RestoreDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
