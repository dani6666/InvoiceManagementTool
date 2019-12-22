using InvoiceManagementTool.Core.Model;
using System;
using System.Windows;

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
