//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebERPAPI.Data.Models.PROCESSERVER
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventory_Item_Version_Details
    {
        public int ID { get; set; }
        public Nullable<int> VersionID { get; set; }
        public Nullable<int> SpecificationID { get; set; }
        public string SpecificationValue { get; set; }
        public string UOM { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public Nullable<bool> ShowInName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    
        public virtual Inventory_Item_Versions Inventory_Item_Versions { get; set; }
        public virtual Inventory_Item_Specification Inventory_Item_Specification { get; set; }
    }
}
