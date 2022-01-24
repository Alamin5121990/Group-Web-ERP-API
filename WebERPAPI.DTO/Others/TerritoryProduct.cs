namespace WebERPAPI.DTO
{
    public class TerritoryProduct
    {
        public string CompanyID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public string TerritoryID { get; set; }
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public decimal SOrderQty { get; set; }
        public decimal STotalTP { get; set; }
    }
}