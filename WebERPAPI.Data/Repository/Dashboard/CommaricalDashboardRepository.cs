using System.Collections.Generic;
using System.Data.SqlClient;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.DTO.Dashboard.Commercial;

namespace WebERPAPI.Data.Repository.Dashboard
{
    public class CommaricalDashboardRepository
    {
        public List<CommericalDaySummary> getDaySummary(int EmployeeID, string ReportDate)
        {
            return new SystemManagerGenericRepository<CommericalDaySummary>().FindUsingSP("getDashboardCommercial @EmployeeID, @ReportDate",
                new SqlParameter("@EmployeeID", EmployeeID), new SqlParameter("@ReportDate", ReportDate));
        }
    }
}