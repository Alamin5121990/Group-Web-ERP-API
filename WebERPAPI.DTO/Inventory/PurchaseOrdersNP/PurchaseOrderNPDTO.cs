using System;

namespace WebERPAPI.DTO.Inventory.PurchaseOrdersNP
{
    public class PurchaseOrderNPDto : BaseEntityDTO
    {
        //public Nullable<int> ID { get; set; }

        //public string MainGroupName { get; set; }
        //public string InventoryType { get; set; }
        //public Nullable<int> StoreID { get; set; }
        //public string StoreName { get; set; }
        //public string RequisitionCode { get; set; }

        //public Nullable<int> InventoryTypeID { get; set; }
        //public Nullable<int> RequisitionID { get; set; }
        //public string RequisitionType { get; set; }
        //public string PaymentTypeName { get; set; }
        //public string POCode { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }

        public Nullable<int> TotalMaterial { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<decimal> VATAmount { get; set; }
        public Nullable<decimal> Discount { get; set; }

        public Nullable<decimal> CarryingCost { get; set; }
        public Nullable<decimal> LabourCost { get; set; }

        public string OtherCostName { get; set; }
        public Nullable<decimal> OtherCost { get; set; }

        public Nullable<decimal> TotalAmount { get; set; }

        //public Nullable<int> BillPaymentTypeID { get; set; }
        //public Nullable<DateTime> DeliveryDate { get; set; }
        //public Nullable<int> MainGroupID { get; set; }
        //public Nullable<DateTime> RequiredDate { get; set; }
        //public string TermsAndConditions { get; set; }

        //public string SupplierCode { get; set; }
        //public string SupplierName { get; set; }
        //public string ManufacturerCode { get; set; }
        //public string ManufacturerName { get; set; }
        //public string Remarks { get; set; }

        //public string CreatedBy { get; set; }
        //public Nullable<DateTime> CreatedOn { get; set; }

        public Nullable<int> NumberOfGRN { get; set; }
        public Nullable<DateTime> LastGRNDate { get; set; }
        //public Nullable<Boolean> IsClosed { get; set; }

        //public Nullable<DateTime> ClosedOn { get; set; }
        public Nullable<int> NumberOfQRN { get; set; }

        public Nullable<DateTime> LastQRNDate { get; set; }
        //public Nullable<Boolean> IsPOClosable { get; set; }
        //public string BillID { get; set; }

        //public Nullable<int> CreditDays { get; set; }

        //public Nullable<bool> IsCanceled { get; set; }
        //public Nullable<DateTime> CanceledOn { get; set; }
        //public string CanceledReason { get; set; }
        //public string CanceledBy { get; set; }

        //public string ItemNames { get; set; }

        public string MainGroupName { get; set; }
        public string InventoryType { get; set; }

        public Nullable<int> StoreID { get; set; }
        public string StoreName { get; set; }

        public string RequisitionCode { get; set; }

        public Nullable<int> InventoryTypeID { get; set; }
        public Nullable<int> RequisitionID { get; set; }
        public string RequisitionType { get; set; }
        public string PaymentTypeName { get; set; }
        public string POCode { get; set; }

        public Nullable<int> BillPaymentTypeID { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public Nullable<int> MainGroupID { get; set; }
        public Nullable<DateTime> RequiredDate { get; set; }
        public string TermsAndConditions { get; set; }

        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }

        public Nullable<Boolean> IsPOClosable { get; set; }
        public string BillID { get; set; }
        public Nullable<Boolean> IsCanceled { get; set; }

        public Nullable<DateTime> CanceledOn { get; set; }
        public string CanceledReason { get; set; }
        public string CanceledBy { get; set; }
        public string ItemNames { get; set; }
    }

    public class nonPSupplierListOfAllPODto
    {
        public string SupplierCode { get; set; }

        public string SupplierName { get; set; }
        public Nullable<int> TotalPO { get; set; }
    }
}