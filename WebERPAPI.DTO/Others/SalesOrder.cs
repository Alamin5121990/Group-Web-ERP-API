namespace WebERPAPI.DTO
{
    public class SalesOrderReport
    {
        public System.DateTime OrderDate { get; set; }
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public string depoid { get; set; }
        public string DepoName { get; set; }
        public int noofemployee { get; set; }
        public int noofOrder { get; set; }
        public decimal OrderValue { get; set; }
    }
}