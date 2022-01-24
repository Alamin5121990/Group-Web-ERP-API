using System;

namespace WebERPAPI.DTO.Inventory.PurchaseOrdersNP
{
    public class PurchaseOrderNPNew
    {
        public int ID { get; set; }
        public int MainGroupID { get; set; }
        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }
        public DateTime RequiredDate { get; set; }

        public int BillPaymentTypeID { get; set; }

        public string TermsAndConditions { get; set; }
        public string EmployeeCode { get; set; }
        public string Data { get; set; }
        public string Remarks { get; set; }
        public decimal Discount { get; set; }
        public decimal CarryingCost { get; set; }
        public decimal LabourCost { get; set; }
        public string OtherCostName { get; set; }
        public decimal OtherCost { get; set; }
    }
}