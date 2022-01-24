using System;

namespace WebERPAPI.DTO.Inventory
{
    public class GRNDetailsByLC
    {
        public string LCID { get; set; }

        public string RequisitionCode { get; set; }
        public string GRNID { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
        public string ProjectCD { get; set; }
        public string SupplierID { get; set; }

        public string SupplierName { get; set; }
        public string ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }

        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> ReceiveQuantity { get; set; }
        public string BatchNo { get; set; }
        public Nullable<DateTime> MFGDate { get; set; }
        public Nullable<DateTime> ExpiryDate { get; set; }

        public string PackingInfo { get; set; }
        public string Damage { get; set; }
        public string Remarks { get; set; }
    }
}