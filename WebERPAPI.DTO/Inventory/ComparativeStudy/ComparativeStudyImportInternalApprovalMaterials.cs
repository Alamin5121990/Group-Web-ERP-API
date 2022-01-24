using System;

namespace WebERPAPI.DTO.Inventory
{
    public class InternalApprovalImportMaterials
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> CSID { get; set; }
        public string InternalApprovalCode { get; set; }
        public Nullable<DateTime> ReportDate { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }

        public string UOM { get; set; }
        public string ModeOfShipment { get; set; }

        public string IndentorCode { get; set; }
        public string IndentorName { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        public string MaterialGrade { get; set; }

        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string Remarks { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public string CSCode { get; set; }

        public string DeliveryMode { get; set; }
        public string CurrencyName { get; set; }
    }
}