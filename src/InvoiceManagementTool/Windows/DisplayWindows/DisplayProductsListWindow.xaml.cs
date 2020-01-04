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

            var product = _productsService.GetProductById(productId);

            if (product != null)
            {
                _windowNavigator.ShowDialogWithParam<ProductManipulationWindow, Product>(product);
            }
        }
    }
}
