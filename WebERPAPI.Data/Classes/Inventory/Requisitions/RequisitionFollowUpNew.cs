using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class RequisitionFollowUpNew
    {
        public DateTime EntryDate { get; set; }
        public string MaterialCode { get; set; }
        public string RequisitionCode { get; set; }
        public string POID { get; set; }
        public string EntryBy { get; set; }
        public Nullable<Boolean> IsUrgent { get; set; }
        public Nullable<Boolean> IsClosed { get; set; }

        public string RemarksFromFactory { get; set; }
        public Nullable<DateTime> TentativeAvailableDate { get; set; }
        public string RemarksFromSCM { get; set; }
        public Nullable<DateTime> ActualAvailableDate { get; set; }
        public string ClosedBy { get; set; }
    }

    public class RequisitionFollowUpData
    {
        public string Data { get; set; }
        public string EmployeeName { get; set; }
    }
}