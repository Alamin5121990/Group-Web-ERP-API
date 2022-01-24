namespace WebERPAPI.DTO.Inventory
{
    public class ItemGroupNew
    {
        public int ID { get; set; }
        public int InventoryTypeID { get; set; }
        public int MainGroupID { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public string ItemCodePrefix { get; set; }

        public string EmployeeCode { get; set; }
    }
}