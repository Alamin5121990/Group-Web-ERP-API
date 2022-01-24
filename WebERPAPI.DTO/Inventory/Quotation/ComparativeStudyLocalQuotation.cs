using System;

namespace WebERPAPI.DTO.Inventory.Quotation
{
    public class ComparativeStudyLocalQuotation
    {
        public Nullable<int> ID { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }
        public string UOM { get; set; }
        public string RequisitionCode { get; set; }
        public Nullable<decimal> InvitedQuantity { get; set; }
        public Nullable<decimal> OfferedQuantity { get; set; }
        public Nullable<decimal> OfferedRate { get; set; }
        public Nullable<decimal> NegotiatePrice { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
        public string Remarks { get; set; }
        public Boolean IsSelected { get; set; }
        public Boolean IsLowestBidder { get; set; }
    }
}