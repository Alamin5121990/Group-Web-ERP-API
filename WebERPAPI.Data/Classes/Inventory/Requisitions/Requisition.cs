using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Inventory.Requisitions
{
    public class RequisitionPending
    {
        public string RequisitionID { get; set; }
        public System.DateTime ReqDate { get; set; }
        public string EmployeeName { get; set; }

        public string Remarks { get; set; }
        public Boolean IsApproved { get; set; }
        public int SLNo { get; set; }
        public string ProfileImagename { get; set; }
        public Nullable<int> QuotationCreated { get; set; }
        public Nullable<int> QuotationPending { get; set; }
        public Boolean IsOpen { get; set; }
        public Boolean IsSelected { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public string MaterialType { get; set; }

        public Boolean IsLocalSource { get; set; }
        public string Source { get; set; }

        public List<RequisitionMaterials> Materials { get; set; }
    }

    public class RequisitionMaterials
    {
        public string RequisitionID { get; set; }
        public Nullable<int> SLNo { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string MaterialGrade { get; set; }
        public string VersionNo { get; set; }
        public string ProductTypeName { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public string ShortSpec { get; set; }
        public string Remarks { get; set; }
        public string Source { get; set; }
    }

    public class RequisitionDetails
    {
        public string RequisitionID { get; set; }
        public int SLNo { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string VersionNo { get; set; }

        public string MaterialGrade { get; set; }
        public string ModeOfShipment { get; set; }

        public string ProductTypeName { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> BaseRequisitionQuantity { get; set; }
        public System.DateTime DeliveryDate { get; set; }

        public string Suppliers { get; set; }
        public string SupplierIDList { get; set; }
        public string ColorCode { get; set; }
        public string ShortSpec { get; set; }
        public string Remarks { get; set; }
        public string Source { get; set; }

        public Boolean SplitRequisition { get; set; }
    }

    public class MaterialSupplierDetails
    {
        public string SupplierType { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string ColorCode { get; set; }

        public List<ColorCodes> ColorCodeList { get; set; }
        public Boolean IsSelected { get; set; }
    }

    public class ColorCodes
    {
        public string ColorCode { get; set; }
    }

    public class SentRequisition
    {
        public string RequisitionID { get; set; }
        public string MaterialCode { get; set; }
        public string QuotationNumber { get; set; }
    }

    public class NextQuotationInvitationNumber
    {
        public int NextNumber { get; set; }
    }

    public class RequisitionPOGRNSummary
    {
        public string UDID { get; set; }
        public string ProductTypeName { get; set; }
        public string RequisitionID { get; set; }
        public Nullable<DateTime> ReqDate { get; set; }
        public string Raisedby { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> RequisitionQty { get; set; }
        public Nullable<DateTime> ExpectedDeliveryDate { get; set; }
        public string POID { get; set; }
        public string PONo { get; set; }
        public string DeliveryNo { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerName { get; set; }
        public Nullable<decimal> OrderQty { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> TotalValue { get; set; }
        public string POStatus { get; set; }
        public Nullable<decimal> PendingPOQty { get; set; }
        public string GRNID { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
        public Nullable<decimal> ReceiveQty { get; set; }
        public string BatchNo { get; set; }
        public Nullable<DateTime> MFGDate { get; set; }
        public Nullable<DateTime> ExpiryDate { get; set; }
        public string PackingInfo { get; set; }
        public string ReceiveRemarks { get; set; }
        public string DeliveryStatus { get; set; }
        public Nullable<decimal> PendingReceiveQty { get; set; }
        public string LabRefID { get; set; }
        public Nullable<decimal> PassedQty { get; set; }
        public string GRNStatus { get; set; }
    }

    public class EmailSupplierDetails
    {
        public string EmployeeID { get; set; }
        public string TermsAndCondition { get; set; }
        public string MandatoryCheckList { get; set; }
        public string RequisitionCodes { get; set; }
        public string MaterialCodes { get; set; }
        public string SelectedSuppliers { get; set; }
        public string LastReceiveDate { get; set; }
        public Boolean FOB { get; set; }
        public Boolean CPT { get; set; }
    }

    public class RequisitionAndMaterial
    {
        public string RequisitionID { get; set; }
        public string MaterialCode { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string ModeOfShipment { get; set; }
    }

    public class Requisition
    {
        public string RequisitionID { get; set; }
        public Nullable<DateTime> ReqDate { get; set; }
        public string EmployeeName { get; set; }
        public string ReqFor { get; set; }
        public string Remarks { get; set; }
        public Nullable<Boolean> IsApproved { get; set; }
        public string ProfileImagename { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public string MaterialType { get; set; }

        public Nullable<Boolean> IsCanceled { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
        public string ReasonToCancel { get; set; }
        public string CanceledBy { get; set; }
    }
}