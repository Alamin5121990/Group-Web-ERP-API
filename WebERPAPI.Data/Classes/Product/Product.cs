using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Product
{
    public class ProductList
    {
        public int BrandId { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> Vat { get; set; }
    }

    public class ProductSalesQuantity
    {
        public int ID { get; set; }
        public string ProductCode { get; set; }
        public int Month { get; set; }
        public int TotalSalesQty { get; set; }
    }

    public class ProductBatchInProgress
    {
        public string ProductCode { get; set; }
        public Nullable<int> NoofBatchInProcess { get; set; }
        public Nullable<decimal> BatchOutputInProcess { get; set; }
        public Nullable<int> BatchInRelease { get; set; }
        public Nullable<decimal> BatchInReleaseOutput { get; set; }
    }

    public class ProductForecastQuantity
    {
        public Nullable<int> ID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string CommercialPackSize { get; set; }
        public string ProductPriorityCode { get; set; }

        public Nullable<int> CommercialQuantity { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails { get; set; }
    }

    public class ProductForecastSampleQuantity
    {
        public string SampleID { get; set; }
        public string PackSize { get; set; }
        public string SPS { get; set; }
        public Nullable<int> Quantity { get; set; }
    }

    public class ProductForecastQuantityLast3Months
    {
        public int ID { get; set; }
        public string ProductCode { get; set; }
        public int MonthNo { get; set; }
        public Nullable<decimal> TotalSampleQuantity { get; set; }
        public Nullable<int> TotalCommercialQuantity { get; set; }
    }

    public class ProductSampleList
    {
        public string ProductCode { get; set; }
        public string SampleID { get; set; }
        public string PackSize { get; set; }
        public string SPS { get; set; }
    }

    public class ProductBatchDetails
    {
        public string BatchID { get; set; }
        public string BatchNo { get; set; }
        public string BatchSize { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string BatchStatus { get; set; }
        public string ExpiryDate { get; set; }
        public string TransferNoteID { get; set; }
        public string TransferNoteNo { get; set; }
        public Nullable<DateTime> TransferDate { get; set; }
        public Nullable<decimal> TransferQty { get; set; }
        public Nullable<DateTime> StartDate { get; set; }

        public string ScheduleCode { get; set; }
        public string BatchType { get; set; }
    }

    public class ProductActiveMaterial
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
    }

    public class ProductFourMonthForecastQuantity
    {
        public Nullable<int> ID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string CommercialPackSize { get; set; }
        public string ProductPriorityCode { get; set; }

        public Nullable<int> TotalQuantity { get; set; }
        public Nullable<int> LastMonthQuantity { get; set; }

        public Nullable<int> CommercialQuantity1 { get; set; }
        public Nullable<int> CommercialQuantity2 { get; set; }
        public Nullable<int> CommercialQuantity3 { get; set; }
        public Nullable<int> CommercialQuantity4 { get; set; }

        public List<ProductForecastSampleQuantity> SampleDetails1 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails2 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails3 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails4 { get; set; }
    }

    public class ProductTwelveMonthForecastQuantity
    {
        public Nullable<int> ID { get; set; }
        public string BrandName { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string CommercialPackSize { get; set; }
        public string ProductLocation { get; set; }
        public string ProductPriorityCode { get; set; }

        public Nullable<int> TotalQuantity { get; set; }
        public Nullable<int> LastMonthQuantity { get; set; }

        public Nullable<int> CommercialQuantity1 { get; set; }
        public Nullable<int> CommercialQuantity2 { get; set; }
        public Nullable<int> CommercialQuantity3 { get; set; }
        public Nullable<int> CommercialQuantity4 { get; set; }
        public Nullable<int> CommercialQuantity5 { get; set; }
        public Nullable<int> CommercialQuantity6 { get; set; }
        public Nullable<int> CommercialQuantity7 { get; set; }
        public Nullable<int> CommercialQuantity8 { get; set; }
        public Nullable<int> CommercialQuantity9 { get; set; }
        public Nullable<int> CommercialQuantity10 { get; set; }
        public Nullable<int> CommercialQuantity11 { get; set; }
        public Nullable<int> CommercialQuantity12 { get; set; }
        public Nullable<int> CommercialQuantity13 { get; set; }
        public Nullable<int> CommercialQuantity14 { get; set; }
        public Nullable<int> CommercialQuantity15 { get; set; }
        public Nullable<int> CommercialQuantity16 { get; set; }
        public Nullable<int> CommercialQuantity17 { get; set; }
        public Nullable<int> CommercialQuantity18 { get; set; }

        public List<ProductForecastSampleQuantity> SampleDetails1 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails2 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails3 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails4 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails5 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails6 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails7 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails8 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails9 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails10 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails11 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails12 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails13 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails14 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails15 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails16 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails17 { get; set; }
        public List<ProductForecastSampleQuantity> SampleDetails18 { get; set; }
    }

    public class ProductForecastForUpdate
    {
        public int MonthNo { get; set; }
        public string Data { get; set; }
        public int UserID { get; set; }
    }
}