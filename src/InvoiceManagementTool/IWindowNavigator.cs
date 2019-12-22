using System.Windows;

namespace InvoiceManagementTool
{
    public interface IWindowNavigator
    {
        void Show<T>() where T : Window;

        object ShowDialog<T>() where T : Window;

        public object ShowDialogWithParam<T, U>(U parameter) where T : Window, IParametaisedWindow<U>;
    }
}
