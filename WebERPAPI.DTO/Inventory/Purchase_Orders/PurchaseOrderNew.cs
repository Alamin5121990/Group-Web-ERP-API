using System;

namespace WebERPAPI.DTO.Inventory
{
    public class PurchaseOrderNew
    {
        public string Subject { get; set; }
        public string SupplierCode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ModeOfPayment { get; set; }
        public string TermsConditions { get; set; }
        public string CountryofOrigin { get; set; }
        public decimal VATPercent { get; set; }
        public decimal DiscountPercent { get; set; }
        public string CreatedBy { get; set; }
        public string Data { get; set; }
    }

    public class PurchaseOrderNewDetails
    {
        public string InternalApprovalCode { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string UOM { get; set; }
        public string VersionNo { get; set; }
    }
}