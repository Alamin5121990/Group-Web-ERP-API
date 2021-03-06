using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class GRNNPDTO
    {
        public Nullable<int> ID { get; set; }

        public string GRNCode { get; set; }
        public Nullable<int> POID { get; set; }
        public string POCode { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }

        public string ChallanNumber { get; set; }
        public Nullable<DateTime> ChallanDate { get; set; }
        public Nullable<int> NumberOfItem { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> StoreID { get; set; }

        public string OtherCostName { get; set; }
        public Nullable<decimal> OtherCost { get; set; }
        public Nullable<decimal> CarryingCost { get; set; }
        public Nullable<decimal> LabourCost { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> VATAmount { get; set; }

        public string StoreName { get; set; }
        public Nullable<int> MainGroupID { get; set; }
        public string MainGroupName { get; set; }
        public string CreatedByID { get; set; }
        public string CreatedBy { get; set; }

        public string CreatedDesignation { get; set; }
        public string CreatedDepartment { get; set; }

        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<int> QRNID { get; set; }
        public Nullable<DateTime> RequiredDate { get; set; }
        public string PurchaseOrderStatus { get; set; }

        public string VATChallanNumber { get; set; }
        public Nullable<DateTime> VATChallanDate { get; set; }
        public Nullable<Boolean> IsVDSAllowed { get; set; }

        public string QRNByID { get; set; }
        public Nullable<DateTime> QRNOn { get; set; }

        public string QRNBy { get; set; }
        public string QRNDesignation { get; set; }
        public string QRNDepartment { get; set; }

        public Nullable<Boolean> IsApproved { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public string ApprovedBy { get; set; }

        public string ApprovedDepartment { get; set; }
        public string ApprovedDesignation { get; set; }
    }
}