using System;
using System.Collections.Generic;
using System.Text;
using InvoiceManagementTool.Core.Model;

namespace InvoiceManagementTool.WindowManagers.DisplayProductsList
{
    public interface IDisplayProductsListWindowManager
    {
        List<Product> GetAllProducts();
        void OpenEditProductWindow(int productId);
    }
}
