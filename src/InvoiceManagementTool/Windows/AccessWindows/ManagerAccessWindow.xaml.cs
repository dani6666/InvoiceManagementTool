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
            _windowNavigator.ShowDialogWithParam<ProductManipulationWindow, Product>(null);
        }
    }
}
