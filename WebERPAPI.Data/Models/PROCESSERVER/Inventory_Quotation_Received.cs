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
    
    public partial class Inventory_Quotation_Received
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory_Quotation_Received()
        {
            this.Inventory_Quotation_Received_Details = new HashSet<Inventory_Quotation_Received_Details>();
        }
    
        public int ID { get; set; }
        public Nullable<bool> IsReceiveComplete { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsCanceled { get; set; }
        public string ReasonToCanceled { get; set; }
        public string CanceledBy { get; set; }
        public Nullable<System.DateTime> CanceledOn { get; set; }
        public string CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedByID { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory_Quotation_Received_Details> Inventory_Quotation_Received_Details { get; set; }
    }
}