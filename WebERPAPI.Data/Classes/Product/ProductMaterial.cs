using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Product
{
    public class ProductMaterialList
    {
        public string MaterialCode { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> STDQuantity { get; set; }
    }

    public class ProductMaterial
    {
        public string ProductCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialGrade { get; set; }

        public string MaterialName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<int> LeadTime { get; set; }
        public string LeadTimeDetails { get; set; }
        public string UOM { get; set; }
    }

    public class ProductMaterialReport
    {
        public string MaterialCode { get; set; }
        public string MaterialGrade { get; set; }
        public string MaterialName { get; set; }

        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> FreeStockQuantity { get; set; }
        public Nullable<decimal> ProductionFloorStockQuantity { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<decimal> BookingQuantity { get; set; }
        public Nullable<decimal> QuarantineQuantity { get; set; }
        public Nullable<decimal> ReTestQuantity { get; set; }
        public Nullable<decimal> RequiredQuantity { get; set; }

        public string UOM { get; set; }
        public Nullable<int> LeadTime { get; set; }
        public string LeadTimeDetails { get; set; }
        public Boolean IsOpen { get; set; }
        public Boolean IsIntermediateMaterial { get; set; }
    }

    public class ProductMaterialClosingQuantity
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string ProductTypeName { get; set; }
        public string CategoryName { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> STDBatchQuantity { get; set; }
        public Nullable<decimal> GRNQty { get; set; }
        public Nullable<decimal> QCQty { get; set; }
        public Nullable<decimal> PassedQty { get; set; }
        public Nullable<decimal> ADJRQty { get; set; }
        public Nullable<decimal> BatchRTQty { get; set; }
        public Nullable<decimal> IssueQty { get; set; }
        public Nullable<decimal> UsedQty { get; set; }
        public Nullable<decimal> ADJIQty { get; set; }
        public Nullable<decimal> ClosingQty { get; set; }
    }

    public class ProductMaterialRequisitionQuantity
    {
        public string MaterialCode { get; set; }
        public Nullable<decimal> RequisitionQty { get; set; }
    }

    public class ProductMaterialRequisitionDetails
    {
        public Nullable<DateTime> RequisitionDate { get; set; }

        public string RequisitionID { get; set; }
        public string VersionNo { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<decimal> CSQuantity { get; set; }
        public Nullable<decimal> POQuantity { get; set; }

        public Nullable<decimal> LCQuantity { get; set; }
        public string GRNQuantity { get; set; }
        public string QuotationCode { get; set; }
        public string CSCode { get; set; }
        public string POID { get; set; }

        public string LCID { get; set; }
        public Nullable<DateTime> QuotationDate { get; set; }
        public Nullable<DateTime> CSDate { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public Nullable<DateTime> LCDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string SupplierName { get; set; }

        public string SupplierCode { get; set; }
    }

    public class ProductMaterialBookingQuantity
    {
        public string MaterialCode { get; set; }
        public Nullable<decimal> BookingQty { get; set; }
    }

    public class ProductMaterialBookingDetails
    {
        public string BatchID { get; set; }
        public string BatchNo { get; set; }
        public string ProductID { get; set; }
        public string CommercialCode { get; set; }
        public string ProductName { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> StdQty { get; set; }
        public string IssueID { get; set; }
        public string GRNID { get; set; }
        public string LabRefID { get; set; }
        public Nullable<decimal> IssueQty { get; set; }
        public Nullable<decimal> BookingQty { get; set; }
    }

    public class ProductMaterialQuarantineQuantity
    {
        public string MaterialCode { get; set; }
        public Nullable<decimal> QuarantineQty { get; set; }
    }

    public class ProductMaterialQuarantineDetails
    {
        public string GRNID { get; set; }
        public Nullable<System.DateTime> GRNDate { get; set; }
        public string POID { get; set; }
        public string LCID { get; set; }
        public string Source { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> ReceiveQty { get; set; }
        public string LabRefID { get; set; }
        public string QCTestID { get; set; }
        public string TestStatus { get; set; }
        public Nullable<decimal> PassedQty { get; set; }
        public Nullable<Boolean> IsApproved { get; set; }
    }

    public class ProductMaterialDetailsReport
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ProductID { get; set; }
        public string PID { get; set; }
        public string SalesCode { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public string SPS { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> Vat { get; set; }

        public List<ProductMaterial> MaterialList { get; set; }
    }

    public class ProductMaterialReTestQuantity
    {
        public string MaterialCode { get; set; }
        public Nullable<decimal> RetestQty { get; set; }
    }

    public class ProductMaterialQualifyDetails
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> STDQuantity { get; set; }
        public Nullable<decimal> FreeStockQuantity { get; set; }
        public Nullable<decimal> QuarantineQuantity { get; set; }
        public Nullable<decimal> BookingQuantity { get; set; }
        public Nullable<decimal> BatchRequireQuantity { get; set; }
        public int TotalBatchQualify { get; set; }
    }
}