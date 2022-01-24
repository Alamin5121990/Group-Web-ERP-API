using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class MaterialForDesignSubmit
    {
        public Nullable<int> CSID { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string CSCode { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public Nullable<DateTime> ReviewedOn { get; set; }
        public string VersionNo { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }

        public Nullable<Boolean> IsEmailSent { get; set; }
    }
}