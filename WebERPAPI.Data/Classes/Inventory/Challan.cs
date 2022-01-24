using System;

namespace LabaidMIS.Data.Classes.Challan
{
    public class Challan
    {
        public string ChallanID { get; set; }
        public Nullable<System.DateTime> ChallanDate { get; set; }
        public string IssueFrom { get; set; }
        public string IssueTo { get; set; }
        public string IssueType { get; set; }
        public string IssueCause { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string LocationID { get; set; }
        public int isNew { get; set; }
    }

    public class ChallanApproved
    {
        public string ChallanID { get; set; }
        public Nullable<System.DateTime> ChallanDate { get; set; }
        public string IssueFrom { get; set; }
        public string IssueTo { get; set; }
        public string IssueType { get; set; }
        public string IssueCause { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> ApprovedOn { get; set; }
        public string ApprovalRemarks { get; set; }

        public string Reason { get; set; }
        public Nullable<DateTime> RequestedOn { get; set; }
    }

    public class ChallanIssueDetails
    {
        public string ID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string BatchID { get; set; }
        public string BatchNo { get; set; }
        public string PackSize { get; set; }
        public string NoofOuter { get; set; }
        public Nullable<decimal> IssueQty { get; set; }
    }

    public class ChallanApprove
    {
        public string issueid { get; set; }
        public string remarks { get; set; }
        public string userid { get; set; }
        public string LocationID { get; set; }
    }
}