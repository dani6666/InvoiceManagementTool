using InvoiceManagementTool.Core.Model;
using System.Collections.Generic;

namespace InvoiceManagementTool.Core.Interfaces.Services
{
    public interface IProductsService
    {
        List<Product> GetAllProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
        Product GetProductById(int id);
    }
}
