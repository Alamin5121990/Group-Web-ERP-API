using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.Inventory.GRN
{
    public class GRNReportMasterDto
    {
        public string GRNID { get; set; }

        public Nullable<DateTime> GRNDate { get; set; }
        public string POID { get; set; }
        public string LCID { get; set; }
        public string LCNo { get; set; }
        public Nullable<Boolean> IsVatChallan { get; set; }

        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string RequisitionID { get; set; }
        public string Source { get; set; }
        public string ChallanNo { get; set; }

        public Nullable<DateTime> ChallanDate { get; set; }
        public string ReceiveType { get; set; }
        public string QCPriority { get; set; }
        public string Indication { get; set; }
        public string StorageCondition { get; set; }

        public string Status { get; set; }
        public string LocalBatchNo { get; set; }
        public string NoofConRec { get; set; }
        public string VatChallanNo { get; set; }
        public Nullable<DateTime> VatChallanDate { get; set; }

        public Nullable<decimal> ChallanAmount { get; set; }
        public Nullable<Boolean> IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<DateTime> ApprovedDate { get; set; }
        public string ApproveComment { get; set; }

        public string CustomNo { get; set; }
        public string Location { get; set; }
        public string MachinenameIP { get; set; }
        public Nullable<Boolean> Transfered { get; set; }
        public Nullable<Boolean> HOTransfered { get; set; }

        public string Addedby { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }
        public string Updatedby { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }
        public string StockLocationID { get; set; }
        public string AddedByName { get; set; }

        public string AddedByDesignation { get; set; }
        public string AddedbyDepartment { get; set; }
        public string ApprovedByName { get; set; }
        public string ApprovedByDesignation { get; set; }
        public string ApprovedByDepartment { get; set; }

        public string LabRefID { get; set; }
        public string TestStatus { get; set; }
        public string TestedBy { get; set; }
        public Nullable<DateTime> TestedDate { get; set; }
        public string TestedByName { get; set; }

        public string TestedByDesignation { get; set; }
        public string CheckedBy { get; set; }
        public Nullable<DateTime> CheckedDate { get; set; }
        public string CheckedByName { get; set; }
        public string CheckedByDesignation { get; set; }

        public string TestApprovedBy { get; set; }
        public Nullable<DateTime> TestApprovedDate { get; set; }
        public string TestApprovedByName { get; set; }
        public string TestApprovedByDesignation { get; set; }
        public Nullable<decimal> PassedQty { get; set; }

        public Nullable<decimal> SampleQty { get; set; }
        public Nullable<decimal> RejectedQty { get; set; }
        public Nullable<decimal> MachineTrailQty { get; set; }
        public Nullable<decimal> MicrobiologyQty { get; set; }
        public Nullable<decimal> OthersQty { get; set; }

        public List<GRNReportDetailDto> DetailList = new List<GRNReportDetailDto>();

        public GRNVatDto vat = new GRNVatDto();
    }

    public class GRNReportDetailDto
    {
        public string GRNID { get; set; }

        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> ReceiveQty { get; set; }

        public string BatchNo { get; set; }
        public string UOM { get; set; }
        public Nullable<DateTime> MFGDate { get; set; }
        public Nullable<DateTime> ExpiryDate { get; set; }
        public string PackingInfo { get; set; }
        public string Damage { get; set; }

        public string Remarks { get; set; }
    }

    public class GRNVatDto
    {
        public string GRNID { get; set; }
        public string VatChallanNo { get; set; }
        public System.DateTime VatChallanDate { get; set; }
        public decimal ChallanAmount { get; set; }
    }
}