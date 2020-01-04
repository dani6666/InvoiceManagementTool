using InvoiceManagementTool.Core.Interfaces;
using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using MySql.Data.MySqlClient;
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
            var products = new List<Product>();

            var sqlCommand = new MySqlCommand("SELECT ");

            var productsStrings = _sqlDatabaseConnector.SendSelectCommand(sqlCommand, 2);

            foreach (var productsString in productsStrings)
            {
                var product = new Product();

                products.Add(product);
            }

            return products;
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
