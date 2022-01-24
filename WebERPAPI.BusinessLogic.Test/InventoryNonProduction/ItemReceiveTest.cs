using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.BusinessLogic.Test.InventoryNonProduction
{
    /// <summary>
    /// Summary description for ItemReceiveTest
    /// </summary>
    [TestClass]
    public class ItemReceiveTest
    {
        private ItemIssueService service = new ItemIssueService();

        public ItemReceiveTest()
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
        public void saveItemReceive()
        {
            List<Inventory_ItemReceive_Details> items = new List<Inventory_ItemReceive_Details>();
            Inventory_ItemReceive_Details item = new Inventory_ItemReceive_Details();

            item.ItemReceiveID = 1;
            item.IssueID = 1;
            item.RequisitionID = 1;
            item.ItemID = 1;
            item.Quantity = 1.0M;
            item.IsActive = true;
            item.CreatedByID = "LPL02693";
            item.CreatedOn = DateTime.Now;

            items.Add(item);

            string jsonstr = Library.JSONSerialize.ObjectToJSONText(items);
            string itemInBase64 = Library.JSONSerialize.EncodeBase64(jsonstr);

            ItemReceiveAcknowledgementNewDto newReceive = new ItemReceiveAcknowledgementNewDto();

            newReceive.IssueID = 1;
            newReceive.IsActive = true;
            newReceive.CreatedOn = DateTime.Now;
            newReceive.CreatedByID = "LPL02693";
            newReceive.Data = itemInBase64;
            newReceive.Remarks = "UNIT TEST";

            Inventory_ItemReceive_Acknowledgement result = service.saveItemReceive(newReceive);
            Assert.IsNotNull(result, service.Error.Message);
        }
    }
}