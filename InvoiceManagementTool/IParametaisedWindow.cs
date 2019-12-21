using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace InvoiceManagementTool
{
    public interface IParametaisedWindow<T>
    {
        void SetParameter(T parameter);
    }
}
