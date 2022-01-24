using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.DTO.InventoryNonProduction;
using WebERPAPI.DTO;

namespace WebERPAPI.BusinessLogic.Test.InventoryNonProduction
{
    /// <summary>
    /// Summary description for ItemOpeningStockTest
    /// </summary>
    [TestClass]
    public class ItemOpeningStockTest
    {
        private ItemStock service = new ItemStock();

        public ItemOpeningStockTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion Additional test attributes

        [TestMethod()]
        public void saveInventoryStockOpeningDto()
        {
            List<Inventory_Stock_Opening> items = new List<Inventory_Stock_Opening>();
            Inventory_Stock_Opening item = new Inventory_Stock_Opening();

            item.StoreID = 1;
            item.ItemID = 1;
            item.Quantity = 1.0M;
            item.CreatedOn = DateTime.Now;
            item.CreatedByID = "LPL02693";

            items.Add(item);

            string jsonstr = WebERPAPI.Library.JSONSerialize.ObjectToJSONText(items);
            string itemInBase64 = WebERPAPI.Library.JSONSerialize.EncodeBase64(jsonstr);

            BaseEntityNew data = new BaseEntityNew();

            data.Quantity = 1.0M;
            data.CreatedOn = DateTime.Now;
            data.CreatedByID = "LPL02693";
            data.Data = itemInBase64;

            Assert.IsTrue(service.saveItemOpeningStock(data), service.Error.Message);
        }
    }
}