using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.Employee
{
    public class UserLocationDto
    {
        public string LocationID { get; set; }

        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string LocationType { get; set; }
    }
}
