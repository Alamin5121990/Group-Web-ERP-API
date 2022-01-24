using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class MaterialUpcomingExpiry
    {
        public string CompanyID { get; set; }
        public string GRNID { get; set; }
        public string LabRefID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> LastStockQty { get; set; }
        public string TypeName { get; set; }
        public Nullable<DateTime> ExpiryDate { get; set; }
        public Nullable<DateTime> ReTestDate { get; set; }
    }
}