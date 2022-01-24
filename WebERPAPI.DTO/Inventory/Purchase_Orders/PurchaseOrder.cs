using System;

namespace WebERPAPI.DTO.Inventory
{
    public class PurchageOrderPending
    {
        public string POID { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public string Subject { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ModeofPayment { get; set; }
        public Nullable<DateTime> RequiredDate { get; set; }
        public string RequiredFor { get; set; }
        public Nullable<decimal> BillAmount { get; set; }
    }

    public class BillPaymentAdvance
    {
        public string POID { get; set; }
        public Nullable<int> BillGroupTypeID { get; set; }
        public string SupplierID { get; set; }
        public Nullable<decimal> POAmount { get; set; }
        public Nullable<decimal> AdvancePercent { get; set; }
        public Nullable<decimal> AdvancePaymentAmount { get; set; }
        public Boolean IsUrgent { get; set; }
        public string Remarks { get; set; }
        public string EmployeeID { get; set; }
    }

    public class AdvanceRequisition
    {
        public string POID { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public string Subject { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> POAmount { get; set; }
        public Nullable<decimal> AdvancePercent { get; set; }
        public Nullable<decimal> AdvancePaymentAmount { get; set; }
        public string Remarks { get; set; }
        public Boolean IsUrgent { get; set; }
        public Nullable<DateTime> AdvanceRequestedOn { get; set; }
        public string RequestedBy { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<Boolean> IsReceivedFromAccounts { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public string ReceivedBy { get; set; }
        public string ApprovalRemarks { get; set; }

        public Nullable<DateTime> RollBackOn { get; set; }
        public string RollBackBy { get; set; }
        public string RollBackById { get; set; }
        public string RollBackRemarks { get; set; }
    }

    public class SupplierAdvanceRequisitionHistory
    {
        public string POID { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public string Subject { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> POAmount { get; set; }
        public Nullable<decimal> AdvancePercent { get; set; }
        public Nullable<decimal> AdvancePaymentAmount { get; set; }
        public string Remarks { get; set; }
        public Nullable<DateTime> AdvanceRequestedOn { get; set; }
    }

    public class AdvanceRequisitionApproval
    {
        public string POID { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovalRemarks { get; set; }
    }

    public class PurchaseOrder
    {
        public string POID { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public string RequisitionCode { get; set; }
        public string SupplierID { get; set; }
        public string ManufacturerID { get; set; }
        public string Subject { get; set; }
        public string RequiredFor { get; set; }
        public Nullable<DateTime> RequiredDate { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public string ModeofPayment { get; set; }
        public string TermsConditions { get; set; }
        public string Currency { get; set; }
        public Nullable<Boolean> IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<DateTime> ApprovedDate { get; set; }
        public string ApproveComment { get; set; }
        public Nullable<Boolean> IsPOClosed { get; set; }
        public string POClosedBy { get; set; }
        public Nullable<DateTime> POClosedOn { get; set; }
        public string Location { get; set; }
        public string MachinenameIP { get; set; }
        public Nullable<Boolean> Transfered { get; set; }
        public Nullable<Boolean> HOTransfered { get; set; }
        public string Addedby { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }
        public string Updatedby { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }
        public Nullable<Boolean> IsPOCanceled { get; set; }
        public Nullable<DateTime> POCanceledOn { get; set; }
        public string POCanceledReason { get; set; }
        public string CanceledBy { get; set; }
        public string CreatedBy { get; set; }
        public string Designation { get; set; }

        public string BillID { get; set; }

        public Nullable<Boolean> IsVerified { get; set; }
        public Nullable<DateTime> VerifiedOn { get; set; }
        public string VerifiedBy { get; set; }
        public string VerifiedDesignation { get; set; }

        public string CreatedDepartment { get; set; }
        public string VerifiedDepartment { get; set; }
        public string ApprovedDepartment { get; set; }
    }
}