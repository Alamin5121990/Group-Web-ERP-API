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
    
    public partial class Inventory_Requisition_For_Months
    {
        public int ID { get; set; }
        public Nullable<int> RequisitionID { get; set; }
        public Nullable<System.DateTime> ForDate { get; set; }
    
        public virtual Inventory_Requisitions Inventory_Requisitions { get; set; }
    }
}
