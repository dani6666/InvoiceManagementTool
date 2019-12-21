using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace InvoiceManagementTool.Infrastructure
{
    public class SqlDatabaseConnector
    {
        private readonly SqlConnection _sqlConnection = new SqlConnection();

        public void SetUpConnectionString(string connectionString)
        {
            _sqlConnection.Close();
            _sqlConnection.ConnectionString = connectionString;
            _sqlConnection.Open();
        }

        public List<string[]> SendSelectCommand(SqlCommand sqlCommand, int columnCount)
        {
            var result = new List<string[]>();

            sqlCommand.Connection = _sqlConnection;
            sqlCommand.CommandType = CommandType.Text;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
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
