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
                    DateOfBirth = DateTime.Parse(clientsString[3])
                };

                clients.Add(client);
            }

            return clients;
        }

        public void AddClient(Client client)
        {
            var sqlCommand = new MySqlCommand("INSERT INTO Clients (id, name, surname, dateOfBirth) VALUES " +
                                              $" (\'{client.Identity}\', \'{client.Name}\', \'{client.SurName}\', \'{client.DateOfBirth.ToString("yyyy-MM-dd")}\')");

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
        }

        public void UpdateClient(Client client, string lastIdentity)
        {
            MySqlCommand sqlCommand = new MySqlCommand("UPDATE Clients SET" +
                                                       $" id=\'{client.Identity}\'," +
                                                       $" name=\'{client.Name}\'," +
                                                       $" surname=\'{client.SurName}\'," +
                                                       $" dateOfBirth=\'{client.DateOfBirth.ToString("yyyy-MM-dd")}\'" +
                                                       $" WHERE id=\'{lastIdentity}\'");

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
        }

        public void DeleteClient(string clientIdentity)
        {

        }

        public Client GetClientById(string identity)
        {
            var sqlCommand = new MySqlCommand("SELECT id, name, surname, dateOfBirth FROM Clients" +
                                              $" WHERE id=\'{identity}\'");

            var usersString = _sqlDatabaseConnector.SendSelectCommand(sqlCommand, 4)[0];

            var client = new Client
            {
                Identity= usersString[0],
                Name = usersString[1],
                SurName = usersString[2],
                DateOfBirth = DateTime.Parse(usersString[3])
            };

            return client;
        }
    }
}
