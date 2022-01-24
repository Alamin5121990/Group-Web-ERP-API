using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class GRNPendingNP
    {
        public Nullable<int> ID { get; set; }

        public string GRNCode { get; set; }
        public Nullable<int> POID { get; set; }
        public string POCode { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }

        public string ChallanNumber { get; set; }
        public Nullable<DateTime> ChallanDate { get; set; }
        public Nullable<int> NumberOfItem { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}