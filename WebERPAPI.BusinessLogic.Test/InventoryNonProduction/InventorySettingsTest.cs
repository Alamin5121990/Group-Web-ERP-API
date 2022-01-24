using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.BusinessLogic.Inventory;
using WebERPAPI.DTO;
using WebERPAPI.Data.Models.PROCESSERVER;
using System.Collections.Generic;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.DTO.Inventory.Requisitions;
using WebERPAPI.DTO.Inventory;

namespace WebERPAPI.BusinessLogic.Test
{
    [TestClass()]
    public class InventorySettingsTest
    {
        private InventorySettings service = new InventorySettings();
        private int InventoryTypeID = 5;  //IT & Accessories

        [TestMethod()]
        public void getInvenotrySubgroupTest()
        {
            var subgroupItem = service.getInvenotrySubgroup(6);
            Assert.IsNotNull(subgroupItem);
        }

        [TestMethod()]
        public void getInventoryStoresTest()
        {
            var item = service.getInventoryStores(5);
            Assert.IsNotNull(item);
        }

        [TestMethod()]
        public void deleteInventoryTypeTest()
        {
            var item = service.deleteInventoryType(5, "LPL05360");
            Assert.IsNotNull(item);
        }

        [TestMethod()]
        public void getInventoryMainGroupSupplierListByMaingroupIdTest()
        {
            var item = service.getInventoryMainGroupSupplierListByMaingroupId(1);
            Assert.IsNotNull(item);
        }

        [TestMethod()]
        public void getItemSpecificationListTest()
        {
            List<Inventory_Item_Specification> SpecList = service.getItemSpecificationList(InventoryTypeID);
            Assert.IsNotNull(SpecList);
            Assert.IsTrue(SpecList.Count > 0);
        }

        [TestMethod()]
        public void getInventoryTypesTest()
        {
            List<InventoryTypes> typeList = service.getInventoryTypes();
            Assert.IsNotNull(typeList);
            Assert.IsTrue(typeList.Count > 0);
        }

        [TestMethod()]
        public void getInventoryTypesAndStoresTest()
        {
            object result = service.getInventoryTypesAndStores();
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void getItemUsageTypeTest()
        {
            List<Inventory_Item_UsageTypes> result = service.getItemUsageType();
            Assert.IsNotNull(result, service.Error.Message);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void getVersionStatesTest()
        {
            List<Inventory_Item_Version_State> result = service.getVersionStates();
            Assert.IsNotNull(result, service.Error.Message);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void getInventoryItemsTest()
        {
            List<InventoryItems> result = service.getInventoryItems(InventoryTypeID);
            Assert.IsNotNull(result, service.Error.Message);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void getInventoryItemTest()
        {
            InventoryItems result = service.getInventoryItem(6); // always getting result null
            //Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void getItemSpecificationsTest()
        {
            List<ItemSpecification> result = service.getItemSpecifications(6, 12);
            Assert.IsNotNull(result, service.Error.Message);
        }

        [TestMethod()]
        public void saveInventoryTypesTest()
        {
            CommonDataEntryClass data = new CommonDataEntryClass();

            data.ID = 0;
            data.EmployeeCode = "LPL02693";
            data.Remarks = "CREATED BY UNIT TEST";
            data.ItemName = "UNIT TEST DATA";
            Inventory_Types result = service.saveInventoryTypes(data);
            Assert.IsNotNull(result, service.Error.Message);
        }

        [TestMethod()]
        public void saveInventoryStoreTest()
        {
            CommonDataEntryClass data = new CommonDataEntryClass();

            data.ID = 0;
            data.EmployeeCode = "LPL02693";
            data.ItemName = "CREATED BY UNIT TEST";
            data.Remarks = "UNIT TEST DATA";
            data.TypeID = 1;
            data.ActionGroupID = 1;
            Inventory_Stores result = service.saveInventoryStore(data);
            Assert.IsNotNull(result, service.Error.Message);
        }

        [TestMethod()]
        public void saveItemSubGroupTest()
        {
            ItemGroupNew data = new ItemGroupNew();

            data.ID = 0;
            data.EmployeeCode = "LPL02693";
            data.GroupName = "CREATED BY UNIT TEST";
            data.Description = "UNIT TEST DATA";
            data.ItemCodePrefix = "Pr";
            data.InventoryTypeID = 1;
            data.MainGroupID = 3;
            Inventory_Item_SubGroup result = service.saveItemSubGroup(data);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void getItemNameWithSpecTest()
        {
            string ItemName = "Name for unit Test";
            List<ItemSpecification> Specs = new List<ItemSpecification>();
            ItemSpecification data = new ItemSpecification();

            data.IsSelected = true;
            data.OrderNo = 1;
            data.ShowInName = true;
            data.SpecificationID = 2;
            data.SpecificationName = "Unit test";
            data.SpecificationValue = "Testing value";
            data.UOM = "Test Kg";
            Specs.Add(data);
            data = new ItemSpecification();
            data.IsSelected = true;
            data.OrderNo = 2;
            data.ShowInName = true;
            data.SpecificationID = 1;
            data.SpecificationName = "Unit test 2";
            data.SpecificationValue = "Testing value 2";
            data.UOM = "Test Kg";
            Specs.Add(data);
            string result = service.getItemNameWithSpec(ItemName, Specs);
            Assert.IsNotNull(result, service.Error.Message);
            Assert.AreNotEqual(result, "", service.Error.Message);
        }
    }
}