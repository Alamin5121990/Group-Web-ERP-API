using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class MaterialFloorStockDetails
    {
        public string IssueID { get; set; }
        public Nullable<DateTime> IssueDate { get; set; }
        public string IssueType { get; set; }
        public string IssueTo { get; set; }
        public string MaterialCode { get; set; }
        public string GRNID { get; set; }
        public string LabRefID { get; set; }
        public Nullable<decimal> HandoverQty { get; set; }
        public Nullable<decimal> Issueqty { get; set; }
        public Nullable<decimal> ProductFloorStock { get; set; }
    }
}