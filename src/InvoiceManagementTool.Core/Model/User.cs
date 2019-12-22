using InvoiceManagementTool.Core.Model.Enums;

namespace InvoiceManagementTool.Core.Model
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
}
