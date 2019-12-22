using InvoiceManagementTool.Core.Model;
using System.Collections.Generic;

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
