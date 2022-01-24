namespace WebERPAPI.Classes.Inventory.Store
{
    public class StoreItemNew
    {
        public int ID { get; set; }
        public int GroupID { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string UOM { get; set; }
        public string PackSize { get; set; }
        public string Specification { get; set; }
        public string Remarks { get; set; }
        public string EmployeeID { get; set; }
    }
}