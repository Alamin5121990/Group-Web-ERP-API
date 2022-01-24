using System;

namespace LabaidMIS.Data.Classes.IT
{
    public class DBBackupValidation
    {
        public Nullable<decimal> TotalServer { get; set; }

        public Nullable<decimal> TotalBackup { get; set; }
        public Nullable<decimal> BackupPercent { get; set; }
    }
}