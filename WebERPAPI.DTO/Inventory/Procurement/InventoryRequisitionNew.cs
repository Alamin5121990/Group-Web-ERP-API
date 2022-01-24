using System;

namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class InventoryRequisitionNew
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> InventoryTypeID { get; set; }
        public string TermAndCondition { get; set; }
        public string RequisitionCode { get; set; }
        public Nullable<int> MainGroupID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<int> RequisitionTypeID { get; set; }
        public string Remarks { get; set; }
        public string Data { get; set; }
        public string BrandIds { get; set; }
        public string Months { get; set; }
        public string EmployeeID { get; set; }
    }

    public class InventoryRequisitionItems
    {
        public Nullable<int> MainGroupID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public string Purpose { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public Nullable<int> VersionID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public System.Collections.Generic.List<InventoryRequisitionSpecifications> Specification { get; set; }
    }

    public class InventoryRequisitionSpecifications
    {
        public Nullable<int> SpecificationID { get; set; }
        public string SpecificationValue { get; set; }
        public string SpecificationName { get; set; }
        public string UOM { get; set; }
        public Nullable<bool> ShowInName { get; set; }
        public Nullable<bool> IsSelected { get; set; }
        public Nullable<int> OrderNo { get; set; }
    }
}