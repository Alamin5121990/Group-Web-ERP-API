namespace WebERPAPI.DTO.Inventory.Procurement.Quotation
{
    public class QuotationInvitationSendDetails
    {
        public int RequisitionID { get; set; }
        public int ItemID { get; set; }
        public int OrderNo { get; set; }
        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }

        public decimal Quantity { get; set; }
    }
}