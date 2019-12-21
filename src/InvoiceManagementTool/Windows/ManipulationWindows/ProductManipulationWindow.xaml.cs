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

namespace InvoiceManagementTool.Windows.ManipulationWindows
{
    /// <summary>
    /// Interaction logic for ProductManipulationWindow.xaml
    /// </summary>
    public partial class ProductManipulationWindow : Window, IParametaisedWindow<Product>
    {
        public ProductManipulationWindow()
        {
            InitializeComponent();
        }

        public void SetParameter(Product parameter)
        {
            throw new NotImplementedException();
        }
    }
}
