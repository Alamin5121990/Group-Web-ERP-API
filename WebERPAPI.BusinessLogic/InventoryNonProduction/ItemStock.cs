using System;
using System.Collections.Generic;
using WebERPAPI.BusinessLogic.Interfaces;
using WebERPAPI.BusinessLogic.Map;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.Inventory;
using WebERPAPI.Data.Repository.InventoryNonProduction;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.DTO.InventoryNonProduction;
using WebERPAPI.Library;

namespace WebERPAPI.BusinessLogic.InventoryNonProduction
{
    public class ItemStock 
    {
        public Exception Error = new Exception();
        private ItemStockRepository repo = new ItemStockRepository();

        public List<InventoryItemStockDto> getItemStock(int StoreID, int MainGroupID, int ItemID, string SearchText)
        {
            try
            {
                return repo.getItemStock(StoreID, MainGroupID, ItemID, SearchText);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<Inventory_Stock_InTransit> ItemStockTransfer(List<InventoryItemStockTransferDto> list)
        {
            try
            {
                //save in transit table
                // Inventory_Stock_InTransit
                List<Inventory_Stock_InTransit> transitList = new List<Inventory_Stock_InTransit>();
                foreach (var item in list)
                {
                    if (item.SourceStoreId != null && item.DestinationStoreId != null && item.TransferQty != null && item.TransferQty > 0 && item.TransferQty <= item.Quantity)
                    {
                        Inventory_Stock_InTransit transit = new Inventory_Stock_InTransit();
                        transit.CreatedById = item.CreatedById;
                        transit.CreatedOn = DateTime.Now;
                        transit.DestinationStoreID = Convert.ToInt32(item.DestinationStoreId);
                        transit.SourceStoreID = Convert.ToInt32(item.SourceStoreId);
                        transit.TransferQty = item.TransferQty;
                        transit.ItemID = item.ItemID;
                        transit.IsReceived = false;
                        transitList.Add(repo.saveStockTransit(transit));
                    }
                }

                return transitList;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<TransitItemListDto> getStockTransitList(int SourceStoreID)
        {
            try
            {
                return repo.getStockTransitList(SourceStoreID);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<Inventory_Stock> itemStockReceive(int TransditID, string EmployeeId)
        {
            try
            {
                Inventory_Stock_InTransit inTransit = repo.getItemStockTransit(TransditID);
                if (inTransit == null) throw new Exception("Transfer data not found.");

                List<Inventory_Stock> StockList = new List<Inventory_Stock>();

                List<Inventory_Stock> BothStock = repo.TransferItemStock(Convert.ToInt32(inTransit.SourceStoreID), Convert.ToInt32(inTransit.DestinationStoreID), Convert.ToInt32(inTransit.ItemID), Convert.ToDecimal(inTransit.TransferQty), EmployeeId);

                foreach (var stock in BothStock)
                {
                    StockList.Add(stock);
                }

                if (StockList.Count == 2)
                {
                    inTransit.IsReceived = true;
                    inTransit.ReceivedById = EmployeeId;
                    inTransit.ReceivedOn = DateTime.Now;
                    repo.updateStockTransit(inTransit);
                }
                else
                {
                    throw new Exception("Unable to update stock, please see log.");
                }

                return StockList;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<InventoryItemStockTransferDto> getItemStockList(int StoreID, int MainGroupID)
        {
            try
            {
                return repo.getItemStockList(StoreID, MainGroupID);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<ItemStockUpdateHistoryDto> getItemStockUpdateHistory(int StoreID, int ItemID)
        {
            try
            {
                return repo.getItemStockUpdateHistory(StoreID, ItemID);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

      
    }
}