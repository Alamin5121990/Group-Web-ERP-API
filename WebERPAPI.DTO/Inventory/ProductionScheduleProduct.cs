namespace WebERPAPI.DTO.Inventory
{
    public class ProductionScheduleProduct
    {
        public int ScheduleID { get; set; }
        public string Data { get; set; }
        public string EmployeeID { get; set; }
    }

    public class ProductionScheduleProductData
    {
        public int ProductID { get; set; }
        public int BatchNo { get; set; }
    }
}