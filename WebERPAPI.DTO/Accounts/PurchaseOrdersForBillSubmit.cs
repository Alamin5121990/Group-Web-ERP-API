using System;

namespace WebERPAPI.DTO.Accounts
{
    public class PurchaseOrdersForBillSubmit
    {
        public string POID { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public Nullable<decimal> POAmount { get; set; }
        public string ChallanNo { get; set; }
        public string RequisitionID { get; set; }

        public Nullable<decimal> VATAmount { get; set; }
        public Nullable<decimal> CarryingCost { get; set; }
        public Nullable<decimal> LabourCost { get; set; }
        public Nullable<decimal> OtherCost { get; set; }
        public string OtherCostName { get; set; }
        public Nullable<decimal> Discount { get; set; }
    }
}