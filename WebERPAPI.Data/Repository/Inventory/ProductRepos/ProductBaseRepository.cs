using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.Inventory;

namespace WebERPAPI.Data.Repository.Inventory.ProductRepos
{
    public class ProductBaseRepository
    {
        //private InventoryGenericRepository<Products> _product = null;
        //private MISGenericRepository<Products> _productMIS = null;

        public ProductBaseRepository()
        {
            //_product = new BrandAndProductGenericRepository<Products>();
            //_productMIS = new MISGenericRepository<Products>();
        }

        public List<ProductsDto> getProducts(int LoadType)
        {
            return new InventoryGenericRepository<ProductsDto>().FindUsingSP("getProducts @LoadType",
                new SqlParameter("@LoadType", LoadType));
        }

    }
}