using System;

namespace WebERPAPI.DTO.Inventory.GRN
{
    public class PurchaseOrderGRNsDto
    {
        public string GRNID { get; set; }

        public Nullable<DateTime> GRNDate { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Source { get; set; }
        public string NoofConRec { get; set; }

        public string ChallanNo { get; set; }
        public Nullable<DateTime> ChallanDate { get; set; }
        public Nullable<Boolean> IsVatChallan { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<DateTime> ApprovedDate { get; set; }

        public string Addedby { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }
    }
}