using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO.Inventory
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
        public Nullable<decimal> TransferMRP { get; set; }
        public string ReleaseStatus { get; set; }
    }


    public class ProductionTransferStatementReportDto
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public Nullable<decimal> TP { get; set; }

        public Nullable<decimal> TotalTransferQty { get; set; }
        public Nullable<decimal> TotalMasterQty { get; set; }
        public Nullable<decimal> TotalLooseQty { get; set; }
        public Nullable<decimal> TotalTransferTP { get; set; }
        public Nullable<decimal> TotalTransferMRP { get; set; }
        public int TotalReleased { get; set; }
        public int TotalNotReleased { get; set; }
        public List<ProductionTransferStatement> BatchList = new List<ProductionTransferStatement>();
    }

}