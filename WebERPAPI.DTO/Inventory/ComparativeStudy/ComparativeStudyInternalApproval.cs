using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO.Inventory
{
    public class ComparativeStudyInternalApproval
    {
        public Nullable<int> ID { get; set; }
        public string InternalApprovalCode { get; set; }
        public Nullable<DateTime> ReportDate { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }

        public List<InternalApprovalCSList> CSList { get; set; }
    }
}