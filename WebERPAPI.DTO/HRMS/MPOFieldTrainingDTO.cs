using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.HRMS
{
  public class MPOFieldTrainingDTO
    {
        public string ApplicantName { get; set; }

        public Nullable<int> Id { get; set; }
        public string SupervisorName { get; set; }
        public string SupervisorMobile { get; set; }
        public string SupervisorRegionName { get; set; }
        public string SupervisorDesignation { get; set; }
        public Nullable<int> PresentMPOId { get; set; }


        public List<MPOFieldTrainingDTO> mPOFieldTrainings { get; set; }

    }
}
