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
    
    public partial class Inventory_Requisition_Item_Specifications
    {
        public int ID { get; set; }
        public Nullable<int> RequisitionID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public string SpecificationValue { get; set; }
        public string SpecificationName { get; set; }
        public string UOM { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedByID { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string UpdatedByID { get; set; }
        public Nullable<int> RequisitionItemID { get; set; }
    }
}
