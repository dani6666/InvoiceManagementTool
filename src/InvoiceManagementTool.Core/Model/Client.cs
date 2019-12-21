using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagementTool.Core.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
