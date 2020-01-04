using InvoiceManagementTool.Core.Interfaces;
using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using MySql.Data.MySqlClient;
using System;
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
            var clients = new List<Client>();

            var sqlCommand = new MySqlCommand("SELECT id, name, surname, dateOfBirth FROM Clients");

            var clientsStrings = _sqlDatabaseConnector.SendSelectCommand(sqlCommand, 4);

            foreach (var clientsString in clientsStrings)
            {
                var client = new Client
                {
                    Identity = clientsString[0],
                    Name= clientsString[1],
                    SurName = clientsString[2],
                    DateOfBirth = DateTime.Parse(clientsString[0])
                };

                clients.Add(client);
            }

            return clients;
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
