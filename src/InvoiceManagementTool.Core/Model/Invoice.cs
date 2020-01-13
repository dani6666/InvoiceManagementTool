using System;
using System.Collections.Generic;

namespace InvoiceManagementTool.Core.Model
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public Client Client { get; set; }
        public List<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>();
    }
}
