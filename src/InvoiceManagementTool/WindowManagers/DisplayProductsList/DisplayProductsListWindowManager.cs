﻿using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using InvoiceManagementTool.Windows.ManipulationWindows;
using System.Collections.Generic;

namespace InvoiceManagementTool.WindowManagers.DisplayProductsList
{
    public class DisplayProductsListWindowManager : IDisplayProductsListWindowManager
    {
        private readonly IProductsService _productsService;
        private readonly IWindowNavigator _windowNavigator;

        public DisplayProductsListWindowManager(IProductsService productsService, IWindowNavigator windowNavigator)
        {
            _productsService = productsService;
            _windowNavigator = windowNavigator;
        }

        public List<Product> GetAllProducts()
        {
            return _productsService.GetAllProducts();
        }

        public void OpenEditProductWindow(int productId)
        {
            var product = _productsService.GetProductById(productId);

            if (product != null)
            {
                _windowNavigator.ShowDialogWithParam<ProductManipulationWindow, Product>(product);
            }
        }
    }
}
