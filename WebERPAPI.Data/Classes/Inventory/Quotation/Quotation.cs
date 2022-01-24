using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class QuotationPending
    {
        //public Nullable<int> QuotationID { get; set; }
        //public string QuotationCode { get; set; }

        //public Nullable<int> TotalMaterial { get; set; }
        //public Nullable<int> TotalPending { get; set; }
        //public Nullable<int> TotalReceived { get; set; }
        //public Nullable<int> TotalCSDone { get; set; }

        //public string CreatedBy { get; set; }
        //public Nullable<DateTime> CreatedOn { get; set; }

        //public Nullable<int> QuotationReceiveID { get; set; }
        //public List<QuotationMaterialList> MaterialList { get; set; }

        public Nullable<int> QuotationID { get; set; }

        public string MaterialCode { get; set; }
        public string QuotationCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public string MaterialGrade { get; set; }

        public Nullable<DateTime> LastReceivedDate { get; set; }
        public Nullable<decimal> InvitedQuantity { get; set; }
        public string RequisitionCode { get; set; }
        public Nullable<int> TotalInvitedIndentor { get; set; }
        public Nullable<int> TotalQuotationReceived { get; set; }

        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string LCID { get; set; }
    }

    public class QuotationReceiveData
    {
        public string Data { get; set; }
        public string EmployeeID { get; set; }
        public int QuotationInvitationID { get; set; }
        public string QuotationReceivedOn { get; set; }
        public string Remarks { get; set; }
    }

    public class QuotationImportReceiveData
    {
        public string Data { get; set; }
        public string EmployeeID { get; set; }
        public Boolean IsReceiveComplete { get; set; }
        public int QuotationInvitationID { get; set; }
        public string Remarks { get; set; }
    }

    public class QuotationReceivedDetails
    {
        public string RequisitionCode { get; set; }
        public string SupplierCode { get; set; }
        public string MaterialCode { get; set; }
        public Nullable<decimal> ReceivedQty { get; set; }
        public Nullable<decimal> ReceivedPrice { get; set; }
    }

    public class QuotationImportReceivedDetails
    {
        public string RequisitionCode { get; set; }
        public string IndentorCode { get; set; }
        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }
        public string MaterialCode { get; set; }

        public string ModeOfShipment { get; set; }
        public Nullable<int> CurrencyID { get; set; }

        public Nullable<decimal> CurrencyConversionRate { get; set; }

        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> OfferedFOBRate { get; set; }
        public Nullable<decimal> OfferedCPTRate { get; set; }

        public string Remarks { get; set; }
        public string PackagingInfo { get; set; }
    }

    public class RequisitionItemForCS
    {
        public Boolean IsSelected { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
    }

    public class QuotationDetailsForCS
    {
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }

        public string CurrencyName { get; set; }
        public Nullable<int> CurrencyID { get; set; }
        public string ModeOfShipment { get; set; }

        public Nullable<decimal> ReceivedQuantity { get; set; }
        public Nullable<decimal> ReceivedPrice { get; set; }

        public Nullable<DateTime> PurchaseDate { get; set; }
        public Nullable<decimal> PurchaseRate { get; set; }
        public Nullable<decimal> PurchaseQuantity { get; set; }

        public Nullable<Boolean> IsSelected { get; set; }
    }

    public class ComparativeStudyMaterialDetails
    {
        public string RequisitionCode { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Remarks { get; set; }
        public string MaterialName1 { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public string Source { get; set; }
        public string ShortSpec { get; set; }
        public Nullable<int> LeadTime { get; set; }
        public string LeadTimeDetails { get; set; }
    }

    public class RequisitionSupplierPrice
    {
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> OfferedQuantity { get; set; }
        public Nullable<decimal> OfferedPrice { get; set; }

        public Nullable<decimal> PreviousPurchaseQuantity { get; set; }
        public Nullable<decimal> PreviousPurchasePrice { get; set; }
        public Nullable<DateTime> PreviousPurchaseDate { get; set; }
    }

    public class ComparativeStudyData
    {
        public string Data { get; set; }
        public string EmployeeID { get; set; }
        public int CSID { get; set; }
        public string Remarks { get; set; }
        public decimal Rate { get; set; }
    }

    public class ComparativeStudyDetails
    {
        public Nullable<Boolean> Selected { get; set; }
        public Nullable<int> CSID { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string SupplierCode { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Remarks { get; set; }
    }

    public class ComparativeStudyList
    {
        public Nullable<int> ID { get; set; }
        public string CSCode { get; set; }
        public string RequisitionID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<int> TotalMaterial { get; set; }

        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public string ReviewedBy { get; set; }
        public Nullable<DateTime> ReviewedOn { get; set; }
        public string ReviewRemarks { get; set; }

        public string AccountsApproveBy { get; set; }
        public Nullable<DateTime> AccountsApprovedOn { get; set; }
        public string AccountsApprovalRemarks { get; set; }

        public string MarketingGMVerifiedBy { get; set; }
        public Nullable<DateTime> MarketingGMVerifiedOn { get; set; }
        public string MarketingGMVerifiedRemarks { get; set; }

        public string ManagementApproveBy { get; set; }
        public Nullable<DateTime> ManagementApprovedOn { get; set; }
        public string ManagementApprovalRemarks { get; set; }

        public Nullable<decimal> CSTotal { get; set; }

        public List<QuotationList> QuotationList { get; set; }
        public List<QuotationMaterialList> MaterialList { get; set; }
    }

    public class QuotationList
    {
        public Nullable<int> QuotationID { get; set; }
        public string QuotationCode { get; set; }
    }

    public class SelectedSupplier
    {
        public string SupplierID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
    }

    public class ComparativeStudyDetailsForReview
    {
        public string RequisitionCode { get; set; }
        public string QuotationCode { get; set; }
        public string SupplierID { get; set; }

        public string SupplierName { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string VersionNo { get; set; }

        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public Nullable<DateTime> RequisitionDate { get; set; }

        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Remarks { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public string Source { get; set; }
        public string ShortSpec { get; set; }
        public Nullable<int> LeadTime { get; set; }
        public string LeadTimeDetails { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
    }

    public class ComparativeStudySupplierPriceList
    {
        public string RequisitionID { get; set; }
        public string MaterialCode { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> ReceivedQuantity { get; set; }
        public Nullable<decimal> ReceivedPrice { get; set; }
    }

    public class ComparativeStudyApprovalData
    {
        public string MaterialCode { get; set; }
        public int CSID { get; set; }
        public string CSCode { get; set; }
        public string Remarks { get; set; }
        public string EmployeeID { get; set; }
    }

    public class SupplierMaterialList
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public string ShortSpec { get; set; }
    }

    public class ComparativeStudyImportData
    {
        public string Data { get; set; }
        public string EmployeeID { get; set; }
        public int CSID { get; set; }
        public string Remarks { get; set; }
    }

    public class ComparativeStudyImportDetails
    {
        public Nullable<Boolean> Selected { get; set; }
        public Nullable<int> CSID { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }

        public string IndentorCode { get; set; }
        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }

        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string ModeOfShipment { get; set; }
        public int CurrencyID { get; set; }
        public string Remarks { get; set; }
        public string DeliveryMode { get; set; }

        public Nullable<decimal> CurrencyConversionRate { get; set; }
    }
}