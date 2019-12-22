using InvoiceManagementTool.Core.Model;
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
using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model.Enums;
using InvoiceManagementTool.WindowManagers.DisplayProductsList;

namespace InvoiceManagementTool.Windows.DisplayWindows
{
    /// <summary>
    /// Interaction logic for DisplayProductsListWindow.xaml
    /// </summary>
    public partial class DisplayProductsListWindow : Window
    {
        private readonly IDisplayProductsListWindowManager _displayProductsListWindowManager;
        public DisplayProductsListWindow(IDisplayProductsListWindowManager displayProductsListWindowManager)
        {
            InitializeComponent();

            _displayProductsListWindowManager = displayProductsListWindowManager;

            foreach (var product in _displayProductsListWindowManager.GetAllProducts())
            {
                var panel = new StackPanel();
                panel.Children.Add(new TextBlock()
                {
                    Text = product.Name
                });
                panel.Children.Add(new TextBlock()
                {
                    Text = product.StorageAmount.ToString()
                });
                panel.MouseLeftButtonDown += Row_Click;
                panel.Name = product.Id.ToString();

                ProductsStackPanel.Children.Add(panel);
            }
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            var productId = int.Parse(((StackPanel)sender).Name);

            _displayProductsListWindowManager.OpenEditProductWindow(productId);
        }
    }
}
