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
    
    public partial class ProformaInvoice_Invitation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProformaInvoice_Invitation()
        {
            this.ProformaInvoice_Invitation_Details = new HashSet<ProformaInvoice_Invitation_Details>();
        }
    
        public int ID { get; set; }
        public string PICode { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedByID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProformaInvoice_Invitation_Details> ProformaInvoice_Invitation_Details { get; set; }
    }
}
