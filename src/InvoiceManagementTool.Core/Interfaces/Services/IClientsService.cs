using InvoiceManagementTool.Core.Model;
using System.Collections.Generic;

namespace InvoiceManagementTool.Core.Interfaces.Services
{
    public interface IClientsService
    {
        List<Client> GetAllClients();
        void AddClient(Client client);
        void UpdateClient(Client client, string lastIdentity);
        void DeleteClient(string clientIdentity);
        Client GetClientById(string identity);
    }
}
