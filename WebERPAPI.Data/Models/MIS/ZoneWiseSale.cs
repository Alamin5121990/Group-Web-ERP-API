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
    
    public partial class ZoneWiseSale
    {
        public long ID { get; set; }
        public Nullable<int> BrandId { get; set; }
        public Nullable<int> ZoneId { get; set; }
        public Nullable<int> RegionId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<int> SoldQuantity { get; set; }
        public Nullable<decimal> SoldValue { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> AreaId { get; set; }
        public Nullable<int> TerritoryID { get; set; }
    }
}
