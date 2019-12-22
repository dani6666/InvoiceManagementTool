using InvoiceManagementTool.Core.Model;
using System;

namespace InvoiceManagementTool.Windows
{
    public partial class ClientManipulationWindow : IParametaisedWindow<Client>
    {
        public ClientManipulationWindow()
        {
            InitializeComponent();
        }

        public void SetParameter(Client parameter)
        {
            throw new NotImplementedException();
        }
    }
}
