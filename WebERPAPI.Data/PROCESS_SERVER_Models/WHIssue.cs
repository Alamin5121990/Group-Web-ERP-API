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
    
    public partial class WHIssue
    {
        public string ChallanID { get; set; }
        public System.DateTime ChallanDate { get; set; }
        public string IssueTo { get; set; }
        public string IssueFrom { get; set; }
        public string IssueType { get; set; }
        public string IssueCause { get; set; }
        public string Remarks { get; set; }
        public string VehicleNo { get; set; }
        public string VatChallanNo { get; set; }
        public string AllocationID { get; set; }
        public bool IsLocked { get; set; }
        public string Location { get; set; }
        public string MachinenameIP { get; set; }
        public bool Transfered { get; set; }
        public bool HOTransfered { get; set; }
        public string Addedby { get; set; }
        public System.DateTime DateAdded { get; set; }
        public string Updatedby { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<int> ApprovedById { get; set; }
        public Nullable<System.DateTime> ApprovedOn { get; set; }
        public string ApprovalRemarks { get; set; }
    }
}