using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.HRMS
{
    public class MPOSupervisorDTO
    {
        public string SupervisorEmployeeID { get; set; }

        public string SupervisorEmployeeName { get; set; }
        public string SupervisorMobile { get; set; }
        public string SupervisorRegion { get; set; }
        public string SupervisorRegionName { get; set; }
        public string SupervisorDesignation { get; set; }

    }
    public class MPOCodeGeneratorDTO
    {
        public string PresentMPOId { get; set; }

    }
}
