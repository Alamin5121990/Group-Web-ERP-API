using System;

namespace LabaidMIS.Data.Classes.Product
{
    public class MaterialGRNDetails
    {
        public string GRNID { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
        public string LabRefID { get; set; }
        public Nullable<decimal> AvailableQty { get; set; }
        public Nullable<DateTime> ExpiryDate { get; set; }
        public Nullable<DateTime> MaxRetestDate { get; set; }
        public string VersionNo { get; set; }
    }
}