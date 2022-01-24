using System;

namespace LabaidMIS.Data.Classes.Product
{
    public class MaterialList
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<int> MaterialProdcutPriorityID { get; set; }
        public string ProductPriorityCode { get; set; }
        public string ProductType { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductCategory { get; set; }
        public string CategoryName { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public string SourceType { get; set; }
        public string VersionNo { get; set; }
        public string ShortSpec { get; set; }
        public Nullable<int> LeadTime { get; set; }
        public Nullable<decimal> OneBatchRequiredQuantity { get; set; }

        public string MaterialGrade { get; set; }
        public Nullable<decimal> MSL { get; set; }
    }
}