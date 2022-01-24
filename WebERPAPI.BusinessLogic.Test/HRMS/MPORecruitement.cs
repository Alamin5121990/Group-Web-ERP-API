using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebERPAPI.BusinessLogic.HRMS;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.HRMS;

namespace WebERPAPI.BusinessLogic.Test.HRMS
{
    /// <summary>
    /// Summary description for MPORecruitement
    /// </summary>
    [TestClass]
    public class MPORecruitement
    {
        MPORecruitmentService service;
        public MPORecruitement()
        {
            this.service = new MPORecruitmentService();
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
        #endregion

        [TestMethod()]
        public void saveMPORecruitmentBatchTest()
        {
            MPORecruitment_BatchDTO item = new MPORecruitment_BatchDTO();

            item.BatchNo = 89;
            item.BatchMonth = "test batch";


            //


            Boolean result = service.saveMPOBatch(item);
            Assert.IsNotNull(result, service.Error.Message);
            Assert.IsTrue(result, service.Error.Message);

        }

        [TestMethod()]
        public void GetMPOBatchLists()
        {
            var result = service.GetMPOBatchLists();
            Assert.IsNotNull(result, service.Error.Message);

        }

        [TestMethod()]
        public void getMPOlistByBatchNo()
        {
            int batchno = 88;
            var result = service.getMPOlistByBatchNo(batchno);
            Assert.IsNotNull(result, service.Error.Message);

        }

        [TestMethod()]
        public void saveMPOApplicantByBatchTest()
        {
            List<MPORecruitment_BatchwiseMPOListDTO> item = new List<MPORecruitment_BatchwiseMPOListDTO>();

            foreach (var applicants in item)
            {
                applicants.ApplicantName = "sadman test";

            }



            //


            Boolean result = service.saveMPOApplicantInfo(item);
            Assert.IsNotNull(result, service.Error.Message);
            Assert.IsTrue(result, service.Error.Message);

        }

        [TestMethod()]
        public void saveMPOBasicApplicantAssesmentsByBatch()
        {
            List<MPORecruitment_AssesmentsDTO> item = new List<MPORecruitment_AssesmentsDTO>();

            foreach (var assesments in item)
            {
                assesments.BatchNo = 1;
                assesments.AssesmentType = "Basic";
                assesments.AssesmentName = "CVC";
                assesments.AssesmentMarks = 20;

            }


            Boolean result = service.saveBasicBatchAssesment(item);
            Assert.IsNotNull(result, service.Error.Message);
            Assert.IsTrue(result, service.Error.Message);

        }
        [TestMethod()]
        public void saveMPOProductApplicantAssesmentsByBatch()
        {
            List<MPORecruitment_AssesmentsDTO> item = new List<MPORecruitment_AssesmentsDTO>();

            foreach (var assesments in item)
            {
                assesments.BatchNo = 1;
                assesments.AssesmentType = "Product";
                assesments.AssesmentName = "CVC";
                assesments.AssesmentMarks = 20;

            }


            Boolean result = service.saveProductBatchAssesment(item);
            Assert.IsNotNull(result, service.Error.Message);
            Assert.IsTrue(result, service.Error.Message);

        }
    }
}
