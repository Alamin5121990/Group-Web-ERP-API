namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class QRNNewDTO
    {
        public int ID { get; set; }
        public int GRNID { get; set; }
        public string CreatedByID { get; set; }
        public string Remarks { get; set; }
        public string Data { get; set; }
        public string VATChallanData { get; set; }
    }

    public class QRNNewItemsDTO
    {
        public int ItemID { get; set; }
        public decimal PassedQuantity { get; set; }
        public decimal RejectedQuantity { get; set; }
    }
}