namespace WebERPAPI.DTO.Inventory.PurchaseOrdersNP
{
    public class PurchaseOrderDetailsNew
    {
        public int RequisitionID { get; set; }
        public int ItemID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal VATPercent { get; set; }
        public decimal VATAmount { get; set; }
        public int OrderNo { get; set; }
    }
}