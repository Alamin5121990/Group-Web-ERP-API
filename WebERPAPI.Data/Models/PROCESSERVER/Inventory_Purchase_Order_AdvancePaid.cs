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
    
    public partial class Inventory_Purchase_Order_AdvancePaid
    {
        public int ID { get; set; }
        public string SupplierCode { get; set; }
        public string POID { get; set; }
        public Nullable<decimal> AdvancePercent { get; set; }
        public Nullable<decimal> AdvanceAmount { get; set; }
        public Nullable<bool> IsUrgent { get; set; }
        public Nullable<bool> IsReceivedFromAccounts { get; set; }
        public string Remarks { get; set; }
        public string CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ApprovedOn { get; set; }
        public string ApprovedById { get; set; }
        public string ApprovalRemarks { get; set; }
        public string RollBackById { get; set; }
        public Nullable<System.DateTime> RollBackOn { get; set; }
        public string RollBackRemarks { get; set; }
        public string UpdatedByID { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> IsCanceled { get; set; }
        public string CancelRemarks { get; set; }
    }
}