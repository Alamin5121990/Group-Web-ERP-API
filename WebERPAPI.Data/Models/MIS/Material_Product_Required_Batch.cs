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
    
    public partial class Material_Product_Required_Batch
    {
        public int ID { get; set; }
        public string MaterialCode { get; set; }
        public string ProductCode { get; set; }
        public Nullable<decimal> StandardQuantity { get; set; }
        public Nullable<int> BatchSize { get; set; }
        public Nullable<int> ForecastRequired { get; set; }
        public Nullable<int> StockQuantity { get; set; }
        public Nullable<int> BatchOutputInProgress { get; set; }
        public Nullable<int> BatchOutputInRelease { get; set; }
        public Nullable<int> TotalBatchRequired { get; set; }
        public Nullable<decimal> BatchRequiredQuantity { get; set; }
        public Nullable<decimal> IssueQuantity { get; set; }
    }
}