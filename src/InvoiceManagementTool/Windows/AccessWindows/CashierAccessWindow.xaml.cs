using System.Windows;

namespace InvoiceManagementTool.Windows
{
    /// <summary>
    /// Interaction logic for CashierAccessWindow.xaml
    /// </summary>
    public partial class CashierAccessWindow : Window
    {
        private readonly IWindowNavigator _windowNavigator;
        public CashierAccessWindow(IWindowNavigator windowNavigator)
        {
            InitializeComponent();

            _windowNavigator = windowNavigator;
        }

        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.ShowDialog<ClientManipulationWindow>();
        }

        private void InvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.ShowDialog<InvoiceManipulationWindow>();
        }
    }
}
