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
