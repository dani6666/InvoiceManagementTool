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
