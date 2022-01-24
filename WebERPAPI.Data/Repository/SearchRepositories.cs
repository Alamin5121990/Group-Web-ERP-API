using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.Inventory;
using WebERPAPI.Library;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.DTO.User;

namespace WebERPAPI.Data.Repository
{
    public class SearchRepositories
    {
        #region GolobalSearchRepo

        public List<Supplier> getGlobalSearchSupplierResult(string SearchType, string SearchText)
        {
            return new NonProductionGenericRepository<Supplier>().FindUsingSP("getGlobalSearchResult @SearchType, @SearchText", new SqlParameter("@SearchType", SearchType), new SqlParameter("@SearchText", SearchText)).ToList();
        }

        public List<MaterialGlobalSearchResultDto> getGlobalSearchSMaterialResult(string SearchType, string SearchText)
        {
            return new NonProductionGenericRepository<MaterialGlobalSearchResultDto>().FindUsingSP("getGlobalSearchResult @SearchType, @SearchText", new SqlParameter("@SearchType", SearchType), new SqlParameter("@SearchText", SearchText)).ToList();
        }

        public List<Inventory_Items> getGlobalSearchSInventoryItemsResult(string SearchType, string SearchText)
        {
            return new NonProductionGenericRepository<Inventory_Items>().FindUsingSP("getGlobalSearchResult @SearchType, @SearchText", new SqlParameter("@SearchType", SearchType), new SqlParameter("@SearchText", SearchText)).ToList();
        }

        public List<Employee> getGlobalSearchEmployeeResult(string SearchType, string SearchText)
        {
            return new NonProductionGenericRepository<Employee>().FindUsingSP("getGlobalSearchResult @SearchType, @SearchText", new SqlParameter("@SearchType", SearchType), new SqlParameter("@SearchText", SearchText)).ToList();
        }

        #endregion GolobalSearchRepo

        public List<Supplier> getSearchResultSupplier(string SearchWord1, string SearchWord2, string SearchWord3)
        {
            using (InventoryEntities db = new InventoryEntities())
            {
                var entityName = new SqlParameter("@SearchText", "SUPPLIER");
                var searchWord1 = new SqlParameter("@SearchWord1", SearchWord1);
                var searchWord2 = new SqlParameter("@SearchWord2", SearchWord2);
                var searchWord3 = new SqlParameter("@SearchWord3", SearchWord3);

                return db.Database.SqlQuery<Supplier>("getSearchResult @EntityName, @SearchWord1, @SearchWord2, @SearchWord3", entityName, searchWord1, searchWord2, searchWord3).ToList();
            }
        }

        public List<Material> getSearchResultMaterial(string SearchWord1, string SearchWord2, string SearchWord3)
        {
            using (InventoryEntities db = new InventoryEntities())
            {
                var entityName = new SqlParameter("@SearchText", "MATERIAL");
                var searchWord1 = new SqlParameter("@SearchWord1", SearchWord1);
                var searchWord2 = new SqlParameter("@SearchWord2", SearchWord2);
                var searchWord3 = new SqlParameter("@SearchWord3", SearchWord3);

                return db.Database.SqlQuery<Material>("getSearchResult @EntityName, @SearchWord1, @SearchWord2, @SearchWord3", entityName, searchWord1, searchWord2, searchWord3).ToList();
            }
        }

        public SingleValueString getSearchEntityName(string EmployeeID, string SearchWord1, string SearchWord2, string SearchWord3)
        {
            var employeeID = new SqlParameter("@EmployeeID", EmployeeID);
            var searchWord1 = new SqlParameter("@SearchWord1", SearchWord1);
            var searchWord2 = new SqlParameter("@SearchWord2", SearchWord2);
            var searchWord3 = new SqlParameter("@SearchWord3", SearchWord3);

            using (InventoryEntities db = new InventoryEntities())
            {
                return db.Database.SqlQuery<SingleValueString>("getSearchEntityName @EmployeeID, @SearchWord1, @SearchWord2, @SearchWord3", employeeID, searchWord1, searchWord2, searchWord3).FirstOrDefault();
            }
        }

        public SearchTag getSearchTag(string SearchText)
        {
            var tag = new SqlParameter("@SearchText", SearchText);
            using (InventoryEntities db = new InventoryEntities())
            {
                return db.Database.SqlQuery<SearchTag>("getSearchTag @SearchText", tag).FirstOrDefault();
            }
        }
    }
}