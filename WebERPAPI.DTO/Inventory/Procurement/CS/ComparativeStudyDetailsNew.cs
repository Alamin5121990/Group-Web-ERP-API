using System;

namespace WebERPAPI.DTO.Inventory.Procurement.CS
{
    public class ComparativeStudyDetailsNew
    {
        public int ID { get; set; }
        public Boolean IsSelected { get; set; }
        public Nullable<int> CSID { get; set; }
        public Nullable<int> QuotationID { get; set; }
        public int RequisitionID { get; set; }
        public int ItemID { get; set; }
        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }

        public Nullable<int> CreditDays { get; set; }
        public Nullable<int> BillPaymentTypeID { get; set; }

        public string CreatedByID { get; set; }

        public string VendorRemarks { get; set; }
        public Nullable<int> BillCurrencyTypeID { get; set; }

    }
}