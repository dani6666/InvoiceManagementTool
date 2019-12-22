using InvoiceManagementTool.Core.Model;
using System;
using System.Windows;

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
