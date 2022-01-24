using System;

namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class ItemSpecification
    {
        public Nullable<int> SpecificationID { get; set; }
        public string SpecificationValue { get; set; }
        public string SpecificationName { get; set; }
        public string UOM { get; set; }
        public Nullable<Boolean> ShowInName { get; set; }
        public Nullable<Boolean> IsSelected { get; set; }
        public Nullable<int> OrderNo { get; set; }
    }
}