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
    
    public partial class Quotation_Received_Details
    {
        public int ID { get; set; }
        public Nullable<int> QuotationInvitationID { get; set; }
        public Nullable<int> QuotationReceiveID { get; set; }
        public string RequisitionCode { get; set; }
        public string SupplierCode { get; set; }
        public string MaterialCode { get; set; }
        public Nullable<decimal> ReceivedQuantity { get; set; }
        public Nullable<decimal> ReceivedPrice { get; set; }
        public string VendorRemarks { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string ManufacturerCode { get; set; }
        public Nullable<decimal> NegotiatePrice { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Quotation_Received Quotation_Received { get; set; }
    }
}