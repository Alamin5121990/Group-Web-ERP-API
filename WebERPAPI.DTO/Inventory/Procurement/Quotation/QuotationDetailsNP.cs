using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO.Inventory.Procurement.Quotation
{
    public class QuotationDetailsNP
    {
        public Nullable<int> ItemID { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public string UOM { get; set; }

        public Nullable<DateTime> DeliveryDate { get; set; }
        public Nullable<int> SubGroupId { get; set; }
        public string SubGroupName { get; set; }
        public string MainGroupName { get; set; }
        public Nullable<int> RequisitionID { get; set; }
        public string RequisitionCode { get; set; }

        public List<ItemSpecification> Specifications { get; set; }

        public List<QuotationSuppliersNP> Suppliers { get; set; }
    }
}