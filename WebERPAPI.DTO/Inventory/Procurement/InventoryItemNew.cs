namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class InventoryItemNew
    {
        public int ID { get; set; }
        public int SubGroupId { get; set; }
        public string ItemName { get; set; }
        public string GenericName { get; set; }
        public string Description { get; set; }
        public string UOM { get; set; }

        public string EmployeeID { get; set; }
        public int InventoryTypeID { get; set; }
        public decimal Price { get; set; }
    }
}