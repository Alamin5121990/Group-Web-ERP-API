using System;

namespace WebERPAPI.DTO.Inventory
{
    public class PartsAndMachineLogs
    {
        public Nullable<int> ID { get; set; }
        public string RequisitionCode { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string ProformaInvoiceNumber { get; set; }
        public Nullable<DateTime> ProformaInvoiceDate { get; set; }

        public string LCNo { get; set; }
        public Nullable<DateTime> LCDate { get; set; }
        public Nullable<decimal> LCValue { get; set; }
        public string Remarks { get; set; }
        public string EmployeeID { get; set; }
    }
}