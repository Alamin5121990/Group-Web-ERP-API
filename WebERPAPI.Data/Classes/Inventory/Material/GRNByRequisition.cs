using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class GRNByRequisition
    {
        public string GRNID { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
        public string LCID { get; set; }
        public string POID { get; set; }

        public string ProjectCD { get; set; }
        public string QCPriority { get; set; }
        public Nullable<DateTime> ApprovedDate { get; set; }
        public string Source { get; set; }
        public string ChallanNo { get; set; }
        public Nullable<DateTime> ChallanDate { get; set; }
        public string LocalBatchNo { get; set; }
    }
}