using System;
using System.Collections.Generic;
using WebERPAPI.Data.Repository.Dashboard;
using WebERPAPI.DTO.Dashboard.Commercial;
using System.Linq;

namespace WebERPAPI.BusinessLogic.Dashboard
{
    public class CommercialDashboardService
    {
        public Exception Error = new Exception();
        private CommaricalDashboardRepository repo = new CommaricalDashboardRepository();

        public List<CommericalDaySummaryReport> getDaySummary(int EmployeeID, string ReportDate)
        {
            try
            {
                List<CommericalDaySummary> data = repo.getDaySummary(EmployeeID, ReportDate);
                var sections = from s in data
                               group s by s.Section into gs
                               select gs.FirstOrDefault().Section;

                List<CommericalDaySummaryReport> report = new List<CommericalDaySummaryReport>();

                foreach (string section in sections)
                {
                    CommericalDaySummaryReport rpt = new CommericalDaySummaryReport();

                    rpt.Section = section;
                    var summary = data.Where(s => s.Section == section);
                    if (summary != null)
                    {
                        rpt.Summary = new List<CommericalDaySummary>();

                        rpt.Summary.AddRange(summary);
                    }

                    report.Add(rpt);
                }

                return report;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }
    }
}