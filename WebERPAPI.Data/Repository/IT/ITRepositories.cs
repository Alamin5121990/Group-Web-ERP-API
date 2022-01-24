using System;
using System.Collections.Generic;
using System.Linq;
using WebERPAPI.DTO.IT;
using WebERPAPI.Data.Models.MIS;

namespace WebERPAPI.Data.Repository.IT
{
    public class ITRepositories
    {
        public Exception error = new Exception();

        public MISCorrectionReport getDataCorrectionReport()
        {
            try
            {
                using (MISEntities db = new MISEntities())
                {
                    return db.Database.SqlQuery<MISCorrectionReport>("_getDataCorrectionReport").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<RequestStatistics> getErrorLogsTodaysTotal()
        {
            try
            {
                using (MaintenanceEntities db = new MaintenanceEntities())
                {
                    return db.Database.SqlQuery<RequestStatistics>("getErrorLogsTodaysTotal").ToList();
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