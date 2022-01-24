using System;

namespace WebERPAPI.DTO
{
    public class BaseEntityNew
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string ItemName { get; set; }
        public string Data { get; set; }
        public string EmployeeCode { get; set; }
        public string Remarks { get; set; }
        public decimal Quantity { get; set; }
        public int TypeID { get; set; }
        public int ActionGroupID { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public string CreatedByID { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string UpdatedByID { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
    }
}