using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.BusinessLogic.User;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.BusinessLogic.Test
{
    /// <summary>
    /// Summary description for UserActivityTest
    /// </summary>
    [TestClass]
    public class UserActivityTest
    {
        private UserActivityService service = new UserActivityService();

        public UserActivityTest()
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
        public void saveUserActivitiesTest()
        {
            User_Activities item = new User_Activities();

            item.ActivityDescription = "UNIT TEST USER ACTIVITY TEST";
            item.ActivityModuleID = 20;
            item.ReferenceID = 1;
            item.CreatedByID = 2467;
            item.URL = "https://www.lplmis.com/ERP/#/it/dashboard";

            Assert.IsTrue(service.saveUserActivity(item), service.Error.Message);
        }
    }
}