using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.Procurement.CS;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace LabaidERP.BusinessLogic.Test
{
    /// <summary>
    /// Summary description for ComparativeStudyNPTest
    /// </summary>
    [TestClass]
    public class ComparativeStudyNPTest
    {
        private string EmployeeID = "LPL03397";
        private int QuotationID = 0;
        private int RequisitionID = 0;
        private int MainGroupID = 0;

        private ComparativeStudyNP service = new ComparativeStudyNP();

        public ComparativeStudyNPTest()
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

        // COMPARATIVE STUDY NEW

        [TestMethod()]
        public void saveComparativeStudy()
        {
            List<Inventory_Comparative_Study_Details> items = new List<Inventory_Comparative_Study_Details>();
            Inventory_Comparative_Study_Details item = new Inventory_Comparative_Study_Details();

            item.RequisitionID = 15;
            item.ItemID = 22; //Mouse (USB)
            item.Quantity = 1;
            item.SupplierCode = "S-0693";
            item.ManufacturerCode = "";
            item.Rate = 3;

            items.Add(item);

            string jsonstr = WebERPAPI.Library.JSONSerialize.ObjectToJSONText(items);
            string itemInBase64 = WebERPAPI.Library.JSONSerialize.EncodeBase64(jsonstr);

            CommonDataEntryClass Data = new CommonDataEntryClass();

            Data.EmployeeCode = "LPL02693";
            Data.Date = DateTime.Now;
            Data.Remarks = "CREATED BY UNIT TEST";
            Data.Data = itemInBase64;

            // CREATE CS
            Inventory_Comparative_Study CS = service.saveComparativeStudy(Data);
            Assert.IsNotNull(CS, service.Error.Message);

            // CANCEL CS
            CommonDataEntryClass cCS = new CommonDataEntryClass();

            cCS.ID = CS.ID;
            cCS.EmployeeCode = "LPL02693";
            cCS.Remarks = "CANCELED BY UNIT TEST";

            Inventory_Comparative_Study canceledCS = service.cancelComparativeStudy(cCS);
            Assert.IsNotNull(canceledCS, service.Error.Message);

            // QUOTATION DETAILS
            //var requisitionDetails = service.getRequisitionDetails(requisition.ID);
            //Assert.IsNotNull(requisitionDetails, service.Error.Message);
        }

        [TestMethod()]
        public void getComparativeStudyStatusReport()
        {
            MainGroupID = 22;
            List<ComparativeStudyListNP> inventoryTypes = service.getComparativeStudyStatusReport(2467, 1);
            Assert.IsNotNull(inventoryTypes, service.Error.Message);
        }
    }
}