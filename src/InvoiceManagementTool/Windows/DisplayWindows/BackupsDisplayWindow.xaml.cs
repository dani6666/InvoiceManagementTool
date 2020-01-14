using InvoiceManagementTool.Core.Interfaces.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InvoiceManagementTool.Windows.DisplayWindows
{
    /// <summary>
    /// Interaction logic for BackupsDisplayWindow.xaml
    /// </summary>
    public partial class BackupsDisplayWindow : Window
    {
        private readonly IBackupService _backupService;
        public BackupsDisplayWindow(IBackupService backupService)
        {
            InitializeComponent();

            _backupService = backupService;

            foreach (var backup in _backupService.GetAllBackups())
            {
                var textBlock = new TextBlock()
                {
                    Text = backup,
                    Width = 150
                };

                textBlock.MouseLeftButtonDown += Row_Click;

                BackupsStackPanel.Children.Add(textBlock);
            }
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            _backupService.RestoreDatabase(((TextBlock)sender).Text);

            MessageBox.Show("Database restored successfully");

            Close();
        }
    }
}
