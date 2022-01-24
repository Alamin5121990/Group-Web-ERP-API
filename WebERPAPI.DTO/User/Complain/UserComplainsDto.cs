using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.User.Complain
{
    public class UserComplainsDto
    {
        public Nullable<int> ID { get; set; }
        public string ComplainTypeName { get; set; }

        public string Details { get; set; }
        public string Recepients { get; set; }
        public string ImageFileName { get; set; }
        public Nullable<Boolean> IsSolved { get; set; }
        public Nullable<DateTime> SolvedOn { get; set; }
        public string SolvedBy { get; set; }

        public string CreatedBy { get; set; }
    }
}