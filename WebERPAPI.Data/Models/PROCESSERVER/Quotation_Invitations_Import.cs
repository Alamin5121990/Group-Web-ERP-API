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
    
    public partial class Quotation_Invitations_Import
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quotation_Invitations_Import()
        {
            this.Quotation_Invitation_Import_Details = new HashSet<Quotation_Invitation_Import_Details>();
        }
    
        public int ID { get; set; }
        public string QuotationCode { get; set; }
        public string TermAndCondition { get; set; }
        public string MandatoryCheckList { get; set; }
        public string SentByID { get; set; }
        public Nullable<bool> IsCanceled { get; set; }
        public string ReasonToCanceled { get; set; }
        public string CanceledBy { get; set; }
        public Nullable<System.DateTime> CanceledOn { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string Remarks { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quotation_Invitation_Import_Details> Quotation_Invitation_Import_Details { get; set; }
    }
}
