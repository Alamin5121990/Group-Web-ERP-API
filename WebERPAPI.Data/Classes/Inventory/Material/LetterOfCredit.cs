using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class LetterOfCredit
    {
        public string LCNo { get; set; }
        public Nullable<DateTime> LCDate { get; set; }
        public Nullable<DateTime> LastShipDate { get; set; }
        public string Currency { get; set; }
        public Nullable<decimal> ConvRate { get; set; }
        public Nullable<DateTime> ExpireDate { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string BankID { get; set; }
        public string BankName { get; set; }
        public string IndenterID { get; set; }
        public string SupplierName1 { get; set; }
        public string InsuranceNo { get; set; }
        public Nullable<DateTime> InsuranceDate { get; set; }
        public Nullable<decimal> InsuranceValue { get; set; }
        public string Addedby { get; set; }
    }
}
