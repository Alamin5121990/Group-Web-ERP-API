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
    
    public partial class User_Complain_Attachments
    {
        public int ID { get; set; }
        public Nullable<int> ComplainID { get; set; }
        public string ImageFileName { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    
        public virtual User_Complains User_Complains { get; set; }
    }
}
