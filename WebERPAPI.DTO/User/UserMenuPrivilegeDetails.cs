using System;

namespace WebERPAPI.DTO.User
{
    public class UserMenuPrivilegeDetails
    {
        public Nullable<Boolean> HasView { get; set; }

        public Nullable<Boolean> HasInsert { get; set; }
        public Nullable<Boolean> HasUpdate { get; set; }
        public Nullable<Boolean> HasDelete { get; set; }
        public Nullable<Boolean> HasPrint { get; set; }
        public Nullable<Boolean> HasCheck { get; set; }
        public Nullable<Boolean> HasReview { get; set; }
        public Nullable<Boolean> HasAudit { get; set; }
        public Nullable<Boolean> HasVerify { get; set; }
        public Nullable<Boolean> HasRecommendation { get; set; }
        public Nullable<Boolean> HasApprove { get; set; }
        public Nullable<Boolean> HasFullAccess { get; set; }
    }
}