using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaidMIS.BL.Classes.Sales.Rank
{
    public class EmployeeBrandRankReport
    {
        public Nullable<int> BrandID { get; set; }
        public string BrandName { get; set; }

        public Nullable<int> Month1Rank { get; set; }
        public Nullable<int> Month2Rank { get; set; }
        public Nullable<int> Month3Rank { get; set; }
        public Nullable<int> Month4Rank { get; set; }
        public Nullable<int> Month5Rank { get; set; }
        public Nullable<int> Month6Rank { get; set; }

    }
}
