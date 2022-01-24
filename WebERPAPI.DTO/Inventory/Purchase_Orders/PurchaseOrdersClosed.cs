using System;

namespace WebERPAPI.DTO.Inventory.Purchase_Orders
{
    public class PurchaseOrdersClosed
    {
        public string POID { get; set; }

        public Nullable<DateTime> PODate { get; set; }
        public string RequisitionID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }

        public string MaterialGrade { get; set; }
        public string VersionNo { get; set; }
        public Nullable<decimal> POAmount { get; set; }
        public string BillID { get; set; }
    }
}