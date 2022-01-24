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
    
    public partial class Proforma_BlockList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proforma_BlockList()
        {
            this.Proforma_BlockList_Details = new HashSet<Proforma_BlockList_Details>();
        }
    
        public int ID { get; set; }
        public string BlockListCode { get; set; }
        public string ReferenceCode { get; set; }
        public Nullable<System.DateTime> SubmissionDate { get; set; }
        public Nullable<System.DateTime> FinancialYearStart { get; set; }
        public Nullable<System.DateTime> FinancialYearEnd { get; set; }
        public string ProductExecutiveID { get; set; }
        public string CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string ApprovedReferenceNumber { get; set; }
        public Nullable<System.DateTime> ApprovedOn { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string UpdatedByID { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proforma_BlockList_Details> Proforma_BlockList_Details { get; set; }
    }
}
