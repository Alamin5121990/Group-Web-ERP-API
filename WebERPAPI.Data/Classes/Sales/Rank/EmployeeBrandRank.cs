using System;

namespace LabaidMIS.Data.Classes.Sales.Rank
{
    public class EmployeeBrandRank
    {
        public string ID { get; set; }

        public Nullable<int> OAID { get; set; }
        public Nullable<int> ZoneID { get; set; }
        public Nullable<int> BrandID { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }

        public Nullable<DateTime> InvoiceDate { get; set; }
        public Nullable<decimal> SalesAverage { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
        public Nullable<int> RankNo { get; set; }
    }
}