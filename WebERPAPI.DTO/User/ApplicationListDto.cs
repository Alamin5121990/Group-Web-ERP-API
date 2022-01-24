using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.User
{
    public class ApplicationListDto
    {
        public int ID { get; set; }
        public string ApplicationName { get; set; }
        public string ShortName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CurrentVersion { get; set; }
        public string NextVersion { get; set; }
        public string CreatedBy { get; set; }
    }
}