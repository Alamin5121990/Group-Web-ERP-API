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
    
    public partial class ProductProcess
    {
        public string BatchCategory { get; set; }
        public string ProductID { get; set; }
        public string ProcessID { get; set; }
        public int SLNo { get; set; }
        public Nullable<decimal> StartBatchTime { get; set; }
        public Nullable<decimal> ContinuousBatchTime { get; set; }
        public string TimeUOM { get; set; }
        public Nullable<decimal> StartBatchIPQC { get; set; }
        public Nullable<decimal> ContinuousBatchIPQC { get; set; }
    }
}