using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO.Inventory
{
    public class PurchaseOrderGRNDetailsReport
    {
        public string GRNID { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
        public string ReceiveType { get; set; }
        public string SupplierID { get; set; }
        public string POID { get; set; }
        public string LCID { get; set; }
        public string ProjectCD { get; set; }
        public string IssueID { get; set; }
        public string QCPriority { get; set; }
        public Boolean IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<DateTime> ApprovedDate { get; set; }
        public string ApproveComment { get; set; }
        public string Source { get; set; }
        public string StorageCondition { get; set; }
        public string Indication { get; set; }
        public string NoofConRec { get; set; }
        public string Status { get; set; }
        public string ChallanNo { get; set; }
        public Nullable<DateTime> ChallanDate { get; set; }

        public List<PurchaseOrdersGRNDetails> GRNDetails { get; set; }
    }
}