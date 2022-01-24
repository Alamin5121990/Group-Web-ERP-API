using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class MPOSalesData
    {
        public string LocationCode { get; set; }
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
        public Nullable<decimal> SalesTarget { get; set; }
        public Nullable<decimal> Achievement { get; set; }
    }

    public class MPOPerformaceReport
    {
        public string LocationCode { get; set; }
        public string LocationName { get; set; }

        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }

        public Nullable<DateTime> JoiningDate { get; set; }

        public Nullable<decimal> TotalSales { get; set; }

        public MPOsSalesDetails Month1 { get; set; }
        public MPOsSalesDetails Month2 { get; set; }
        public MPOsSalesDetails Month3 { get; set; }
        public MPOsSalesDetails Month4 { get; set; }
        public MPOsSalesDetails Month5 { get; set; }
        public MPOsSalesDetails Month6 { get; set; }
        public MPOsSalesDetails Month7 { get; set; }
        public MPOsSalesDetails Month8 { get; set; }
        public MPOsSalesDetails Month9 { get; set; }
        public MPOsSalesDetails Month10 { get; set; }
        public MPOsSalesDetails Month11 { get; set; }
    }

    public class MPOsSalesDetails
    {
        public Nullable<decimal> SalesTarget { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
        public Nullable<decimal> Achievement { get; set; }

        public Nullable<decimal> Growth { get; set; }
    }
}