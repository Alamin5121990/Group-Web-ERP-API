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
    
    public partial class BankOfSupplier
    {
        public int ID { get; set; }
        public string ShortName { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedByID { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string UpdatedByID { get; set; }
    }
}