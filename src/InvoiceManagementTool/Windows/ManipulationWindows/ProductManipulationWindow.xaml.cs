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
        private float _productPrice;
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
            _productPrice = parameter.Price;

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

                try
                {
                    if (_productId != 0)
                    {
                        _productsService.UpdateProduct(product);

                        if (_productPrice != product.Price)
                        {
                            _productsService.UpdateProductPrice(_productId, product.Price);
                        }
                    }
                    else
                    {
                        _productsService.AddProduct(product);
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid data input");
                    return;
                }


                MessageBox.Show("Operation completed successfully");

                Close();
            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }
    }
}
