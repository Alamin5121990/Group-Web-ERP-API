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
    
    public partial class Stockbatch
    {
        public string GRNID { get; set; }
        public string MaterialCode { get; set; }
        public string LabRefID { get; set; }
        public Nullable<decimal> QuarantineQty { get; set; }
        public Nullable<decimal> ReceiveQty { get; set; }
        public Nullable<decimal> IssueQty { get; set; }
        public Nullable<decimal> UsedQty { get; set; }
        public Nullable<decimal> RejectQty { get; set; }
        public Nullable<System.DateTime> MFGDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string Location { get; set; }
        public string MachinenameIP { get; set; }
        public bool Transfered { get; set; }
        public bool HOTransfered { get; set; }
        public string Addedby { get; set; }
        public System.DateTime DateAdded { get; set; }
        public string Updatedby { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }
}
