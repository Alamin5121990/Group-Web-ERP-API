using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class ProductionStatus
    {
        public string BatchID { get; set; }
        public string BatchNo { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public string ProductionLocation { get; set; }
        public string DosageForm { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<int> SLNo { get; set; }
        public string ProcessID { get; set; }
        public string ProcessName { get; set; }
        public Nullable<DateTime> EndTime { get; set; }
    }

    public class ProductionStatusReport
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public string ProductionLocation { get; set; }
        public string DosageForm { get; set; }
        public string BatchID { get; set; }
        public string BatchNo { get; set; }

        public List<ProductionStatus> BatchDetails { get; set; }
    }
}