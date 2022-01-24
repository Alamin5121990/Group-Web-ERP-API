using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.DTO.Inventory.Procurement.Quotation;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.BusinessLogic.Test
{
    /// <summary>
    /// Summary description for QuotationNPTest
    /// </summary>
    [TestClass]
    public class QuotationNPTest
    {
        private string employeeID = "LPL03397";
        private int quotationID = 0;
        private int requisitionID = 0;
        private QuotationNP service = new QuotationNP();

        public QuotationNPTest()
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

        [TestMethod()]
        public void inviteQuotation()
        {
            List<QuotationInvitationSendDetails> items = new List<QuotationInvitationSendDetails>();
            QuotationInvitationSendDetails item = new QuotationInvitationSendDetails();

            item.RequisitionID = 9;
            item.ItemID = 27; //Mouse (USB)
            item.Quantity = 1;
            item.SupplierCode = "S-0694";
            item.ManufacturerCode = "";

            items.Add(item);

            string jsonstr = Library.JSONSerialize.ObjectToJSONText(items);
            string itemInBase64 = Library.JSONSerialize.EncodeBase64(jsonstr);

            CommonDataEntryClass Data = new CommonDataEntryClass();

            Data.EmployeeCode = "LPL02693";
            Data.Date = DateTime.Now;
            Data.Remarks = "CREATED BY UNIT TEST";
            Data.Data = itemInBase64;

            // CREATE QUOTATION
            Inventory_Quotation_Invitations quotation = service.inviteQuotation(Data, "");
            Assert.IsNotNull(quotation, service.Error.Message);

            // CANCEL QUOTATION
            CommonDataEntryClass cQuot = new CommonDataEntryClass();

            cQuot.ID = quotation.ID;
            cQuot.EmployeeCode = "LPL02693";
            cQuot.Remarks = "CANCELED BY UNIT TEST";

            Inventory_Quotation_Invitations canceledQuotation = service.cancelQuotation(cQuot);
            Assert.IsNotNull(canceledQuotation, service.Error.Message);

            // QUOTATION DETAILS
            //var requisitionDetails = service.getRequisitionDetails(requisition.ID);
            //Assert.IsNotNull(requisitionDetails, service.Error.Message);
        }

        [TestMethod()]
        public void getUserInventoryTypeList()
        {
            List<InventoryTypes> inventoryTypes = service.getUserInventoryTypeList(employeeID);
            Assert.IsNotNull(inventoryTypes, service.Error.Message);
            Assert.IsTrue(inventoryTypes.Count > 0, service.Error.Message);
        }

        [TestMethod()]
        public void getUserMainGroupList()
        {
            List<UserMainGroup> inventoryTypes = service.getUserMainGroupList(employeeID, 3); // 3 = General Inventory
            Assert.IsNotNull(inventoryTypes, service.Error.Message);
            Assert.IsTrue(inventoryTypes.Count > 0, service.Error.Message);
        }

        [TestMethod()]
        public void getRequisitionNPPending()
        {
            int mainGroupID = 28;

            List<RequisitionNPPending> requisitions = service.getRequisitionNPPending(mainGroupID);
            if (service.Error == null && (requisitions == null || requisitions.Count == 0)) Assert.IsNull(requisitions, service.Error.Message);
            else Assert.IsNotNull(requisitions, service.Error.Message);
        }

        [TestMethod()]
        public void getRequisitionSuppliersNP()
        {
            requisitionID = 3;

            List<RequisitionSuppliersNP> inventoryTypes = service.getRequisitionSuppliersNP(requisitionID);
            Assert.IsNotNull(inventoryTypes, service.Error.Message);
            Assert.IsTrue(inventoryTypes.Count > 0, service.Error.Message);
        }

        [TestMethod()]
        public void getBillPaymentTypes()
        {
            List<Bill_PaymentType> billPaymentTypes = service.getBillPaymentTypes();
            Assert.IsNotNull(billPaymentTypes, service.Error.Message);
            Assert.IsTrue(billPaymentTypes.Count > 0, service.Error.Message);
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

        // QUOTATION RECEIVE

        [TestMethod()]
        public void receiveQuotation()
        {
            List<Inventory_Quotation_Received_Details> items = new List<Inventory_Quotation_Received_Details>();
            Inventory_Quotation_Received_Details item = new Inventory_Quotation_Received_Details();

            item.RequisitionID = 9;
            item.ItemID = 27; //Mouse (USB)
            item.Quantity = 1;
            item.SupplierCode = "S-0694";
            item.ManufacturerCode = "";
            item.QuotationID = 3;
            item.Rate = 3;
            item.BillPaymentTypeID = 1;

            items.Add(item);

            string jsonstr = Library.JSONSerialize.ObjectToJSONText(items);
            string itemInBase64 = Library.JSONSerialize.EncodeBase64(jsonstr);

            CommonDataEntryClass Data = new CommonDataEntryClass();

            Data.EmployeeCode = "LPL02693";
            Data.Date = DateTime.Now;
            Data.Remarks = "CREATED BY UNIT TEST";
            Data.Data = itemInBase64;

            // CREATE QUOTATION
            Inventory_Quotation_Received quotation = service.receiveQuotation(Data);
            Assert.IsNotNull(quotation, service.Error.Message);

            // CANCEL QUOTATION
            CommonDataEntryClass cQuot = new CommonDataEntryClass();

            cQuot.ID = quotation.ID;
            cQuot.EmployeeCode = "LPL02693";
            cQuot.Remarks = "CANCELED BY UNIT TEST";

            //Inventory_Quotation_Received canceledQuotation = service.saveQuotationReceiveDetails(quotation.ID, cQuot);
            //Assert.IsNotNull(canceledQuotation, service.Error.Message);

            // QUOTATION DETAILS
            //var requisitionDetails = service.getRequisitionDetails(requisition.ID);
            //Assert.IsNotNull(requisitionDetails, service.Error.Message);
        }
    }
}