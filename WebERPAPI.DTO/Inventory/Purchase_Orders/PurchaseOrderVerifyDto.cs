namespace WebERPAPI.DTO.Inventory.Purchase_Orders
{
    public class PurchaseOrderVerifyDto
    {
        public string Code { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string Remarks { get; set; }
    }
}