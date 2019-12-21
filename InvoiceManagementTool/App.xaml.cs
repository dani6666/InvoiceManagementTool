using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Services;
using InvoiceManagementTool.WindowManagers.AccountantAccess;
using InvoiceManagementTool.WindowManagers.AdminAccess;
using InvoiceManagementTool.WindowManagers.Login;
using InvoiceManagementTool.WindowManagers.ManagerAccess;
using InvoiceManagementTool.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
                .AddSingleton<IWindowNavigator, WindowNavigator>()
                .AddTransient<ILoginWindowManager, LoginWindowManager>()
                .AddTransient<IAdminAccessWindowManager, AdminAccessWindowManager>()
                .AddTransient<IAccountantAccessWindowManager, AccountantAccessWindowManager>()
                .AddTransient<IManagerAccessWindowManager, ManagerAccessWindowManager>()
                .AddTransient<ILoginAccountService, AccountService>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var loginWindow = _serviceProvider.GetService<LoginWindow>();
            loginWindow.Show();
        }
    }
}
