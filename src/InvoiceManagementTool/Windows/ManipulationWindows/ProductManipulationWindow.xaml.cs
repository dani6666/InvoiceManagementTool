using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using System.Windows;

namespace InvoiceManagementTool.Windows.ManipulationWindows
{
    /// <summary>
    /// Interaction logic for ProductManipulationWindow.xaml
    /// </summary>
    public partial class ProductManipulationWindow : Window, IParametaisedWindow<Product>
    {
        private readonly IProductsService _productsService;
        private int _productId;
        public ProductManipulationWindow(IProductsService productsService)
        {
            InitializeComponent();

            _productsService = productsService;
        }

        public void SetParameter(Product parameter)
        {
            Title = "Update product";
            ApplyButton.Content = "Update product";

            _productId = parameter.Id;

            NameTextBox.Text = parameter.Name;
            StorageAmountTextBox.Text = parameter.StorageAmount.ToString();
            PriceTextBox.Text = parameter.Price.ToString();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(StorageAmountTextBox.Text, out int amount) && float.TryParse(PriceTextBox.Text, out float price))
            {
                var product = new Product
                {
                    Id = _productId,
                    Name = NameTextBox.Text,
                    StorageAmount = amount,
                    Price = price
                };

                if (_productId!=0)
                {
                    _productsService.UpdateProduct(product);
                }
                else
                {
                    _productsService.AddProduct(product);
                }
            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }
    }
}
