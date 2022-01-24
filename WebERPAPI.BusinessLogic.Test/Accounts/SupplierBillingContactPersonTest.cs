using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.DTO.Accounts.BillPayment;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.BusinessLogic.Accounts;

namespace WebERPAPI.BusinessLogic.Test.Accounts
{
    /// <summary>
    /// Summary description for SupplierBillingContactPersonTest
    /// </summary>
    [TestClass]
    public class SupplierBillingContactPersonTest
    {
        private SupplierBillingPersonService service = new SupplierBillingPersonService();

        public SupplierBillingContactPersonTest()
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
        public void saveSupplierBillingContactPersonTest()
        {
            SupplierBillingContactPersonNewDto item = new SupplierBillingContactPersonNewDto();

            item.SupplierCode = "E-1912004";
            item.ContactPersonName = "UNIT TEST TEXT";
            item.CreatedByID = 1;
            //item.CreatedOn = DateTime.Now;

            Supplier_Billing_Contact_Person result = service.saveBillingPerson(item);
            Assert.IsNotNull(result, service.Error.Message);
        }

        [TestMethod()]
        public void getSupplierBillingContactPersonTest()
        {
            List<Supplier_Billing_Contact_Person> result = service.getSupplierBillingPerson("E-1912004");
            Assert.IsNotNull(result, service.Error.Message);
        }
    }
}