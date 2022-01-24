using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class GRNVATChallansNPDTO
    {
        public Nullable<int> ItemID { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ChallanNumber { get; set; }
        public Nullable<DateTime> ChallanDate { get; set; }
        public Nullable<Boolean> IsVDSAllowed { get; set; }

        public string CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
    }
}