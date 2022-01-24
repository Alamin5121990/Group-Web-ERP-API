using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class ChallanApprovalRequestList
    {
        public string ChallanID { get; set; }
        public Nullable<DateTime> IssueDate { get; set; }
        public string IssueFrom { get; set; }
        public string IssueTo { get; set; }
        public string IssueType { get; set; }
        public string RequisitionFor { get; set; }
        public string Remarks { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }
        public string RequestedBy { get; set; }
        public string Reason { get; set; }
        public string LocationID { get; set; }
        public Nullable<DateTime> RequestedOn { get; set; }
    }

    public class ChallanApprovalRequest
    {
        public string ChallanID { get; set; }
        public string Reason { get; set; }
        public string EmployeeID { get; set; }
    }
}