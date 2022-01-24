namespace LabaidMIS.Data.Classes.Sales
{
    public class ChemistCreditSummary
    {
        public int TotalChemist { get; set; }
        public int TotalCreditAmount { get; set; }
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
    }

    public class ChemistCreditDetails
    {
        public string ChemistID { get; set; }
        public int ChemistNumber { get; set; }
        public string ChemistName { get; set; }
        public string Address { get; set; }
        public int CreditAmount { get; set; }
        public int CreditLimit { get; set; }
    }
}