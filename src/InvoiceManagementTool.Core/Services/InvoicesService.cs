using InvoiceManagementTool.Core.Interfaces;
using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
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
            return null;
        }

        public void AddInvoice(Invoice invoice)
        {

        }
    }
}
