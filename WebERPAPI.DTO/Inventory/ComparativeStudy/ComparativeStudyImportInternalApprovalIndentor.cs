using System;

namespace WebERPAPI.DTO.Inventory
{
    public class InternalApprovalIndentor
    {
        public string IndentorCode { get; set; }
        public string IndentorName { get; set; }
        public Nullable<int> TotalMaterial { get; set; }
    }
}