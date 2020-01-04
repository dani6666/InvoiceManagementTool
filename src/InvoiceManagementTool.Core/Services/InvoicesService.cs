using InvoiceManagementTool.Core.Interfaces;
using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace InvoiceManagementTool.Core.Services
{
    public class InvoicesService : IInvoicesService
    {
        private readonly ISqlDatabaseConnector _sqlDatabaseConnector;

        public InvoicesService(ISqlDatabaseConnector sqlDatabaseConnector)
        {
            _sqlDatabaseConnector = sqlDatabaseConnector;
        }

        public List<Invoice> GetAllInvoices()
        {
            var invoices = new List<Invoice>();

            var sqlCommand = new MySqlCommand("SELECT ");

            var invoicesStrings = _sqlDatabaseConnector.SendSelectCommand(sqlCommand, 2);

            foreach (var invoicesString in invoicesStrings)
            {
                var invoice = new Invoice();

                invoices.Add(invoice);
            }

            return invoices;
        }

        public void AddInvoice(Invoice invoice)
        {

        }
    }
}
