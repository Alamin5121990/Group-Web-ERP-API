using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.Data.Repository.InventoryNonProduction
{
    public class ItemStockRepository
    {
     
        public List<InventoryItemStockDto> getItemStock(int StoreID, int MainGroupID, int ItemID, string SearchText)
        {
            return new NonProductionGenericRepository<InventoryItemStockDto>().FindUsingSP("getInventoryItemStock @StoreID, @MainGroupID, @ItemID, @SearchText",
                new SqlParameter("@StoreID", StoreID), new SqlParameter("@MainGroupID", MainGroupID)
                , new SqlParameter("@ItemID", ItemID), new SqlParameter("@SearchText", SearchText));
        }

        public List<InventoryItemStockTransferDto> getItemStockList(int StoreID, int MainGroupID)
        {
            return new NonProductionGenericRepository<InventoryItemStockTransferDto>().FindUsingSP("getInventoryItemStockAll @StoreID, @MainGroupID",
                new SqlParameter("@StoreID", StoreID), new SqlParameter("@MainGroupID", MainGroupID));
        }

        public List<Inventory_Stock> TransferItemStock(int SourceStoreID, int DestinationStoreID, int ItemID, decimal TransferQty, string EmployeeID)
        {
            return new NonProductionGenericRepository<Inventory_Stock>().FindUsingSP("TransferItemStock @SourceStoreID, @DestinationStoreID, @ItemID, @TransferQty, @EmployeeID",
                new SqlParameter("@SourceStoreID", SourceStoreID), new SqlParameter("@DestinationStoreID", DestinationStoreID),
                new SqlParameter("@ItemID", ItemID), new SqlParameter("@TransferQty", TransferQty),
                new SqlParameter("@EmployeeID", EmployeeID));
        }

        public Inventory_Stock_InTransit saveStockTransit(Inventory_Stock_InTransit item)
        {
            return new ProcurementGenericRepository<Inventory_Stock_InTransit>().Insert(item);
        }

        public Inventory_Stock_InTransit getItemStockTransit(int ID)
        {
            return new ProcurementGenericRepository<Inventory_Stock_InTransit>().Find(i => i.ID == ID).FirstOrDefault();
        }

        public Inventory_Stock_InTransit updateStockTransit(Inventory_Stock_InTransit item)
        {
            return new ProcurementGenericRepository<Inventory_Stock_InTransit>().Update(item, i => i.ID == item.ID);
        }

        public List<TransitItemListDto> getStockTransitList(int SourceStoreID)
        {
            return new ProcurementGenericRepository<TransitItemListDto>().FindUsingSP("getInventoryItemStockReceiveList @StoreID",
                new SqlParameter("@StoreID", SourceStoreID));
        }

        public Inventory_Stock getItemStock(int storeId, int ItemId)
        {
            return new NonProductionGenericRepository<Inventory_Stock>().FindOne(i => i.StoreID == storeId && i.ItemID == ItemId);
        }

        public List<ItemStockUpdateHistoryDto> getItemStockUpdateHistory(int StoreID, int ItemID)
        {
            return new NonProductionGenericRepository<ItemStockUpdateHistoryDto>().FindUsingSP("getInventoryItemStockUpdateHistory @StoreID, @ItemID",
                new SqlParameter("@StoreID", StoreID), new SqlParameter("@ItemID", ItemID));
        }

      
        // SAVE
        public Inventory_Stock_Opening saveInventoryStockOpening(Inventory_Stock_Opening Entity)
        {
            //Entity.IsActive = true;
            Entity.CreatedOn = DateTime.Now;
            return new ProcurementGenericRepository<Inventory_Stock_Opening>().Insert(Entity);
        }

        //update
        public Inventory_Stock_Opening updateInventoryStockOpening(Inventory_Stock_Opening Entity)
        {
            return new ProcurementGenericRepository<Inventory_Stock_Opening>().Update(Entity, e => e.ID == Entity.ID);
        }


        // Find One
        public Inventory_Stock_Opening getItemStockOpening(int StoreID, int ItemID)
        {
            return new ProcurementGenericRepository<Inventory_Stock_Opening>().FindOne(I => I.StoreID == StoreID && I.ItemID == ItemID);
        }

    }
}