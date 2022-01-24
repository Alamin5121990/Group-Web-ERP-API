using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class PurchaseOrderGRNsNPDTO
    {
        public Nullable<int> ID { get; set; }

        public string GRNCode { get; set; }
        public string ChallanNumber { get; set; }
        public Nullable<DateTime> ChallanDate { get; set; }
        public Nullable<int> NumberOfItem { get; set; }
        public string Remarks { get; set; }

        public string VATChallanNumber { get; set; }
        public Nullable<DateTime> VATChallanDate { get; set; }
        public Nullable<Boolean> IsVDSAllowed { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
        public Nullable<int> QRNID { get; set; }

        public Nullable<DateTime> QRNDate { get; set; }

        public string QRNStatus { get; set; }
    }
}