using System;
using System.Collections.Generic;
using WebERPAPI.DTO;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.BusinessLogic.Interfaces
{
    public interface IItemStock
    {
        List<InventoryItemStockDto> getItemStock(int StoreID, int MainGroupID, int ItemID, string SearchText);

        List<ItemStockUpdateHistoryDto> getItemStockUpdateHistory(int StoreID, int ItemID);

        Boolean saveItemOpeningStock(BaseEntityNew Data);

        List<ItemOpeningStockDto> getItemOpeningStock(int StoreID, int SubGroupID);
    }
}