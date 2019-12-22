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
using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model.Enums;
using InvoiceManagementTool.WindowManagers.DisplayClientsList;
using InvoiceManagementTool.WindowManagers.DisplayUsersList;

namespace InvoiceManagementTool.Windows.DisplayWindows
{
    /// <summary>
    /// Interaction logic for DisplayClientsListWindow.xaml
    /// </summary>
    public partial class DisplayClientsListWindow : Window
    {
        private readonly IDisplayClientsListWindowManager _displayClientsListWindowManager;
        public DisplayClientsListWindow(IDisplayClientsListWindowManager displayClientsListWindowManager)
        {
            InitializeComponent();

            _displayClientsListWindowManager = displayClientsListWindowManager;

            foreach (var client in _displayClientsListWindowManager.GetAllClients())
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

            _displayClientsListWindowManager.OpenEditClientWindow(clientId);
        }
    }
}
