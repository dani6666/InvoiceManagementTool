using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InvoiceManagementTool.Windows.DisplayWindows
{
    /// <summary>
    /// Interaction logic for DisplayClientsListWindow.xaml
    /// </summary>
    public partial class DisplayClientsListWindow : Window
    {
        private readonly IClientsService _clientsService;
        private readonly IWindowNavigator _windowNavigator;
        public DisplayClientsListWindow(IClientsService clientsService, IWindowNavigator windowNavigator)
        {
            InitializeComponent();

            _clientsService = clientsService;
            _windowNavigator = windowNavigator;

            foreach (var client in _clientsService.GetAllClients())
            {
                var panel = new StackPanel();
                panel.Children.Add(new TextBlock()
                {
                    Text = client.Identity
                });
                panel.Children.Add(new TextBlock()
                {
                    Text = client.Name
                });
                panel.Children.Add(new TextBlock()
                {
                    Text = client.SurName
                });
                panel.Children.Add(new TextBlock()
                {
                    Text = client.DateOfBirth.ToShortDateString()
                });
                panel.MouseLeftButtonDown += Row_Click;

                ClientsStackPanel.Children.Add(panel);
            }
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            var clientId = ((TextBlock)((StackPanel)sender).Children[0]).Text;

            var client = _clientsService.GetClientById(clientId);

            if (client != null)
            {
                _windowNavigator.ShowDialogWithParam<ClientManipulationWindow, Client>(client);
            }
        }
    }
}
