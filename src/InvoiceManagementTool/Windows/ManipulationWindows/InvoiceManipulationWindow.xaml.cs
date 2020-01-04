using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
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
        private int _invoiceId;
        public InvoiceManipulationWindow(IClientsService clientsService, IInvoicesService invoicesService,
            IProductsService productsService)
        {
            InitializeComponent();

            var stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            var comboBox = new ComboBox();
            var textBox = new TextBox();
            stackPanel.Children.Add(comboBox);
            stackPanel.Children.Add(textBox);

            ProductsStackPanel.Children.Add(stackPanel);
        }

        public void SetParameter(Invoice parameter)
        {
            var stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            var textBlock = new TextBlock();
            var datePicker = new DatePicker();
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(datePicker);

            ProductsStackPanel.Children.Add(stackPanel);

            _invoiceId = parameter.Id;
        }

        private void AddProductButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            var comboBox = new ComboBox();
            var textBox = new TextBox();
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
