using InvoiceManagementTool.Windows.DisplayWindows;
using InvoiceManagementTool.Windows.ManipulationWindows;
using System.Windows;

namespace InvoiceManagementTool.Windows
{
    /// <summary>
    /// Interaction logic for ManagerAccessWindow.xaml
    /// </summary>
    public partial class ManagerAccessWindow : Window
    {
        private readonly IWindowNavigator _windowNavigator;
        public ManagerAccessWindow(IWindowNavigator windowNavigator)
        {
            InitializeComponent();

            _windowNavigator = windowNavigator;
        }

        private void ShowProductsButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.ShowDialog<DisplayProductsListWindow>();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.ShowDialog<ProductManipulationWindow>();
        }
    }
}
