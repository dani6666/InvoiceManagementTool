using System;

namespace InvoiceManagementTool.Core.Model
{
    public class Client
    {
        public string Identity { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
