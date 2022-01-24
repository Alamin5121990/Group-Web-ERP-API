using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.BusinessLogic.Test.InventoryNonProduction
{
    /// <summary>
    /// Summary description for ItemIssueTest
    /// </summary>
    [TestClass]
    public class ItemIssueTest
    {
        private ItemIssueService service = new ItemIssueService();
        private int RequisitionID = 4;

        public ItemIssueTest()
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

        [TestMethod]
        public void saveItemIssueTest()
        {
            List<Inventory_ItemIssue_Details> items = new List<Inventory_ItemIssue_Details>();
            Inventory_ItemIssue_Details item = new Inventory_ItemIssue_Details();

            item.RequisitionID = 4;
            item.ItemID = 20;
            item.Quantity = 10;
            item.StoreID = 10;

            items.Add(item);

            string jsonstr = Library.JSONSerialize.ObjectToJSONText(items);
            string itemInBase64 = Library.JSONSerialize.EncodeBase64(jsonstr);

            ItemIssuesNewDto Data = new ItemIssuesNewDto();

            Data.CreatedByID = "LPL02693";
            Data.Remarks = "CREATED BY UNIT TEST";
            Data.MainGroupID = 22;
            Data.StoreID = 10;
            Data.Data = itemInBase64;

            // CREATE Issue new
            Inventory_ItemIssues newIssue = service.saveItemIssue(Data);
            Assert.IsNotNull(newIssue, service.Error.Message);
        }

        [TestMethod]
        public void getItemIssueNew()
        {
            object itemIssueNew = service.getItemIssueNew(RequisitionID);
            Assert.IsNotNull(itemIssueNew, service.Error.Message);
        }
    }
}