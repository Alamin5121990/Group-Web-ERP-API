using System;

namespace WebERPAPI.DTO.Inventory.Procurement.Quotation
{
    public class QuotationsNonProduction
    {
        public Nullable<int> ID { get; set; }
        public string QuotationCode { get; set; }

        public string RequisitionCode { get; set; }
        public Nullable<int> TotalItem { get; set; }

        public string MainGroups { get; set; }
        public string SubGroups { get; set; }
        public string ItemNames { get; set; }

        public Nullable<int> TotalSupplier { get; set; }
        public Nullable<DateTime> LastReceiveDate { get; set; }
        public string CreatedByID { get; set; }

        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string Remarks { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }

        public Nullable<bool> IsCanceled { get; set; }
        public string CancelBy { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
        public string ReasonToCanceled { get; set; }

        public string RequisitionRemarks { get; set; }
        public string RequisitionVerifyRemarks { get; set; }
        public string RequisitionApprovalRemarks { get; set; }

        public bool IsEmailSent { get; set; }
        public bool IsQuotationReceived { get; set; }

        public int InventoryTypeID { get; set; }
    }
}