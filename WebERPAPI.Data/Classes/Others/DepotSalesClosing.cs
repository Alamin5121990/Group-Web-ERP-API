using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes
{
    public class DepotSalesClosingProduct
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public string DepotID { get; set; }
        public string DepoName { get; set; }
        public Nullable<decimal> ReceiveQty { get; set; }
        public Nullable<decimal> SoldQty { get; set; }
        public Nullable<decimal> TotalClosing { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
    }

    public class DepotSalesClosingCWHProduct
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }

        public Nullable<decimal> TotalReceiveQty { get; set; }
        public Nullable<decimal> TotalIssueQty { get; set; }
        public Nullable<decimal> ClosingQty { get; set; }
    }

    public class DepotSalesClosingProductReport
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public List<DepotSalesClosingDetails> DepotDetails { get; set; }
        public Nullable<decimal> ProductTotalClosing { get; set; }
        public Nullable<decimal> ProductTotalTransitQuantity { get; set; }
    }

    public class DepotTransitQuantity
    {
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public string ProductCode { get; set; }
        public Nullable<decimal> TransitQty { get; set; }
    }

    public class DepotSalesClosingDetails
    {
        public string DepotID { get; set; }
        public string DepoName { get; set; }
        public Nullable<decimal> ReceiveQty { get; set; }
        public Nullable<decimal> SoldQty { get; set; }
        public Nullable<decimal> TransitQty { get; set; }
        public Nullable<decimal> TotalClosing { get; set; }
    }

    public class DepotSalesLastData
    {
        public string DepotID { get; set; }
        public DateTime ClosingDate { get; set; }
        public List<DepotSalesClosingProduct> LastData { get; set; }
    }
}