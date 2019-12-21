using InvoiceManagementTool.Core.Model;
using InvoiceManagementTool.WindowManagers.CashierAccess;
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
