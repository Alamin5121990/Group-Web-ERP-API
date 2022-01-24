using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WebERPAPI.Test.Library.DateTimeTest
{
    [TestClass()]
    public class DateTimeTest
    {
        [TestMethod()]
        public void getNullableDateValueTest()
        {
            int testNo = 2, success = 0;

            // test 1
            string Expected = "10 Jul 2019";
            DateTime dt = new DateTime(2019, 07, 10);
            string Result = WebERPAPI.Library.TimeConvert.getNullableDateValue(dt, "dd MMM yyyy");
            if (Expected == Result) success++;

            // test 2
            Expected = "";
            Nullable<DateTime> dtNull = null;
            Result = WebERPAPI.Library.TimeConvert.getNullableDateValue(dtNull, "dd MMM yyyy");
            if (Expected == Result) success++;

            Assert.AreEqual(testNo, success);
        }
    }
}