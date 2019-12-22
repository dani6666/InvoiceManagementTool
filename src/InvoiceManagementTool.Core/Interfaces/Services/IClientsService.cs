using System;
using System.Collections.Generic;
using System.Text;
using InvoiceManagementTool.Core.Model;

namespace InvoiceManagementTool.Core.Interfaces.Services
{
    public interface IClientsService
    {
        List<Client> GetAllClients();
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int clientId);
        Client GetClientById(string identity);
    }
}
