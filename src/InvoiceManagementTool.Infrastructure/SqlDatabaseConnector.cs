using InvoiceManagementTool.Core.Interfaces;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace InvoiceManagementTool.Infrastructure
{
    public class SqlDatabaseConnector : ISqlDatabaseConnector
    {
        private readonly MySqlConnection _sqlConnection = new MySqlConnection();

        public void SetUpConnectionString(string connectionString)
        {
            _sqlConnection.Close();
            _sqlConnection.ConnectionString = connectionString;
            _sqlConnection.Open();
        }

        public List<string[]> SendSelectCommand(MySqlCommand sqlCommand, int columnCount)
        {
            var result = new List<string[]>();

            sqlCommand.Connection = _sqlConnection;
            sqlCommand.CommandType = CommandType.Text;

            MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var row = new string[columnCount];

                for (int i = 0; i < columnCount; i++)
                {
                    row[i] = sqlDataReader.GetString(i + 1);
                }

                result.Add(row);
            }

            return result;
        }

        public void SendExecutableCommand(MySqlCommand sqlCommand)
        {
            sqlCommand.Connection = _sqlConnection;
            sqlCommand.CommandType = CommandType.Text;

            sqlCommand.ExecuteNonQuery();
        }

    }
}
