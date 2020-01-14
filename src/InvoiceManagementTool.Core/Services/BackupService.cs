using InvoiceManagementTool.Core.Interfaces;
using InvoiceManagementTool.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InvoiceManagementTool.Core.Services
{
    public class BackupService : IBackupService
    {
        private  readonly ISqlDatabaseConnector _sqlDatabaseConnector;
        private readonly string _backupsPath;

        public BackupService(ISqlDatabaseConnector sqlDatabaseConnector)
        {
            _sqlDatabaseConnector = sqlDatabaseConnector;
            _backupsPath = Path.Combine(Environment.CurrentDirectory, "Backups");
        }
        public void BackupDatabase()
        {
            _sqlDatabaseConnector.Backup(Path.Combine(_backupsPath, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".sql"));
            //var script = "cd C:\\Program Files\\MySQL\\MySQL Server 5.5\\bin" + Environment.NewLine +
            //             ".\\mysqldump.exe -h localhost -u root -p Fredek " +
            //             $"--result-file={Path.Combine(Environment.CurrentDirectory, DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss") + ".sql")} --databases InvoiceManagement /c";
            //var res = System.Diagnostics.Process.Start("CMD.exe", script);

            //res.WaitForExit();
            //using (var PowerShellInstance = PowerShell.Create())
            //{
                
            //    //                PowerShellInstance.AddScript("cd C:\\Program Files\\MySQL\\MySQL Server 5.5\\bin");
            //    PowerShellInstance.AddScript(".\\mysqldump.exe -h localhost -u IMAdmin -p ceda392467dc055ce0cc55cd5a23e062 " +
            //                                 $"--result-file={Path.Combine(Environment.CurrentDirectory, DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss") + ".sql")} --databases InvoiceManagement /c");
            //    /*--defaults-extra-file=$config*/
            //    /*--log-error=$errorLog*/

            //    //PowerShellInstance.Invoke();
            //}
        }

        public void RestoreDatabase(string date)
        {
            _sqlDatabaseConnector.Restore(Path.Combine(_backupsPath,date));
        }

        public List<string> GetAllBackups()
        {
            return Directory.GetFiles(_backupsPath).Select(s => s.Split('\\').Last()).ToList();
        }
    }
}
