using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.BusinessLogic.HRMS;
using WebERPAPI.DTO.HRMS.SMSNotification;

namespace WebERPAPI.BusinessLogic.Test.HRMS
{
    /// <summary>
    /// Summary description for SMSNotificationTest
    /// </summary>
    [TestClass]
    public class SMSNotificationTest
    {
        public SMSNotificationService service = new SMSNotificationService();


        public SMSNotificationTest()
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
        #endregion

        [TestMethod()]
        public void getSMSCategoryList()
        {
            var result = service.getSMSCategoryList();
            Assert.IsNotNull(result, service.Error.Message);

        }


        [TestMethod()]
        public void getUserNotificationList()
        {
            int EmployeeID = 2467;
            var result = service.getUserNotificationList(EmployeeID);
            Assert.IsNotNull(result, service.Error.Message);

        }

        [TestMethod()]
        public void saveSMSNotificationTest()
        {
            List<SMS_Notification_Details> items = new List<SMS_Notification_Details>();
            SMS_Notification_Details details = new SMS_Notification_Details();

            details.ScheduleDate = System.DateTime.Now;
            details.SMSContent = "Details Test Content";
            details.SMSNotificationID = 1;
            details.CreatedOn = System.DateTime.Now;
            details.CreatedByID = 1334;
            details.BatchNo = 1;
            details.EmployeeID = 1234;
            details.IsSent = false;

            items.Add(details);

            string jsonstr = Library.JSONSerialize.ObjectToJSONText(items);
            string itemInBase64 = Library.JSONSerialize.EncodeBase64(jsonstr);

            SMSNotificationNewDto item = new SMSNotificationNewDto();
            item.YearNo = 2020;
            item.MonthNo = 7;
            item.Title = "This is Test";
            item.NotificationCategoryID = 1;
            //item.NotificationDetailsNewDto = itemInBase64;

            SMS_Notification result = service.saveSMSNotification(item);
            Assert.IsNotNull(result, service.Error.Message);
        }
    }
}
