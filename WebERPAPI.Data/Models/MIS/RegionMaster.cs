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
    
    public partial class RegionMaster
    {
        public int ID { get; set; }
        public string RegionCode { get; set; }
        public Nullable<int> OAID { get; set; }
        public Nullable<int> ZoneID { get; set; }
        public string ZoneCode { get; set; }
        public string RegionName { get; set; }
        public string EmployeeID { get; set; }
        public decimal STPercent { get; set; }
        public decimal STValue { get; set; }
        public decimal Budget { get; set; }
        public string SampleCategory { get; set; }
        public bool IsInActive { get; set; }
        public string Location { get; set; }
        public string MachineNameIP { get; set; }
        public bool Transfered { get; set; }
        public bool HOTransfered { get; set; }
        public string Addedby { get; set; }
        public System.DateTime DateAdded { get; set; }
        public string Updatedby { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }
}
