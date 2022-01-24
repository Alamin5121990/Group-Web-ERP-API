using System;

namespace WebERPAPI.DTO.Inventory
{
    public class MaterialImportPurchaseHistory
    {
        public string CompanyID { get; set; }
        public string MaterialCode { get; set; }
        public string IndenterID { get; set; }
        public string IndentorName { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string LCManufacturerID { get; set; }
        public string LCManufacturerName { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
        public string PackingInfo { get; set; }
        public string CountryOfOrigin { get; set; }
        public string ShipMode { get; set; }
        public Nullable<decimal> ReceiveQty { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> FCRate { get; set; }
        public string Currency { get; set; }
        public Nullable<decimal> RTConvRate { get; set; }
    }
}