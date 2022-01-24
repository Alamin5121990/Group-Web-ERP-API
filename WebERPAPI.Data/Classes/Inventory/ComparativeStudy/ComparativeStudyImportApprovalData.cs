namespace LabaidMIS.Data.Classes.Inventory
{
    public class ComparativeStudyImportApprovalData
    {
        public string EmployeeID { get; set; }
        public string Data { get; set; }
    }

    public class ComparativeStudyImportApprovalDetails
    {
        public int CSID { get; set; }
        public string MaterialCode { get; set; }
        public string RequisitionCode { get; set; }
        public string Remarks { get; set; }
    }
}