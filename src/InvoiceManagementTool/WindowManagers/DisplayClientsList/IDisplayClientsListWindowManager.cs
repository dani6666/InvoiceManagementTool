using System;
using System.Collections.Generic;
using System.Text;
using InvoiceManagementTool.Core.Model;

namespace InvoiceManagementTool.WindowManagers.DisplayClientsList
{
    public interface IDisplayClientsListWindowManager
    {
        public List<Client> GetAllClients();

        public void OpenEditClientWindow(string clientId);
    }
}
