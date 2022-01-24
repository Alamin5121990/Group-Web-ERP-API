namespace WebERPAPI.DTO.Inventory.Requisitions
{
    public class RequisitionCancel
    {
        public string RequisitionCode { get; set; }
        public string ReasonToCancel { get; set; }
        public string EmployeeCode { get; set; }
    }
}