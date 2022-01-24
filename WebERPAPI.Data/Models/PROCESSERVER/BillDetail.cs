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
    
    public partial class BillDetail
    {
        public string BillID { get; set; }
        public string ChallanID { get; set; }
        public int SLNo { get; set; }
        public string POID { get; set; }
        public string GRNID { get; set; }
        public string ItemID { get; set; }
        public decimal BillQty { get; set; }
        public decimal Rate { get; set; }
        public decimal BillAmount { get; set; }
        public decimal VatAmt { get; set; }
        public decimal AITAmt { get; set; }
        public string BillRemarks { get; set; }
        public string AddedBy { get; set; }
        public System.DateTime DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    
        public virtual BillMaster BillMaster { get; set; }
    }
}
