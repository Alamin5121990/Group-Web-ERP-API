using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.ComparativeStudyNP;
using WebERPAPI.DTO.Inventory.PurchaseOrdersNP;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.BusinessLogic.Test
{
    /// <summary>
    /// Summary description for PurchaseOrdersNPTest
    /// </summary>
    [TestClass]
    public class PurchaseOrdersNPTest
    {
        private string EmployeeID = "LPL02693";
        private int QuotationID = 0;
        private int RequisitionID = 0;
        private int MainGroupID = 0;
        private int CSID = 4;

        private PurchaseOrderNP service = new PurchaseOrderNP();

        public PurchaseOrdersNPTest()
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
        public void savePurchaseOrder()
        {
            List<Inventory_Purchase_Order_Detail> items = new List<Inventory_Purchase_Order_Detail>();
            Inventory_Purchase_Order_Detail item = new Inventory_Purchase_Order_Detail();

            item.RequisitionID = 15;
            item.ItemID = 22; //Mouse (USB)
            item.Quantity = 1;
            item.Rate = 3000;
            item.VATPercent = 0.15M;
            item.OrderNo = 1;

            items.Add(item);

            string jsonstr = Library.JSONSerialize.ObjectToJSONText(items);
            string itemInBase64 = Library.JSONSerialize.EncodeBase64(jsonstr);

            PurchaseOrderNPNew Data = new PurchaseOrderNPNew();

            Data.MainGroupID = 22;
            Data.RequiredDate = DateTime.Now.AddDays(7);
            Data.SupplierCode = "S-0693";
            Data.ManufacturerCode = "";
            Data.BillPaymentTypeID = 1;

            Data.TermsAndConditions = "UNIT TEST TERMS AND CONDITION";

            Data.EmployeeCode = "LPL02693";
            Data.Remarks = "CREATED BY UNIT TEST";
            Data.Data = itemInBase64;

            // CREATE PO
            Inventory_Purchase_Orders newPO = service.savePurchaseOrder(Data);
            Assert.IsNotNull(newPO, service.Error.Message);

            // VERIFY PO
            CommonDataEntryClass cancelPO = new CommonDataEntryClass();

            cancelPO.ActionGroupID = ActionGroup.VERIFIED;
            cancelPO.ID = newPO.ID;
            cancelPO.EmployeeCode = "LPL02693";
            cancelPO.Remarks = "VERIFIED BY UNIT TEST";

            Inventory_Purchase_Orders canceledCS = service.updatePurchaseOrderStatus(cancelPO);
            Assert.IsNotNull(canceledCS, service.Error.Message);

            // CLOSE
            cancelPO.ActionGroupID = ActionGroup.CLOSED;
            cancelPO.ID = newPO.ID;
            cancelPO.EmployeeCode = "LPL02693";
            cancelPO.Remarks = "CLOSED BY UNIT TEST";

            canceledCS = service.updatePurchaseOrderStatus(cancelPO);
            Assert.IsNotNull(canceledCS, service.Error.Message);

            // CANCEL
            cancelPO.ActionGroupID = ActionGroup.CANCELED;
            cancelPO.ID = newPO.ID;
            cancelPO.EmployeeCode = "LPL02693";
            cancelPO.Remarks = "CANCELED BY UNIT TEST";

            canceledCS = service.updatePurchaseOrderStatus(cancelPO);
            Assert.IsNotNull(canceledCS, service.Error.Message);

            // QUOTATION DETAILS
            //var requisitionDetails = service.getRequisitionDetails(requisition.ID);
            //Assert.IsNotNull(requisitionDetails, service.Error.Message);
        }

        [TestMethod]
        public void getComparativeStudySuppliersNP()
        {
            List<ComparativeStudySuppliersNP> suppliers = service.getComparativeStudySuppliersNP(EmployeeID);
            Assert.IsNotNull(suppliers, service.Error.Message);
            Assert.IsTrue(suppliers.Count > 0, service.Error.Message);
        }

        [TestMethod]
        public void getComparativeStudyForPurchaseNP()
        {
            MainGroupID = 22;
            List<ComparativeStudyForPurchaseNP> suppliers = service.getComparativeStudyForPurchaseNP(MainGroupID, "S-0000");
            Assert.IsNotNull(suppliers, service.Error.Message);
        }

        [TestMethod]
        public void getComparativeStudyItemsForPurchaseOrder()
        {
            CSID = 4;
            List<ComparativeStudyItemsForPurchaseOrderNP> items = service.getComparativeStudyItemsForPurchaseOrder(CSID, "S-0693");
            Assert.IsNotNull(items, service.Error.Message);
        }
    }
}