using InvoiceManagementTool.Core.Model;
using System.Collections.Generic;

namespace InvoiceManagementTool.Core.Interfaces.Services
{
    public interface IInvoicesService
    {
        List<InvoiceView> GetAllInvoices();

        void AddInvoice(Invoice invoice);

        void UpdateInvoice(Invoice invoice);

        void UpdateInvoiceProducts(int invoiceId, List<InvoiceProduct> newProducts);

        void DeleteInvoice(int invoiceId);

        Invoice GetInvoiceById(int id);
    }
}
