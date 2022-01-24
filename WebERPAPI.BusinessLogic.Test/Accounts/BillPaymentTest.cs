using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.BusinessLogic.Accounts;
using WebERPAPI.DTO.Accounts.BillPayment;

namespace WebERPAPI.BusinessLogic.Test.Accounts
{
    /// <summary>
    /// Summary description for BillPaymentTest
    /// </summary>
    [TestClass]
    public class BillPaymentTest
    {
        private BillPaymentService service = new BillPaymentService();

        public BillPaymentTest()
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
        public void saveBillPaymentLogTest()
        {
            CashBillPaymentNew item = new CashBillPaymentNew();

            item.BillCode = "BM3423423";
            item.AmountPaid = 5000;
            item.MoneyReceiptNumber = "454545";
            item.PaidTo = "TEST USER";
            item.PaymentPlanID = 1;
            item.PaymentTypeID = 1;
            item.CreatedByID = 2467;

            Bill_Payment_Log result = service.cashPayment(item);
            Assert.IsNotNull(result, service.Error.Message);
        }
    }
}