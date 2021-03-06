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
    
    public partial class LCDetail
    {
        public string LCID { get; set; }
        public string ProjectCD { get; set; }
        public string RequisitionID { get; set; }
        public string CSID { get; set; }
        public string BlockListRefNo { get; set; }
        public string MaterialCode { get; set; }
        public string UOM { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal TotalValue { get; set; }
        public string CountryOfOrigin { get; set; }
        public string ManufacturerID { get; set; }
        public string ShipMode { get; set; }
        public Nullable<System.DateTime> ShipmentDate { get; set; }
        public Nullable<System.DateTime> ArrivalDate { get; set; }
        public decimal RTConvRate { get; set; }
    
        public virtual LC LC { get; set; }
    }
}
