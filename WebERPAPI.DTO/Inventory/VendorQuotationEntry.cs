namespace WebERPAPI.DTO.Inventory
{
    public class VendorQuotationEntry
    {
        public string Token { get; set; }
        public string Remarks { get; set; }

        public string Data { get; set; }
    }

    public class VendorQuotationDetails
    {
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
    }
}