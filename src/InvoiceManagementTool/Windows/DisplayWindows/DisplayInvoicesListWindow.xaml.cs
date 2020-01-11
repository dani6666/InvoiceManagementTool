using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InvoiceManagementTool.Windows.DisplayWindows
{
    /// <summary>
    /// Interaction logic for DisplayInvoicesListWindow.xaml
    /// </summary>
    public partial class DisplayInvoicesListWindow : Window
    {
        private readonly IInvoicesService _invoicesService;
        private readonly IWindowNavigator _windowNavigator;
        public DisplayInvoicesListWindow(IInvoicesService invoicesService, IWindowNavigator windowNavigator)
        {
            InitializeComponent();

            _invoicesService = invoicesService;
            _windowNavigator = windowNavigator;

            foreach (var invoice in _invoicesService.GetAllInvoices())
            {
                var panel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    DataContext = invoice.Id
                };

                panel.Children.Add(new TextBlock()
                {
                    Text = invoice.DateOfIssue,
                    Width = 65
                });
                panel.Children.Add(new TextBlock()
                {
                    Text = invoice.ClientName,
                    Width = 70
                });
                panel.Children.Add(new TextBlock()
                {
                    Text = invoice.ClientSurname,
                    Width = 75
                });
                panel.Children.Add(new TextBlock()
                {
                    Text = invoice.TotalValue.ToString(),
                    Width = 60
                });
                panel.MouseLeftButtonDown += Row_Click;

                InvoicesStackPanel.Children.Add(panel);
            }
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            var invoiceId = (int)((TextBlock)((StackPanel)sender).Children[0]).DataContext;

            var invoice = _invoicesService.GetInvoiceById(invoiceId);

            if (invoice != null)
            {
                _windowNavigator.ShowDialogWithParam<InvoiceManipulationWindow, Invoice>(invoice);
            }
        }
    }
}
