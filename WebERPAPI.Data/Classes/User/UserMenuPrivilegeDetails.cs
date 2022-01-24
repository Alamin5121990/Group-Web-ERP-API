using System;

namespace LabaidMIS.Data.Classes.User
{
    public class UserMenuPrivilegeDetails
    {
        public Nullable<Boolean> HasView { get; set; }

        public Nullable<Boolean> HasInsert { get; set; }
        public Nullable<Boolean> HasUpdate { get; set; }
        public Nullable<Boolean> HasDelete { get; set; }
        public Nullable<Boolean> HasPrint { get; set; }
        public Nullable<Boolean> HasFullAccess { get; set; }
    }
}