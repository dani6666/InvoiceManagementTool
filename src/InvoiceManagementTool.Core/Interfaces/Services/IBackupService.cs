using System.Collections.Generic;

namespace InvoiceManagementTool.Core.Interfaces.Services
{
    public interface IBackupService
    {
        void BackupDatabase();
        void RestoreDatabase(string date);
        public List<string> GetAllBackups();
    }
}