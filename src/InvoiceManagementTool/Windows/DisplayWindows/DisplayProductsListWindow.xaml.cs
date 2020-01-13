using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using InvoiceManagementTool.Windows.ManipulationWindows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InvoiceManagementTool.Windows.DisplayWindows
{
    /// <summary>
    /// Interaction logic for DisplayProductsListWindow.xaml
    /// </summary>
    public partial class DisplayProductsListWindow : Window
    {
        private readonly IProductsService _productsService;
        private readonly IWindowNavigator _windowNavigator;
        public DisplayProductsListWindow(IProductsService productsService, IWindowNavigator windowNavigator)
        {
            InitializeComponent();

            _productsService = productsService;
            _windowNavigator = windowNavigator;

            foreach (var product in _productsService.GetAllProducts())
            {
                var panel = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };
                panel.Children.Add(new TextBlock()
                {
                    Text = product.Name,
                    Width = 140
                });
                panel.Children.Add(new TextBlock()
                {
                    Text = product.StorageAmount.ToString(),
                    Width = 30
                });
                panel.Children.Add(new TextBlock()
                {
                    Text = product.Price.ToString(),
                    Width = 30
                });
                panel.MouseLeftButtonDown += Row_Click;
                panel.DataContext = product.Id;

                ProductsStackPanel.Children.Add(panel);
            }
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            var senderName = (int)((StackPanel)sender).DataContext;
            var productId =senderName;

            var product = _productsService.GetProductById(productId);

            if (product != null)
            {
                _windowNavigator.ShowDialogWithParam<ProductManipulationWindow, Product>(product);
            }
        }
    }
}
