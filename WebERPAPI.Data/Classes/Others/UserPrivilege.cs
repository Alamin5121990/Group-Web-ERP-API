using System;

namespace LabaidMIS.Data.Classes
{
    public class UserPrivilege
    {
        public int ApplicationID { get; set; }
        public int PrivilegeID { get; set; }
        public int UserID { get; set; }
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public Nullable<Boolean> IsParentMenu { get; set; }
        public Nullable<Boolean> HasInsert { get; set; }
        public Nullable<Boolean> HasUpdate { get; set; }
        public Nullable<Boolean> HasDelete { get; set; }
        public Nullable<Boolean> HasPrint { get; set; }
        public Nullable<Boolean> HasFullAccess { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

        public Nullable<int> TotalRequest { get; set; }
    }
}