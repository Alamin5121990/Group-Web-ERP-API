using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.Inventory.GRN
{
    public class ProductionGRNListDto
    {
        public string GRNID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeID { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
        public string ReceiveType { get; set; }
        public string SupplierID { get; set; }
        public string POID { get; set; }
        public string LCID { get; set; }

        public string ProjectCD { get; set; }
        public string IssueID { get; set; }
        public string QCPriority { get; set; }
        public Nullable<Boolean> IsApproved { get; set; }
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
        public string CustomNo { get; set; }

        public string LocalBatchNo { get; set; }
        public string BatchID { get; set; }
        public Nullable<Boolean> IsVatChallan { get; set; }
        public string Location { get; set; }
        public string MachinenameIP { get; set; }

        public Nullable<Boolean> Transfered { get; set; }
        public Nullable<Boolean> HOTransfered { get; set; }
        public string Addedby { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }
        public string Updatedby { get; set; }

        public Nullable<DateTime> DateUpdated { get; set; }
        public string SupplierName { get; set; }
        public string MaterialName { get; set; }
    }
}