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
    
    public partial class Inventory_Requisition_AdvancePaid
    {
        public int ID { get; set; }
        public Nullable<int> RequisitionID { get; set; }
        public Nullable<decimal> AdvanceAmount { get; set; }
        public Nullable<bool> IsUrgent { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}