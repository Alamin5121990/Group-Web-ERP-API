using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.DTO.Inventory;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.Data.Repository.Inventory
{
    public class GRNRepositories
    {
        public Exception error = new Exception();

        public List<GRNDetailsByLC> getGRNDetailsByLC(string LCID)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    var lcid = new SqlParameter("@LCID", LCID);
                    return db.Database.SqlQuery<GRNDetailsByLC>("getGRNDetailsByLC  @LCID", lcid).ToList();
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