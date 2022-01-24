namespace WebERPAPI.DTO
{
    public class PrescriptionSummary
    {
        public int Year { get; set; }
        public string Month { get; set; }
        public string PrescriptionDate { get; set; }
        public string WorkAreaType { get; set; }
        public string WorkAreaID { get; set; }
        public string WorkAreaName { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string MobileNo { get; set; }
        public string DateofJoining { get; set; }
        public decimal TargetQty { get; set; }
        public int PresQtyToday { get; set; }
        public int PresQtyMonth { get; set; }
        public string LastPrescriptionTime { get; set; }
        public decimal CurSales { get; set; }
        public decimal LastSales { get; set; }
    }
}