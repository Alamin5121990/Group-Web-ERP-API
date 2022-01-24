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
    
    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            this.POReqDetails = new HashSet<POReqDetail>();
            this.PODetails = new HashSet<PODetail>();
        }
    
        public int ID { get; set; }
        public string CompanyID { get; set; }
        public string MaterialCode { get; set; }
        public string ProductType { get; set; }
        public string ProductCategory { get; set; }
        public string MaterialName { get; set; }
        public string MaterialGrade { get; set; }
        public string InventoryLocation { get; set; }
        public string Source { get; set; }
        public decimal MSL { get; set; }
        public decimal MOQ { get; set; }
        public string UOM { get; set; }
        public string PharmaRef { get; set; }
        public Nullable<int> VendorLeadTime { get; set; }
        public Nullable<int> BlockListLeadTime { get; set; }
        public Nullable<int> SCLeadTime { get; set; }
        public Nullable<int> QCLeadTime { get; set; }
        public Nullable<int> ReTestLeadTime { get; set; }
        public string ShortSpec { get; set; }
        public string DefaultModeofShip { get; set; }
        public string RequisitionUOM { get; set; }
        public Nullable<decimal> RUOMConvFac { get; set; }
        public string Location { get; set; }
        public string MachinenameIP { get; set; }
        public Nullable<bool> Transfered { get; set; }
        public Nullable<bool> HOTransfered { get; set; }
        public string Addedby { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string Updatedby { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POReqDetail> POReqDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PODetail> PODetails { get; set; }
    }
}
