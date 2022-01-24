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
    
    public partial class tblUser
    {
        public int UserId { get; set; }
        public string UserCode { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool IsLoggedIn { get; set; }
        public Nullable<System.DateTime> LogonTime { get; set; }
        public string EmployeeCode { get; set; }
        public Nullable<int> UserTypeId { get; set; }
        public Nullable<bool> IsInternal { get; set; }
        public string DefaultLocation { get; set; }
        public byte[] Signature { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime DateAdded { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public bool IsWebAppAllowed { get; set; }
        public string EmailPassword { get; set; }
    }
}