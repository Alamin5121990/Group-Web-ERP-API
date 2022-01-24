using System;
using System.Collections.Generic;
using WebERPAPI.Classes;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.Inventory;

namespace WebERPAPI.BusinessLogic.Inventory.QC
{
    public class RequisitionQC
    {
        public Exception Error = new Exception();
        private RequisitionQCRepositories repo = new RequisitionQCRepositories();

        public List<StoreMaster> getStores()
        {
            return repo.getStores();
        }

        public List<QC_Item_Groups> getQCItemGroupList()
        {
            return repo.getQCItemGroupList();
        }

        public Store_Item_Groups saveQCItemGroup(CommonDataEntryClass Data)
        {
            return repo.saveQCItemGroup(Data);
        }

        public Store_Item_Groups deleteQCGroupItem(int ID, string EmployeeID)
        {
            return repo.deleteQCGroupItem(ID, EmployeeID);
        }

        public Store_ItemMaster saveQCItem(QCItemNew Data)
        {
            return repo.saveQCItem(Data);
        }
    }
}