//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LabaidERP.Data.PROCESS_SERVER_Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quotation_Invitation_Details
    {
        public int ID { get; set; }
        public int QuotationInvitationID { get; set; }
        public string RequisitionID { get; set; }
        public string MaterialCode { get; set; }
    
        public virtual Quotation_Invitations Quotation_Invitations { get; set; }
    }
}
