using System;

namespace WebERPAPI.DTO.Inventory.Procurement.Quotation
{
    public class QuotationSuppliersNP
    {
        public Boolean IsSelected { get; set; }
        public Nullable<int> ID { get; set; }

        public Nullable<int> QuotationID { get; set; }
        public Nullable<int> RequisitionID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }

        public Nullable<decimal> InvitedQuantity { get; set; }

        public Nullable<decimal> Quantity { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string SupplierName { get; set; }

        public Nullable<decimal> Rate { get; set; }
        public Nullable<int> BillPaymentTypeID { get; set; }
        public Nullable<int> CreditDays { get; set; }

        public string VendorRemarks { get; set; }

        public Boolean IsLowestBidder { get; set; }

        public Nullable<decimal> AllItemTotalPrice { get; set; }

        public Nullable<decimal> CarryingCost { get; set; }
        public Nullable<decimal> LabourCost { get; set; }
        public string OtherCostName { get; set; }
        public Nullable<decimal> OtherCost { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<int> RequisitionItemID { get; set; }
        public Nullable<int> CurrencyID { get; set; }
        public Nullable<int> BillCurrencyTypeID { get; set; }
        public string Currency { get; set; }
        public string SupplierSpecification { get; set; }

        public string RemarksForSupplierSpec { get; set; }

        public Nullable<Boolean> IsSpecificationMatched { get; set; }


    }
}