using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class MaterialPurchaseHistory
    {
        public string CompanyID { get; set; }
        public string MaterialCode { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        public System.DateTime GRNDate { get; set; }
        public Nullable<decimal> ReceiveQty { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> FCRate { get; set; }
    }

    public class SupplierPurchaseHistory
    {
        public string CompanyID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
        public Nullable<decimal> ReceiveQty { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> FCRate { get; set; }
    }
}