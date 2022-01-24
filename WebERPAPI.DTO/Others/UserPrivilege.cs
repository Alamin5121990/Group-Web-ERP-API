using System;

namespace WebERPAPI.DTO
{
    public class UserPrivilege
    {
        public Nullable<int> ApplicationID { get; set; }
        public Nullable<int> PrivilegeID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> MenuID { get; set; }
        public string MenuName { get; set; }
        public Nullable<Boolean> IsParentMenu { get; set; }
        public Nullable<Boolean> HasInsert { get; set; }
        public Nullable<Boolean> HasUpdate { get; set; }
        public Nullable<Boolean> HasDelete { get; set; }
        public Nullable<Boolean> HasPrint { get; set; }
        public Nullable<Boolean> HasView { get; set; }
        public Nullable<Boolean> HasFullAccess { get; set; }
        public Nullable<Boolean> HasReview { get; set; }
        public Nullable<Boolean> HasVerify { get; set; }
        public Nullable<Boolean> HasRecommendation { get; set; }
        public Nullable<Boolean> HasAudit { get; set; }
        public Nullable<Boolean> HasApprove { get; set; }

        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

        public Nullable<int> TotalRequest { get; set; }
    }
}