using System;

namespace WebERPAPI.DTO
{
    public abstract class BaseEntityDTO
    {
        public Nullable<int> ID { get; set; }
        public string CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public string Remarks { get; set; }
        public string UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
    }

    public abstract class BaseEntity2DTO
    {
        public Nullable<int> ID { get; set; }
        public string Remarks { get; set; }
        public Nullable<Boolean> IsActive { get; set; }

        public Nullable<int> CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public Nullable<int> UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
    }
}