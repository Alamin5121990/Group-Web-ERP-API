using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class ItemStockOpeningNewDto
    {
        public int StoreID { get; set; }
        public int ItemID { get; set; }
        public string PurchaseDate { get; set; }
        public string ExpiryDate { get; set; }
        public string SupplierCode { get; set; }
        public decimal Quantity { get; set; }
        public string SerialNumber { get; set; }
        public string RequisitionNo { get; set; }
        public string WarrentyPeriod { get; set; }
        public string Remarks { get; set; }
    }
}