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
    
    public partial class BillMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BillMaster()
        {
            this.BillDetails = new HashSet<BillDetail>();
            this.BillDists = new HashSet<BillDist>();
        }
    
        public string BillID { get; set; }
        public System.DateTime BillDate { get; set; }
        public string SubmittedBy { get; set; }
        public string BillGroup { get; set; }
        public string SupplierID { get; set; }
        public string SupplierBillNo { get; set; }
        public Nullable<System.DateTime> SBillDate { get; set; }
        public string BillDescription { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsForwarded { get; set; }
        public string ForwardByID { get; set; }
        public string ForwardRemarks { get; set; }
        public Nullable<System.DateTime> ForwardOn { get; set; }
        public bool AccountsReceived { get; set; }
        public Nullable<System.DateTime> AccountsReceiveDate { get; set; }
        public string AccountsReceiveBy { get; set; }
        public string AccountsRemarks { get; set; }
        public Nullable<bool> IsBillSettled { get; set; }
        public Nullable<System.DateTime> BillSettledOn { get; set; }
        public string BillSettleRemarks { get; set; }
        public string BillSettledBy { get; set; }
        public string BillCorrectionRemarks { get; set; }
        public decimal CarryingCharge { get; set; }
        public decimal LoadingCharge { get; set; }
        public decimal OtherCharge { get; set; }
        public decimal AdvancePaid { get; set; }
        public bool Transferred { get; set; }
        public bool HOTransferred { get; set; }
        public string Location { get; set; }
        public string MachineNameIP { get; set; }
        public string AddedBy { get; set; }
        public System.DateTime DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public Nullable<int> BillGroupID { get; set; }
        public Nullable<bool> IsCanceled { get; set; }
        public Nullable<System.DateTime> CanceledOn { get; set; }
        public Nullable<int> CanceledByID { get; set; }
        public string ReasonToCancel { get; set; }
        public decimal Discount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDist> BillDists { get; set; }
    }
}
