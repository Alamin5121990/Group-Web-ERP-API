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
    
    public partial class Inventory_Item_MainGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory_Item_MainGroup()
        {
            this.Inventory_Item_SubGroup = new HashSet<Inventory_Item_SubGroup>();
            this.Inventory_MainGroup_Users = new HashSet<Inventory_MainGroup_Users>();
        }
    
        public int ID { get; set; }
        public Nullable<int> InventoryTypeID { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public string ItemCodePrefix { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedByID { get; set; }
        public string UpdatedByID { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        public virtual Inventory_Types Inventory_Types { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory_Item_SubGroup> Inventory_Item_SubGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory_MainGroup_Users> Inventory_MainGroup_Users { get; set; }
    }
}