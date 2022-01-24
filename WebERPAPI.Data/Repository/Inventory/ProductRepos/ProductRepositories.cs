using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.MIS;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory;

namespace WebERPAPI.Data.Repository.Product
{
    public class ProductRepositories //: IProductRepositories
    {
        public Exception error = new Exception();

        public List<Models.MIS.BOMMaster> getProductBOMDetails()
        {
            try
            {
                using (Models.MIS.MISEntities db = new Models.MIS.MISEntities())
                {
                    return db.BOMMasters.Where(m => m.IsInActive == false).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<ProductBatchCreationDetails> getProductScheduledBatchDetails(string ProductID, string ScheduleCode)
        {
            return new InventoryGenericRepository<ProductBatchCreationDetails>().FindUsingSP("getProductBatchDetails @ProductID, @ScheduleCode", new SqlParameter("@ProductID", ProductID), new SqlParameter("@ScheduleCode", ScheduleCode));
        }

        public List<ProductPriority> getProductPriorities()
        {
            return new InventoryGenericRepository<ProductPriority>().Find(p => p.IsActive == true);
        }

        
    }
}