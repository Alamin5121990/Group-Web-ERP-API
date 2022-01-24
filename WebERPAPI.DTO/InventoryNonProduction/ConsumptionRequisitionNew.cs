using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class ConsumptionRequisitionNew
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> MainGroupID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string Remarks { get; set; }
        public string CreatedByID { get; set; }
        public string Data { get; set; }
    }

    public class ConsumptionRequisitionNewItem
    {
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> ItemID { get; set; }
        public string Purpose { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<DateTime> RequireDate { get; set; }
    }
}