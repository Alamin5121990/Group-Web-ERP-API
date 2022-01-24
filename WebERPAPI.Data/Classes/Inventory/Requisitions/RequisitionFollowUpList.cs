using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class RequisitionFollowUpList
    {
        public Nullable<DateTime> EntryDate { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<DateTime> RequisitionDate { get; set; }
        public string POID { get; set; }
        public string VersionNo { get; set; }
        public string Source { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public Nullable<Boolean> IsUrgent { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string CreatedBy { get; set; }
        public string PurchaseStatus { get; set; }
        public string RemarksFromFactory { get; set; }
        public Nullable<DateTime> TentativeAvailableDate { get; set; }
        public string RemarksFromSCM { get; set; }
        public Nullable<DateTime> ActualAvailableDate { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public string ClosedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
        public string Updatedby { get; set; }
    }
}