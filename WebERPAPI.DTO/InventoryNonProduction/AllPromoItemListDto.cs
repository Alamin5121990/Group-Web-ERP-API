using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class AllPromoItemListDto
    {
        public Nullable<int> InventoryTypeID { get; set; }

        public string TypeName { get; set; }
        public Nullable<int> MaingroupID { get; set; }
        public string MainGroupName { get; set; }
        public Nullable<int> SubgroupID { get; set; }
        public string SubGroupName { get; set; }

        public Nullable<int> ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }
        public string UOM { get; set; }

        public Nullable<decimal> TotalReceiveQty { get; set; }
        public Nullable<decimal> TotalAllocationQty { get; set; }
        public Nullable <decimal> AvailableStockQty { get; set; }
        public Nullable<decimal> TotalChallanQty { get; set; }
        public Nullable<decimal> BookedTotal { get; set; }
        public Nullable<decimal> StockQty { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string StoreName { get; set; }
    }

    public class AllPromoItemListWithTerritoryListDto
    {
        public Nullable<int> InventoryTypeID { get; set; }

        public string TypeName { get; set; }
        public Nullable<int> MaingroupID { get; set; }
        public string MainGroupName { get; set; }
        public Nullable<int> SubgroupID { get; set; }
        public string SubGroupName { get; set; }

        public Nullable<int> ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }
        public string UOM { get; set; }

        public Nullable<int> StockQty { get; set; }
        public bool IsSelected { get; set; } = false;
        public List<AllAreaWiseZoneRegionTerritoryDto> TerritoryList = new List<AllAreaWiseZoneRegionTerritoryDto>();
    }

    public class AllPromoItemAllocationHistoryDto
    {
        public string AllocationCode { get; set; }

        public string AllocationCycle { get; set; }
        public Nullable<int> AllocationMonth { get; set; }
        public Nullable<int> AllocationYear { get; set; }
        public string AllocationType { get; set; }

        public Nullable<int> PromoID { get; set; }
        public Nullable<int> ID { get; set; }
        public Nullable<decimal> TotalAllocationQty { get; set; }
    }
}