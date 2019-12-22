using InvoiceManagementTool.Core.Interfaces;
using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using System.Collections.Generic;

namespace InvoiceManagementTool.Core.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ISqlDatabaseConnector _sqlDatabaseConnector;

        public ProductsService(ISqlDatabaseConnector sqlDatabaseConnector)
        {
            _sqlDatabaseConnector = sqlDatabaseConnector;
        }

        public List<Product> GetAllProducts()
        {
            return null;
        }

        public void AddProduct(Product product)
        {

        }

        public void UpdateProduct(Product product)
        {

        }

        public void DeleteProduct(int productId)
        {

        }

        public Product GetProductById(int id)
        {
            return null;
        }
    }
}
