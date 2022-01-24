using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class InventoryAllItemListAndSearchDto
    {
        public Nullable<int> ID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public string UOM { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> SubGroupId { get; set; }
        public string SubGroupName { get; set; }
        public Nullable<int> MainGroupID { get; set; }
        public string MainGroupName { get; set; }
        public string CreatedByID { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
    }

    public class InventoryItemListSearchPostDto
    {
        public int InventoryTypeID { get; set; }
        public int MainGroupID { get; set; }
        public int SubGroupID { get; set; }
        public string SearchText { get; set; }
    }
}