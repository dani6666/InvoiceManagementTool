using InvoiceManagementTool.Core.Interfaces;
using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceManagementTool.Core.Services
{
    public class InvoicesService : IInvoicesService
    {
        private readonly ISqlDatabaseConnector _sqlDatabaseConnector;

        public InvoicesService(ISqlDatabaseConnector sqlDatabaseConnector)
        {
            _sqlDatabaseConnector = sqlDatabaseConnector;
        }

        public List<InvoiceView> GetAllInvoices()
        {
            var sqlCommand = new MySqlCommand("SELECT Invoices.id, dateOfIssue, name, surname, SUM(amount * priceAtTheTime) FROM Invoices" +
                                              " INNER JOIN Clients ON Clients.id = Invoices.clientId" +
                                              " INNER JOIN InvoiceProducts ON InvoiceProducts.invoiceId = Invoices.id" +
                                              " GROUP BY Invoices.id");

            var invoicesStrings = _sqlDatabaseConnector.SendSelectCommand(sqlCommand, 5);

            return invoicesStrings.Select(invoicesString => new InvoiceView
            {
                Id = int.Parse(invoicesString[0]),
                DateOfIssue = invoicesString[1],
                ClientName = invoicesString[2],
                ClientSurname = invoicesString[3],
                TotalValue = int.Parse(invoicesString[4]) / 100.0f
            })
                .ToList();
        }

        public void AddInvoice(Invoice invoice)
        {
            var sqlCommand = new MySqlCommand("CALL addInvoice(@Id, " +
                                              $"\'{invoice.DateOfIssue.ToString("yyyy-MM-dd HH:mm:ss")}\')");

            sqlCommand.Parameters.AddWithValue("@Id", invoice.Client.Identity);

            var invoiceId = _sqlDatabaseConnector.SendSelectCommand(sqlCommand, 1)[0][0];

            foreach (var product in invoice.InvoiceProducts)
            {
                sqlCommand = new MySqlCommand($"CALL addProductToInvoice({invoiceId},{product.Product.Id},{product.Amount})");

                _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
            }
        }

        public void UpdateInvoice(Invoice invoice)
        {
            var sqlCommand = new MySqlCommand("UPDATE Invoices SET" +
                                              " clientId=@Id, " +
                                              $" dateOfIssue=\'{invoice.DateOfIssue.ToString("yyyy-MM-dd HH:mm:ss")}\'" +
                                              $" WHERE id={invoice.Id}");

            sqlCommand.Parameters.AddWithValue("@Id", invoice.Client.Identity);

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
        }

        public void UpdateInvoiceProducts(int invoiceId, List<InvoiceProduct> newProducts)
        {
            var sqlCommand = new MySqlCommand($"CALL removeAllProductsFromInvoice({invoiceId})");

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);

            foreach (var product in newProducts)
            {
                sqlCommand = new MySqlCommand($"CALL addProductToInvoice({invoiceId},{product.Product.Id},{product.Amount})");

                _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
            }
        }

        public void DeleteInvoice(int invoiceId)
        {
            var sqlCommand = new MySqlCommand($"CALL removeAllProductsFromInvoice({invoiceId})");

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);

            sqlCommand = new MySqlCommand($"DELETE FROM Invoices WHERE id={invoiceId}");

            _sqlDatabaseConnector.SendExecutableCommand(sqlCommand);
        }

        public Invoice GetInvoiceById(int id)
        {
            var sqlCommand =
                new MySqlCommand("SELECT dateOfIssue, clientId FROM Invoices" +
                                 $" WHERE id={id}");

            var invoicesStrings = _sqlDatabaseConnector.SendSelectCommand(sqlCommand, 2)[0];

            var invoice = new Invoice
            {
                Id = id,
                DateOfIssue = DateTime.Parse(invoicesStrings[0]),
                Client = new Client
                {
                    Identity = invoicesStrings[1]
                },
                InvoiceProducts = new List<InvoiceProduct>()
            };

            sqlCommand =
                new MySqlCommand("SELECT id, name, amount FROM Products" +
                                 " INNER JOIN InvoiceProducts ON Products.id = InvoiceProducts.productId" +
                                 $" WHERE invoiceId={id}");

            var productsStrings = _sqlDatabaseConnector.SendSelectCommand(sqlCommand, 3);

            foreach (var productSting in productsStrings)
            {
                var product = new InvoiceProduct
                {
                    Amount = int.Parse(productSting[2]),
                    Product = new Product
                    {
                        Id = int.Parse(productSting[0]),
                        Name = productSting[1]
                    }
                };

                invoice.InvoiceProducts.Add(product);
            }

            return invoice;
        }
    }
}
