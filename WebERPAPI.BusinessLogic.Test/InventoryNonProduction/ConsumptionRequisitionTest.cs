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
    /// Summary description for ConsumptionRequisitionTest
    /// </summary>
    [TestClass]
    public class ConsumptionRequisitionTest
    {
        private ConsumptionRequisition service = new ConsumptionRequisition();

        private string EmployeeID = "LPL02693";
        private int RequisitionID = 2;

        public ConsumptionRequisitionTest()
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
        public void saveConsumptionRequisitionTest()
        {
            List<Consumption_Requisition_Items> items = new List<Consumption_Requisition_Items>();
            Consumption_Requisition_Items item = new Consumption_Requisition_Items();

            item.ItemID = 20;
            item.Quantity = 10;

            items.Add(item);

            string jsonstr = Library.JSONSerialize.ObjectToJSONText(items);
            string itemInBase64 = Library.JSONSerialize.EncodeBase64(jsonstr);

            ConsumptionRequisitionNew Data = new ConsumptionRequisitionNew();

            Data.MainGroupID = 22;
            Data.StoreID = 1;

            Data.CreatedByID = "LPL02693";
            Data.Remarks = "CREATED BY UNIT TEST";
            Data.Data = itemInBase64;

            // CREATE REQUISITION
            Consumption_Requisitions newRequisition = service.saveRequisition(Data);
            Assert.IsNotNull(newRequisition, service.Error.Message);
        }

        [TestMethod]
        public void getRequisitionsApprovalPendingTest()
        {
            List<ConsumptionRequisitionsApprovalPendingNPDto> stores = service.getRequisitionsApprovalPending(EmployeeID);
            Assert.IsNotNull(stores, service.Error.Message);
            Assert.IsTrue(stores.Count > 0, service.Error.Message);
        }

        [TestMethod]
        public void getRequisitionReportTest()
        {
            ConsumptionRequisitionNPDto requisition = service.getRequisition("0", RequisitionID);
            Assert.IsNotNull(requisition, service.Error.Message);

            List<ConsumptionRequisitionDetailsNPDto> details = service.getRequisitionDetails(RequisitionID);
            Assert.IsNotNull(details, service.Error.Message);
            Assert.IsTrue(details.Count > 0, service.Error.Message);
        }

        [TestMethod]
        public void updateRequisitionStatusTest()
        {
            CommonDataEntryClass Data = new CommonDataEntryClass();

            Data.ActionGroupID = ActionGroup.APPROVED;
            Data.ID = 2;
            Data.EmployeeCode = EmployeeID;
            Data.Remarks = "APPROVED BY UNIT TEST";

            Consumption_Requisitions requisitions = service.updateRequisitionStatus(Data);
            Assert.IsNotNull(requisitions, service.Error.Message);
        }
    }
}