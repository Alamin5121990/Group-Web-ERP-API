namespace WebERPAPI.DTO.Inventory
{
    public class SupplierDesignSubmitNew
    {
        public string RequisitionCode { get; set; }
        public string SupplierCode { get; set; }
        public string MaterialCode { get; set; }
        public string Remarks { get; set; }
        public string Message { get; set; }
        public int SendEmail { get; set; }
        public string CreatedByID { get; set; }
    }
}