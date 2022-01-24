using System;

namespace WebERPAPI.DTO.Inventory
{
    public class RequisitionQuantitySummary
    {
        public Nullable<DateTime> ReqDate { get; set; }
        public Boolean IsApproved { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ApprovedDate { get; set; }

        public string RequisitionID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string VersionNo { get; set; }

        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public Nullable<decimal> LCQuantity { get; set; }
        public Nullable<decimal> GRNQuantity { get; set; }
        public Nullable<decimal> RemainingQuantity { get; set; }
    }

    public class RequisitionSummaryReport
    {
        public Nullable<DateTime> ReqDate { get; set; }
        public Boolean IsApproved { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ApprovedDate { get; set; }

        public string RequisitionID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string VersionNo { get; set; }

        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public Nullable<decimal> LCQuantity { get; set; }
        public Nullable<decimal> GRNQuantity { get; set; }
        public Nullable<decimal> RemainingQuantity { get; set; }
        public Nullable<decimal> MaterialRemainingQuantity { get; set; }
    }
}