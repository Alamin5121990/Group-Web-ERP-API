using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class UOMDto
    {
        public int ID { get; set; }
        public string UOM { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}