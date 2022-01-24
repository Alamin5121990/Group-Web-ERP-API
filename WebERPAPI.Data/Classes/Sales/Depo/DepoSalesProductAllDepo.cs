using System;

namespace LabaidMIS.Data.Classes.Sales.Depo
{
    public class DepoSalesProductAllDepo
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }

        public Nullable<int> Last3MonthsAVGSalesQuantity { get; set; }
        public Nullable<int> LastMonthSalesQuantity { get; set; }
        public Nullable<int> SalesQuantityUpto { get; set; }
    }

    public class DepoSalesProductAllDepoReport
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }

        public Nullable<int> Last3MonthsAVGSalesQuantity { get; set; }
        public Nullable<int> LastMonthSalesQuantity { get; set; }
        public Nullable<int> SalesQuantityUpto { get; set; }

        public Nullable<int> Stock { get; set; }
        public Nullable<int> TransitStock { get; set; }
        public Nullable<int> TotalStock { get; set; }

        public int DayCoverSales { get; set; }
    }
}