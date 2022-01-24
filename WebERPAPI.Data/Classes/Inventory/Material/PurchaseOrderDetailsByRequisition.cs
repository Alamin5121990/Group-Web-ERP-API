using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class PurchaseOrderDetailsByRequisition
    {
        public string POID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string VersionNo { get; set; }
        public string CSCode { get; set; }
        public Nullable<DateTime> CSDate { get; set; }
        public Nullable<decimal> CSQuantity { get; set; }
    }
}