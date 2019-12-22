using InvoiceManagementTool.Core.Model;
using System.Collections.Generic;

namespace InvoiceManagementTool.WindowManagers.DisplayProductsList
{
    public interface IDisplayProductsListWindowManager
    {
        List<Product> GetAllProducts();
        void OpenEditProductWindow(int productId);
    }
}
