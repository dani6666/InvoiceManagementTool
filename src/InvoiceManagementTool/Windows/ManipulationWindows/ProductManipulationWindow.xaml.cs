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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(StorageAmountTextBox.Text, out int amount) && float.TryParse(PriceTextBox.Text, out float price))
            {

            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }
    }
}
