using System;
using System.Windows;

namespace InvoiceManagementTool
{
    public class WindowNavigator : IWindowNavigator
    {
        private readonly IServiceProvider serviceProvider;

        public WindowNavigator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Show<T>() where T : Window
        {
            T window = serviceProvider.GetService(typeof(T)) as T;

            window.Show();
        }

        public object ShowDialog<T>()
            where T : Window
        {
            T window = serviceProvider.GetService(typeof(T)) as T;

            window.ShowDialog();

            return window.DialogResult;
        }

        public object ShowDialogWithParam<T, U>(U parameter)
            where T : Window, IParametaisedWindow<U>
        {
            T window = serviceProvider.GetService(typeof(T)) as T;

            window.SetParameter(parameter);

            window.ShowDialog();

            return window.DialogResult;
        }
    }
}
