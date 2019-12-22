using InvoiceManagementTool.Core.Model;
using System;

namespace InvoiceManagementTool.Windows
{
    /// <summary>
    /// Interaction logic for InvoiceManipulationWindow.xaml
    /// </summary>
    public partial class InvoiceManipulationWindow : IParametaisedWindow<Invoice>
    {
        public InvoiceManipulationWindow()
        {
            InitializeComponent();
        }

        public void SetParameter(Invoice parameter)
        {
            throw new NotImplementedException();
        }
    }
}
