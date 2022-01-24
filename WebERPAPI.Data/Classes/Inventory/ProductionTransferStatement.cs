using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class ProductionTransferStatement
    {
        public string CompanyID { get; set; }
        public string TransferNoteNo { get; set; }
        public Nullable<DateTime> TransferDate { get; set; }
        public Nullable<DateTime> ReleaseDate { get; set; }
        public string BatchID { get; set; }
        public string BatchNo { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> TransferQty { get; set; }
        public Nullable<decimal> MasterQty { get; set; }
        public Nullable<decimal> LooseQty { get; set; }
        public Nullable<decimal> TransferTP { get; set; }
        public string ReleaseStatus { get; set; }
    }
}