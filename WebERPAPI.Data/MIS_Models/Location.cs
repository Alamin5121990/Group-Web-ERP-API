//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LabaidERP.Data.MIS_Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Location
    {
        public int ID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public Nullable<int> LocationTypeId { get; set; }
        public string Address { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
