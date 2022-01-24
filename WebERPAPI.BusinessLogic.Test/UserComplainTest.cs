using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabaidMIS.Data.Models.PROCESSERVER;
using LabaidMIS.BusinessLogic.User;
using LabaidMIS.Classes.User.Complain;

namespace LabaidMIS.BusinessLogic.Test
{
    /// <summary>
    /// Summary description for UserComplainTest
    /// </summary>
    [TestClass]
    public class UserComplainTest
    {
        private UserComplainService service = new UserComplainService();

        public UserComplainTest()
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
        public void saveUserComplainsTest()
        {
            UserComplainsNewDto item = new UserComplainsNewDto();

            item.UserComplainTypeID = 1;
            item.Details = "UNIT TEST TEXT";
            item.CreatedByID = 2497;

            User_Complains result = service.saveUserComplain(item);
            Assert.IsNotNull(result, service.Error.Message);
        }
    }
}