using InvoiceManagementTool.Core.Interfaces;
using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using System.Collections.Generic;

namespace InvoiceManagementTool.Core.Services
{
    public class ClientsService : IClientsService
    {
        private readonly ISqlDatabaseConnector _sqlDatabaseConnector;

        public ClientsService(ISqlDatabaseConnector sqlDatabaseConnector)
        {
            _sqlDatabaseConnector = sqlDatabaseConnector;
        }

        public List<Client> GetAllClients()
        {
            return null;
        }

        public void AddClient(Client client)
        {

        }

        public void UpdateClient(Client client, string lastIdentity)
        {

        }

        public void DeleteClient(string clientIdentity)
        {

        }

        public Client GetClientById(string identity)
        {
            return null;
        }
    }
}
