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
    
    public partial class BankInfo
    {
        public string BankID { get; set; }
        public string BankName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string MachineNameIP { get; set; }
        public bool Transfered { get; set; }
        public bool HOTransfered { get; set; }
        public string Addedby { get; set; }
        public System.DateTime DateAdded { get; set; }
        public string Updatedby { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
