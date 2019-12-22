using InvoiceManagementTool.Core.Model;
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
        }

        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.ShowDialogWithParam<ClientManipulationWindow, Client>(null);
        }

        private void InvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            _windowNavigator.ShowDialogWithParam<InvoiceManipulationWindow, Invoice>(null);
        }
    }
}
