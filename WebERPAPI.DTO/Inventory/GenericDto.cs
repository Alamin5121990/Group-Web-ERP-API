using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.Inventory
{
    public class GenericDto
    {
        public Nullable<int> ID { get; set; }

        public string GenericName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsLabaidGeneric { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
    }

    public class BrandListDto
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> GenericID { get; set; }
        public string BrandName { get; set; }
        public string Decription { get; set; }
        public Nullable<int> BrandPriorityID { get; set; }
        public string PriorityName { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
        public Nullable<int> StateID { get; set; }
        public string StateName { get; set; }
        public string GenericName { get; set; }

        public bool IsSelected { get; set; }
        public Nullable<int> BrandID { get; set; }
        public string AssignedExecutiveID { get; set; }
        public Nullable<DateTime> AssignedOn { get; set; }
        public string AssignedByID { get; set; }
    }
}