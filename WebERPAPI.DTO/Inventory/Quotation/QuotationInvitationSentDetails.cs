using System;

namespace WebERPAPI.DTO.Inventory
{
    public class QuotationInvitationSentDetails
    {
        public string QuotationCode { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string RequisitionID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public string UOM { get; set; }
    }
}