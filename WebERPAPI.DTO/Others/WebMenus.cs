using System;

namespace WebERPAPI.DTO
{
    public class WebMenu
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public Nullable<int> ParentMenuId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Boolean IsNonPrivilegedMenu { get; set; }
        public string Route { get; set; }
        public string CreatedBy { get; set; }
    }

    public class WebMenuDto
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public Nullable<int> ParentMenuId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Boolean IsNonPrivilegedMenu { get; set; }
        public string Route { get; set; }
        public string CreatedBy { get; set; }

        public Nullable<bool> HasView { get; set; }
        public Nullable<bool> HasInsert { get; set; }
        public Nullable<bool> HasUpdate { get; set; }
        public Nullable<bool> HasDelete { get; set; }
        public Nullable<bool> HasPrint { get; set; }
        public Nullable<bool> HasReview { get; set; }
        public Nullable<bool> HasVerify { get; set; }
        public Nullable<bool> HasRecommendation { get; set; }
        public Nullable<bool> HasApprove { get; set; }
        public Nullable<bool> HasFullAccess { get; set; }
        public Nullable<int> GroupID { get; set; }
    }

    public class WebMenuAndRequest
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public Nullable<int> ParentMenuId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Boolean IsNonPrivilegedMenu { get; set; }
        public string Route { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> TotalRequest { get; set; }
    }
}