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
