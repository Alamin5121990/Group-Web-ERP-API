using System;

namespace LabaidMIS.Data.Classes
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