using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class InventoryRequisitionsForSpotPurchase
    {
        public string InventoryType { get; set; }

        public string MainGroupName { get; set; }

        public string StoreName { get; set; }
        public string RequisitionType { get; set; }
        public string RequisitionCode { get; set; }
        public Nullable<int> RequisitionID { get; set; }
        public string RequisitionRemarks { get; set; }

        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public Nullable<Boolean> IsApproved { get; set; }
    }

    public class SpotPurchasesaveDto
    {
        public int ID { get; set; }
        public string PurchaseCode { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Remarks { get; set; }
        public decimal TotalPrice { get; set; }
        public Nullable<decimal> VATAmount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<int> ApprovedByID { get; set; }
        public Nullable<DateTime> ApprovedDate { get; set; }
        public string ApprovalRemarks { get; set; }
        public Nullable<bool> IsCanceled { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
        public string CanceledRemarks { get; set; }
        public int CreatedByID { get; set; }
        public DateTime CreatedOn { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
        public string PODetails { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class SpotPurchaseDetailDto
    {
        public int ID { get; set; }
        public string PurchaseID { get; set; }
        public int RequisitionID { get; set; }
        public string RequisitionCode { get; set; }
        public string InventoryType { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }

        public string MainGroupName { get; set; }
        public string ItemNameWithSpec { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public Nullable<decimal> VATPercent { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Supplier { get; set; }
        public string SupplierName { get; set; }
        public int CreatedByID { get; set; }
        public DateTime CreatedOn { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
    }

    public class SpotPurchaseSupplierDto
    {
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
    }
}