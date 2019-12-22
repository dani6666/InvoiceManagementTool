using InvoiceManagementTool.Core.Model.Enums;

namespace InvoiceManagementTool.Core.Interfaces.Services
{
    public interface ILoginUserService
    {
        Roles? ValidateUser(string login, string password);
    }
}
