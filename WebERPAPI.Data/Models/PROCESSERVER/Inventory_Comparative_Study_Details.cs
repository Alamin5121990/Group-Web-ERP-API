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
    
    public partial class Inventory_Comparative_Study_Details
    {
        public int ID { get; set; }
        public Nullable<int> CSID { get; set; }
        public Nullable<int> RequisitionID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedByID { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        public virtual Inventory_Comparative_Study Inventory_Comparative_Study { get; set; }
    }
}