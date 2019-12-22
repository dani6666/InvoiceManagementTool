using InvoiceManagementTool.Core.Interfaces.Services;
using System.Windows;

namespace InvoiceManagementTool.Windows.DisplayWindows
{
    /// <summary>
    /// Interaction logic for DisplayInvoicesListWindow.xaml
    /// </summary>
    public partial class DisplayInvoicesListWindow : Window
    {
        private readonly IInvoicesService _invoicesService;
        public DisplayInvoicesListWindow(IInvoicesService invoicesService)
        {
            InitializeComponent();

            _invoicesService = invoicesService;
        }
    }
}
