using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class QuotationReceiveDetails
    {
        public string QuotationCode { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string VersionNo { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> ReceivedPrice { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }

        public Nullable<decimal> LastPurchaseQuantity { get; set; }
        public Nullable<decimal> LastPurchaseRate { get; set; }
        public Nullable<DateTime> LastPurchasedOn { get; set; }

        public Boolean IsLowestRate { get; set; }
    }
}