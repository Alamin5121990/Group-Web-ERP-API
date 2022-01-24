using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class ProductBatchCreationDetails
    {
        public string BatchID { get; set; }
        public string BatchNo { get; set; }
        public string BatchSize { get; set; }
        public string ScheduleCode { get; set; }
        public string BatchType { get; set; }
        public string BatchCategory { get; set; }
        public string ProductID { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<int> ExpiryYear { get; set; }
        public Nullable<int> ExpiryMonth { get; set; }
        public string BatchStatus { get; set; }
        public Boolean IsApproved { get; set; }
        public Boolean IsReProcess { get; set; }
        public Nullable<DateTime> ApprovedDate { get; set; }
        public string ApprovedComment { get; set; }
    }
}