using System;

namespace WebERPAPI.DTO.Inventory
{
    public class PurchaseOrderDetails
    {
        public Nullable<int> SLNo { get; set; }
        public string CSCode { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string ShortSpec { get; set; }
        public string VersionNo { get; set; }
        public string CountryofOrigin { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> Vat { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> TotalValue { get; set; }
    }
}