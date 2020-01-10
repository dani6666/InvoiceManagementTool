using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
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
        private readonly List<Product> _allProducts;
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
            var stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            var textBlock = new TextBlock();
            var datePicker = new DatePicker();
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(datePicker);

            ProductsStackPanel.Children.Add(stackPanel);

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

        }

        private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }
    }
}
