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
    
    public partial class Validation_Logs
    {
        public int ID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public string LocationLevel { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> BrandID { get; set; }
        public string ResultStatus { get; set; }
        public string Message { get; set; }
        public string ProcedureName { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<System.DateTime> ReportDate { get; set; }
    }
}
