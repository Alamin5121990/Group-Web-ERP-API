//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LabaidERP.Data.PROCESS_SERVER_Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class v_WebApplicationMenus
    {
        public Nullable<int> ApplicationId { get; set; }
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public Nullable<int> ParentMenuId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public string Route { get; set; }
        public string Createdby { get; set; }
        public Nullable<bool> IsNonPrivilegedMenu { get; set; }
    }
}
