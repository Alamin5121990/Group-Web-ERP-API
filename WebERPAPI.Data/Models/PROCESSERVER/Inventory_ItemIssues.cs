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
    
    public partial class Inventory_ItemIssues
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory_ItemIssues()
        {
            this.Inventory_ItemIssue_Details = new HashSet<Inventory_ItemIssue_Details>();
        }
    
        public int ID { get; set; }
        public string IssueCode { get; set; }
        public int StoreID { get; set; }
        public int MainGroupID { get; set; }
        public string IssueToID { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> CanceledOn { get; set; }
        public Nullable<bool> IsCanceled { get; set; }
        public string CanceledByID { get; set; }
        public string ReasonToCancel { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedByID { get; set; }
        public string UpdatedByID { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory_ItemIssue_Details> Inventory_ItemIssue_Details { get; set; }
    }
}
