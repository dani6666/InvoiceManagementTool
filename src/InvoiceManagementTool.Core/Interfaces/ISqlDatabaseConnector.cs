using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace InvoiceManagementTool.Core.Interfaces
{
    public interface ISqlDatabaseConnector
    {
        void SetUpConnectionString(string connectionString);
        List<string[]> SendSelectCommand(MySqlCommand sqlCommand, int columnCount);
        void SendExecutableCommand(MySqlCommand sqlCommand);
    }
}
