using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.DTO.Inventory;

namespace WebERPAPI.Data.Repository.Inventory.Product
{
    public class SampleRepositories
    {
     
        public List<ProductSampleStock> getProductSampleStockList()
        {
            return new InventoryGenericRepository<ProductSampleStock>().FindUsingSP("getProductSampleStock").ToList();
        }
    }
}