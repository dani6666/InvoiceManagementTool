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
                    Name = clientsString[1],
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
                                              $" (@Identity, @Name, @Surname, \'{client.DateOfBirth.ToString("yyyy-MM-dd")}\')");

            sqlCommand.Parameters.AddWithValue("@Identity", client.Identity);
            sqlCommand.Parameters.AddWithValue("@Name", client.Name);
            sqlCommand.Parameters.AddWithValue("@Surname", client.SurName);

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
        }

        public void UpdateClient(Client client, string lastIdentity)
        {
            var sqlCommand = new MySqlCommand("UPDATE Clients SET" +
                                              " id=@Identity," +
                                              " name=@Name," +
                                              " surname=@Surname," +
                                              $" dateOfBirth=\'{client.DateOfBirth.ToString("yyyy-MM-dd")}\'" + 
                                              " WHERE id=@LastId");

            sqlCommand.Parameters.AddWithValue("@Identity", client.Identity);
            sqlCommand.Parameters.AddWithValue("@Name", client.Name);
            sqlCommand.Parameters.AddWithValue("@Surname", client.SurName);
            sqlCommand.Parameters.AddWithValue("@LastId", lastIdentity);

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
        }

        public Client GetClientById(string identity)
        {
            var sqlCommand = new MySqlCommand("SELECT id, name, surname, dateOfBirth FROM Clients" +
                                              " WHERE id=@Id");

            sqlCommand.Parameters.AddWithValue("@Id", identity);

            var usersString = _sqlDatabaseConnector.SendSelectCommand(sqlCommand, 4)[0];

            var client = new Client
            {
                Identity = usersString[0],
                Name = usersString[1],
                SurName = usersString[2],
                DateOfBirth = DateTime.Parse(usersString[3])
            };

            return client;
        }
    }
}
