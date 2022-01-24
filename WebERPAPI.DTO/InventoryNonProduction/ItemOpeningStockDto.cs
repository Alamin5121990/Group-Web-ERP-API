using System;
using System.Collections.Generic;
using WebERPAPI.DTO.Inventory.Procurement;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class ItemOpeningStockDto
    {
        public Nullable<int> ID { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> OpeningStockQuantity { get; set; }

        public Nullable<DateTime> PurchaseDate { get; set; }
        public Nullable<DateTime> ExpiryDate { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public List<InventoryItemSpecifications> Specifications = new List<InventoryItemSpecifications>();
    }
}