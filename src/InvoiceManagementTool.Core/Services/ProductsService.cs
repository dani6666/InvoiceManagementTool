using InvoiceManagementTool.Core.Interfaces;
using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var sqlCommand = new MySqlCommand("SELECT id, name, storageAmount, " +
                                              $" getProductPriceAtDate(id, \'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\')" +
                                              " FROM Products");

            var productsStrings = _sqlDatabaseConnector.SendSelectCommand(sqlCommand, 4);

            return productsStrings.Select(productsString => new Product
            {
                Id = int.Parse(productsString[0]),
                Name = productsString[1],
                StorageAmount = int.Parse(productsString[2]),
                Price = int.Parse(productsString[3]) / 100.0f
            }).ToList();
        }

        public void AddProduct(Product product)
        {
            var sqlCommand = new MySqlCommand($"CALL addProduct(@Name,{product.StorageAmount},{product.Price * 100})");

            sqlCommand.Parameters.AddWithValue("@Name", product.Name);

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
        }

        public void UpdateProduct(Product product)
        {
            var sqlCommand = new MySqlCommand("UPDATE Products SET" +
                                              " name=@Name," +
                                              $" storageAmount={product.StorageAmount}" +
                                              $" WHERE id={product.Id}");

            sqlCommand.Parameters.AddWithValue("@Name", product.Name);

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
        }

        public void UpdateProductPrice(int productId, float newPrice)
        {
            var sqlCommand = new MySqlCommand($"CALL modifyProductPrice({productId},{newPrice * 100})");

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
        }

        public void DeleteProduct(int productId)
        {

        }

        public Product GetProductById(int id)
        {
            var sqlCommand = new MySqlCommand("SELECT id, name, storageAmount, " +
                                              $" getProductPriceAtDate(id, \'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\')" +
                                              " FROM Products" +
                                              $" WHERE id={id}");

            var productsStrings = _sqlDatabaseConnector.SendSelectCommand(sqlCommand, 4)[0];

            return new Product
            {
                Id = int.Parse(productsStrings[0]),
                Name = productsStrings[1],
                StorageAmount = int.Parse(productsStrings[2]),
                Price = int.Parse(productsStrings[3]) / 100.0f
            }; ;
        }
    }
}
