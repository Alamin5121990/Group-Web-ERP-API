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
    
    public partial class Comparative_Study_Details
    {
        public int ID { get; set; }
        public Nullable<int> CSID { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> IsAccountsApproved { get; set; }
        public Nullable<bool> IsRecommended { get; set; }
        public Nullable<bool> IsManagementApproved { get; set; }
        public Nullable<bool> IsReviewed { get; set; }
        public Nullable<bool> IsAuditDone { get; set; }
        public string AuditById { get; set; }
        public Nullable<System.DateTime> AuditOn { get; set; }
        public string AuditRemarks { get; set; }
        public string ReviewRemarks { get; set; }
        public Nullable<System.DateTime> ReviewedOn { get; set; }
        public string ReviewedByID { get; set; }
        public Nullable<System.DateTime> AccountsApprovedOn { get; set; }
        public string AccountsApprovalRemarks { get; set; }
        public string AccountsApprovedByID { get; set; }
        public Nullable<System.DateTime> RecommendedOn { get; set; }
        public string RecommendationRemarks { get; set; }
        public string RecommendedByID { get; set; }
        public Nullable<System.DateTime> ManagementApprovedOn { get; set; }
        public string ManagementApprovedById { get; set; }
        public string ManagementApprovalRemarks { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Comparative_Study Comparative_Study { get; set; }
    }
}
