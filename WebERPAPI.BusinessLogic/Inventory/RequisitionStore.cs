using System;
using System.Collections.Generic;
using WebERPAPI.Classes;
using WebERPAPI.Classes.Inventory.Store;
using WebERPAPI.Data.Inventory;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.BusinessLogic.Inventory
{
    public class RequisitionStore
    {
        public Exception Error = new Exception();
        private RequisitionStoreRepositories repo = new RequisitionStoreRepositories();

        public List<Store_Item_Groups> getStoreGroupList()
        {
            return repo.getStoreGroupList();
        }

        public Store_Item_Groups saveStoreItemGroup(CommonDataEntryClass Data)
        {
            return repo.saveStoreItemGroup(Data);
        }

        public Store_Item_Groups deleteStoreGroupItem(int ID, string EmployeeID)
        {
            return repo.deleteStoreGroupItem(ID, EmployeeID);
        }

        public Store_ItemMaster saveStoreItem(StoreItemNew Data)
        {
            return repo.saveStoreItem(Data);
        }
    }
}