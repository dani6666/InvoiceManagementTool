using InvoiceManagementTool.Core.Interfaces;
using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Services;
using InvoiceManagementTool.Infrastructure;
using InvoiceManagementTool.WindowManagers.DisplayClientsList;
using InvoiceManagementTool.WindowManagers.DisplayProductsList;
using InvoiceManagementTool.WindowManagers.DisplayUsersList;
using InvoiceManagementTool.WindowManagers.Login;
using InvoiceManagementTool.Windows;
using InvoiceManagementTool.Windows.DisplayWindows;
using InvoiceManagementTool.Windows.ManipulationWindows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace InvoiceManagementTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<LoginWindow>()
                .AddSingleton<AdminAccessWindow>()
                .AddSingleton<CashierAccessWindow>()
                .AddSingleton<ManagerAccessWindow>()
                .AddSingleton<AccountantAccessWindow>()

                .AddSingleton<DisplayClientsListWindowManager>()
                .AddSingleton<DisplayProductsListWindowManager>()
                .AddSingleton<DisplayInvoicesListWindow>()
                .AddSingleton<DisplayUsersListWindow>()

                .AddSingleton<ClientManipulationWindow>()
                .AddSingleton<InvoiceManipulationWindow>()
                .AddSingleton<ProductManipulationWindow>()
                .AddSingleton<UserMaipulationWindow>()

                .AddTransient<ILoginWindowManager, LoginWindowManager>()
                .AddTransient<IDisplayClientsListWindowManager, DisplayClientsListWindowManager>()
                .AddTransient<IDisplayProductsListWindowManager, DisplayProductsListWindowManager>()
                .AddTransient<IDisplayUsersListWindowManager, DisplayUsersListWindowManager>()

                .AddTransient<ISqlDatabaseConnector, SqlDatabaseConnector>()
                .AddTransient<ISqlDatabaseConnector, SqlDatabaseConnector>()
                .AddTransient<ISqlDatabaseConnector, SqlDatabaseConnector>()
                .AddTransient<ISqlDatabaseConnector, SqlDatabaseConnector>()
                .AddTransient<ISqlDatabaseConnector, SqlDatabaseConnector>()
                .AddTransient<ISqlDatabaseConnector, SqlDatabaseConnector>()
                .AddTransient<ISqlDatabaseConnector, SqlDatabaseConnector>()
                .AddTransient<ISqlDatabaseConnector, SqlDatabaseConnector>()

                .AddSingleton<IWindowNavigator, WindowNavigator>()
                .AddTransient<ILoginUserService, UsersService>()
                .AddTransient<IClientsService, ClientsService>()
                .AddTransient<IProductsService, ProductsService>()
                .AddTransient<IInvoicesService, InvoicesService>()
                .AddTransient<ISqlDatabaseConnector, SqlDatabaseConnector>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var loginWindow = _serviceProvider.GetService<LoginWindow>();
            loginWindow.Show();
        }
    }
}
