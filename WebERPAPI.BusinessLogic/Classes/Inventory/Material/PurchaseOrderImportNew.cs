using System;

namespace LabaidMIS.BL.Classes.Inventory.Material
{
    public class PurchaseOrderImportNew
    {
        public string Subject { get; set; }
        public string IndentorCode { get; set; }
        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ModeOfPayment { get; set; }
        public string TermsConditions { get; set; }
        public string CountryofOrigin { get; set; }
        public decimal VATPercent { get; set; }
        public decimal DiscountPercent { get; set; }
        public string CreatedBy { get; set; }
        public string Data { get; set; }
    }


    public class PurchaseOrderImportNewDetails
    {
        public string InternalApprovalCode { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public string UOM { get; set; }
        public string MaterialGrade { get; set; }

    }
}
