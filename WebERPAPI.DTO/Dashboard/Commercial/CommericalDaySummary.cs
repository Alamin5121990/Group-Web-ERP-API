using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO.Dashboard.Commercial
{
    public class CommericalDaySummary
    {
        public string Section { get; set; }

        public string Code { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<int> OrderNo { get; set; }
    }

    public class CommericalDaySummaryReport
    {
        public string Section { get; set; }
        public List<CommericalDaySummary> Summary { get; set; }
    }
}