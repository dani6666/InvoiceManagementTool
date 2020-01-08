using InvoiceManagementTool.Core.Model;
using System.Collections.Generic;

namespace InvoiceManagementTool.Core.Interfaces.Services
{
    public interface IProductsService
    {
        List<Product> GetAllProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void UpdateProductPrice(int productId, float newPrice);
        void DeleteProduct(int productId);
        Product GetProductById(int id);
    }
}
