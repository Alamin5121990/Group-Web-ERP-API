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
    
    public partial class ProductWiseYearlyComparison
    {
        public int BrandId { get; set; }
        public int ProductID { get; set; }
        public int ReportColumnTypeId { get; set; }
        public byte ReportDurationTypeId { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<byte> MonthNo { get; set; }
        public Nullable<int> DayNo { get; set; }
        public Nullable<System.DateTime> ReportDate { get; set; }
        public decimal ColumnValue { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> CreatedById { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    }
}