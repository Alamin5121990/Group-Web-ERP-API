//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebERPAPI.Data.Models.MIS
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesTarget
    {
        public long ID { get; set; }
        public Nullable<int> BrandId { get; set; }
        public Nullable<int> ZoneId { get; set; }
        public Nullable<int> RegionId { get; set; }
        public Nullable<decimal> Average { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    }
}