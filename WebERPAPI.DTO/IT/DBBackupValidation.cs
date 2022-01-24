using System;

namespace WebERPAPI.DTO.IT
{
    public class DBBackupValidation
    {
        public Nullable<decimal> TotalServer { get; set; }

        public Nullable<decimal> TotalBackup { get; set; }
        public Nullable<decimal> BackupPercent { get; set; }
    }
}