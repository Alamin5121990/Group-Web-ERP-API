using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebERPAPI.Data.BusinessLogic;

namespace WebERPAPI.Data.Test.BusinessLogic
{
    [TestClass]
    public class ProductionPlanningTest
    {
        [TestMethod]
        public void getMaterialAvailableQuantity()
        {
            int testTotal = 4;
            int successTotal = 0;

            Nullable<decimal> expected = 5;
            Nullable<decimal> actual = ProductionPlanning.getMaterialAvailableQuantity(8, 3);
            if (expected == actual) successTotal++;

            expected = 8;
            actual = ProductionPlanning.getMaterialAvailableQuantity(8, null);
            if (expected == actual) successTotal++;

            expected = -5;
            actual = ProductionPlanning.getMaterialAvailableQuantity(null, 5);
            if (expected == actual) successTotal++;

            expected = 0;
            actual = ProductionPlanning.getMaterialAvailableQuantity(null, null);
            if (expected == actual) successTotal++;

            Assert.AreEqual(testTotal, successTotal);
        }

        [TestMethod]
        public void getMaterialNewRequisitionQuantity()
        {
            int testTotal = 4;
            int successTotal = 0;

            Nullable<decimal> expected = 5;
            Nullable<decimal> actual = ProductionPlanning.getMaterialNewRequisitionQuantity(8, 3, 2, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getPORemainingQuantity()
        {
        }

        [TestMethod]
        public void getActualFreeStockQuantity()
        {
        }

        [TestMethod]
        public void getActualFreeStock()
        {
        }

        [TestMethod]
        public void getAvailableQuantity()
        {
        }
    }
}