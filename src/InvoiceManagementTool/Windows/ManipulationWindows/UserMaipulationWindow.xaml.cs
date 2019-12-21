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
    /// Interaction logic for UserMaipulationWindow.xaml
    /// </summary>
    public partial class UserMaipulationWindow : Window, IParametaisedWindow<User>
    {
        public UserMaipulationWindow()
        {
            InitializeComponent();
        }

        public void SetParameter(User parameter)
        {
            throw new NotImplementedException();
        }
    }
}
