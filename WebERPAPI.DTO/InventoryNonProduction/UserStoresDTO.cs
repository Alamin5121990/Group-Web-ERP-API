using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class UserStoresDTO
    {
        public Nullable<int> StoreID { get; set; }
        public string StoreName { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public Nullable<Boolean> IsIncharge { get; set; }
    }
}