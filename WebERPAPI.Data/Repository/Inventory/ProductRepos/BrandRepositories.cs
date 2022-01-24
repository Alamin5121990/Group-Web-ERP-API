using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.DTO;

using WebERPAPI.Data.Models.MIS;

namespace WebERPAPI.Data.Repository
{
    public class BrandRepositories // : IBrandRepositories
    {
        public Exception error = new Exception();

      
        public List<BrandDailySales> getBrandWiseDailySales(DateTime InvoiceDate)
        {
            try
            {
                using (MISEntities db = new MISEntities())
                {
                    return db.LocationWiseSales.Where(l => l.InvoiceDate == InvoiceDate.Date)
                            .GroupBy(l => l.BrandId)
                            .Select(r => new BrandDailySales
                            {
                                BrandID = r.FirstOrDefault().BrandId,
                                TotalSales = r.Sum(c => c.SoldValue)
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<BrandAndCurrentSales> getBrandAndCurrentSales()
        {
            try
            {
                using (MISEntities db = new MISEntities())
                {
                    return db.Database.SqlQuery<BrandAndCurrentSales>("getBrandAndCurrentSales").ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }
    }
}