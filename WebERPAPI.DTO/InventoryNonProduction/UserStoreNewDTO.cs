using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class UserStoreNewDTO
    {
        public string EmployeeCode { get; set; }
        public int StoreID { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsIncharge { get; set; }
        public string CreatedByID { get; set; }
    }
}