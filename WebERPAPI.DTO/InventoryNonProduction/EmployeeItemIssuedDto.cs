using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class EmployeeItemIssuedDto : BaseEntityDTO
    {
        public string IssueCode { get; set; }
        public string IssueToID { get; set; }
        public Nullable<int> MainGroupID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string MainGroupName { get; set; }

        public string IssuedFrom { get; set; }
        public string Remarks { get; set; }

        public Nullable<Boolean> IsCanceled { get; set; }
        public string CanceledBy { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
        public string ReasonToCancel { get; set; }
    }
}