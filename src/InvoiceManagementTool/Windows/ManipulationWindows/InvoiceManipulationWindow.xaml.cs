using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace InvoiceManagementTool.Windows
{
    /// <summary>
    /// Interaction logic for InvoiceManipulationWindow.xaml
    /// </summary>
    public partial class InvoiceManipulationWindow : IParametaisedWindow<Invoice>
    {
        private readonly IClientsService _clientsService;
        private readonly IInvoicesService _invoicesService;
        private readonly IProductsService _productsService;
        private DatePicker _dateOfIssuePicker;
        private readonly List<Product> _allProducts;
        private readonly List<InvoiceProduct> _invoiceProducts;
        private readonly List<Client> _allClients;
        private int _invoiceId;
        public InvoiceManipulationWindow(IClientsService clientsService, IInvoicesService invoicesService,
            IProductsService productsService)
        {
            InitializeComponent();

            _allProducts = productsService.GetAllProducts();
            _allClients = clientsService.GetAllClients();

            ClientsComboBox.ItemsSource = _allClients;
            var stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            var comboBox = new ComboBox
            {
                ItemsSource = _allProducts,
                Width = 140,
                Margin = new Thickness(105, 0, 0, 0)
            };
            var textBox = new TextBox
            {
                Width = 40,
                Margin = new Thickness(20, 0, 0, 0)
            };
            stackPanel.Children.Add(comboBox);
            stackPanel.Children.Add(textBox);

            ProductsStackPanel.Children.Add(stackPanel);
        }

        public void SetParameter(Invoice parameter)
        {
            var dateStackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            var textBlock = new TextBlock();
            _dateOfIssuePicker = new DatePicker();
            dateStackPanel.Children.Add(textBlock);
            dateStackPanel.Children.Add(_dateOfIssuePicker);

            OverallStackPanel.Children.Insert(1, dateStackPanel);

            ProductsStackPanel.Children.Clear();

            foreach (var invoiceProduct in parameter.InvoiceProducts)
            {
                var stackPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };
                var comboBox = new ComboBox
                {
                    ItemsSource = _allProducts,
                    Width = 140,
                    Margin = new Thickness(105, 0, 0, 0),
                    SelectedItem = invoiceProduct.Product
                };
                var textBox = new TextBox
                {
                    Width = 40,
                    Margin = new Thickness(20, 0, 0, 0),
                    Text = invoiceProduct.Amount.ToString()
                };
                stackPanel.Children.Add(comboBox);
                stackPanel.Children.Add(textBox);

                ProductsStackPanel.Children.Add(stackPanel);
            }

            _invoiceId = parameter.Id;
        }

        private void AddProductButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            var comboBox = new ComboBox
            {
                ItemsSource = _allProducts,
                Width = 140,
                Margin = new Thickness(105, 0, 0, 0)
            };
            var textBox = new TextBox
            {
                Width = 40,
                Margin = new Thickness(20, 0, 0, 0)
            };
            stackPanel.Children.Add(comboBox);
            stackPanel.Children.Add(textBox);

            ProductsStackPanel.Children.Add(stackPanel);
        }

        private void RemoveProductButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ProductsStackPanel.Children.RemoveAt(ProductsStackPanel.Children.Count - 1);
        }

        private void ApplyButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var invoice = new Invoice
            {
                Client = (Client)ClientsComboBox.SelectedItem
            };

            foreach (StackPanel productPanel in ProductsStackPanel.Children)
            {
                var product = new InvoiceProduct
                {
                    Product = (Product)((ComboBox)productPanel.Children[0]).SelectedItem,
                    Amount = int.Parse(((TextBox)productPanel.Children[1]).Text)
                };

                invoice.InvoiceProducts.Add(product);
            }

            if (_invoiceId == 0)
            {
                invoice.Id = _invoiceId;
                invoice.DateOfIssue = DateTime.Now;

                _invoicesService.AddInvoice(invoice);
            }
            else
            {
                invoice.DateOfIssue = _dateOfIssuePicker.SelectedDate.Value;

                _invoicesService.UpdateInvoice(invoice);

                if (invoice.InvoiceProducts.Count != _invoiceProducts.Count)
                {
                    _invoicesService.UpdateInvoiceProducts(_invoiceId, invoice.InvoiceProducts);
                }
                else
                {
                    for (int i = 0; i < _invoiceProducts.Count; i++)
                    {
                        if (_invoiceProducts[i].Amount != invoice.InvoiceProducts[i].Amount ||
                            _invoiceProducts[i].Product.Id != invoice.InvoiceProducts[i].Product.Id)
                        {
                            _invoicesService.UpdateInvoiceProducts(_invoiceId, invoice.InvoiceProducts);

                            return;
                        }
                    }
                }
            }
        }

        private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            _invoicesService.DeleteInvoice(_invoiceId);
        }
    }
}
