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
    
    public partial class SalesAverage_Daily
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<decimal> SalesAverage { get; set; }
        public Nullable<decimal> TotalSalesUpto { get; set; }
        public Nullable<decimal> ExpectedMonthEndTotalSales { get; set; }
    }
}
