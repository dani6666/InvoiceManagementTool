using System;
using System.Collections.Generic;
using System.Text;
using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using InvoiceManagementTool.Windows;
using InvoiceManagementTool.Windows.ManipulationWindows;

namespace InvoiceManagementTool.WindowManagers.DisplayClientsList
{
    public class DisplayClientsListWindowManager : IDisplayClientsListWindowManager
    {
        private readonly IClientsService _clientsService;
        private readonly IWindowNavigator _windowNavigator;

        public DisplayClientsListWindowManager(IClientsService clientsService, IWindowNavigator windowNavigator)
        {
            _clientsService = clientsService;
            _windowNavigator = windowNavigator;
        }

        public List<Client> GetAllClients()
        {
            return _clientsService.GetAllClients();
        }

        public void OpenEditClientWindow(int clientId)
        {
            var client= _clientsService.GetClientById(clientId);

            if (client != null)
            {
                _windowNavigator.ShowDialogWithParam<ClientManipulationWindow, Client>(client);
            }
        }
    }
}
