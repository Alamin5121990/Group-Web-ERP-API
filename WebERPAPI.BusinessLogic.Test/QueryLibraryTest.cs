using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.BusinessLogic.Maintenance;
using WebERPAPI.DTO.Maintenance;

namespace WebERPAPI.BusinessLogic.Test
{
    /// <summary>
    /// Summary description for QueryLibraryTest
    /// </summary>
    [TestClass]
    public class QueryLibraryTest
    {
        private QueryLibraryService service = new QueryLibraryService();

        public QueryLibraryTest()
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
        public void saveQueryLibraryDto()
        {
            QueryLibraryNewDto item = new QueryLibraryNewDto();

            item.DatabaseID = 1;
            item.Title = "UNIT TEST TEXT";
            item.SqlQuery = "UNIT TEST TEXT";
            item.IsActive = true;
            item.CreatedByID = "LPL02693";
            item.CreatedOn = DateTime.Now;

            Query_Library result = service.saveQueryLibrary(item);
            Assert.IsNotNull(result, service.Error.Message);
        }
    }
}