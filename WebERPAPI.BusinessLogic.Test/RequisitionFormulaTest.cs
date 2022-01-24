using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebERPAPI.BusinessLogic.Formulas;

namespace WebERPAPI.BusinessLogic.Test
{
    [TestClass()]
    public class RequisitionFormulaTest
    {
        [TestMethod()]
        public void getComparativeStudyStatus()
        {
            int TotalTest = 3, TestPassed = 0;

            //TEST 1
            string Expected = "CS_PARTIAL";

            Nullable<decimal> RequisitionQuantity = 400.0m;
            Nullable<decimal> TotalCSQuantity = 100.00m;

            string Result = RequisitionFormula.getComparativeStudyStatus(RequisitionQuantity, TotalCSQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 2
            Expected = "CS_COMPLETED";
            TotalCSQuantity = 400.00m;

            Result = RequisitionFormula.getComparativeStudyStatus(RequisitionQuantity, TotalCSQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 3
            Expected = "CS_NOT_DONE";
            TotalCSQuantity = 0.00m;

            Result = RequisitionFormula.getComparativeStudyStatus(RequisitionQuantity, TotalCSQuantity);
            if (Expected == Result) TestPassed++;

            Assert.AreEqual(TotalTest, TestPassed);
        }

        [TestMethod()]
        public void getPurchaseOrderStatus()
        {
            int TotalTest = 3, TestPassed = 0;

            //TEST 1
            string Expected = "PO_PARTIAL";

            Nullable<decimal> RequisitionQuantity = 400.0m;
            Nullable<decimal> TotalPOQuantity = 100.00m;

            string Result = RequisitionFormula.getPurchaseOrderStatus(RequisitionQuantity, TotalPOQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 2
            Expected = "PO_COMPLETED";
            TotalPOQuantity = 400.00m;

            Result = RequisitionFormula.getPurchaseOrderStatus(RequisitionQuantity, TotalPOQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 3
            Expected = "PO_NOT_DONE";
            TotalPOQuantity = 0.00m;

            Result = RequisitionFormula.getPurchaseOrderStatus(RequisitionQuantity, TotalPOQuantity);
            if (Expected == Result) TestPassed++;

            Assert.AreEqual(TotalTest, TestPassed);
        }

        [TestMethod()]
        public void getLetterOfCreditStatus()
        {
            int TotalTest = 3, TestPassed = 0;

            //TEST 1
            string Expected = "LC_PARTIAL";

            Nullable<decimal> RequisitionQuantity = 400.0m;
            Nullable<decimal> TotalLCQuantity = 100.00m;

            string Result = RequisitionFormula.getLetterOfCreditStatus(RequisitionQuantity, TotalLCQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 2
            Expected = "LC_COMPLETED";
            TotalLCQuantity = 400.00m;

            Result = RequisitionFormula.getLetterOfCreditStatus(RequisitionQuantity, TotalLCQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 3
            Expected = "LC_NOT_DONE";
            TotalLCQuantity = 0.00m;

            Result = RequisitionFormula.getLetterOfCreditStatus(RequisitionQuantity, TotalLCQuantity);
            if (Expected == Result) TestPassed++;

            Assert.AreEqual(TotalTest, TestPassed);
        }

        [TestMethod()]
        public void getGRNStatus()
        {
            int TotalTest = 9, TestPassed = 0;

            //TEST 1
            string Expected = "GRN_PARTIAL";

            Nullable<decimal> RequisitionQuantity = 400.0m;
            Nullable<decimal> TotalGRNQuantity = 100.00m;

            string Result = RequisitionFormula.getGRNStatus("LOCAL", false, RequisitionQuantity, TotalGRNQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 2
            Expected = "GRN_PARTIAL";
            TotalGRNQuantity = 100.00m;

            Result = RequisitionFormula.getGRNStatus("IMPORT", false, RequisitionQuantity, TotalGRNQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 3
            Expected = "GRN_COMPLETED";
            TotalGRNQuantity = 400.00m;

            Result = RequisitionFormula.getGRNStatus("IMPORT", false, RequisitionQuantity, TotalGRNQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 4
            Expected = "GRN_COMPLETED";
            TotalGRNQuantity = 400.00m;

            Result = RequisitionFormula.getGRNStatus("IMPORT", true, RequisitionQuantity, TotalGRNQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 5
            Expected = "GRN_COMPLETED";
            TotalGRNQuantity = 400.00m;

            Result = RequisitionFormula.getGRNStatus("LOCAL", false, RequisitionQuantity, TotalGRNQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 6
            Expected = "GRN_COMPLETED";
            TotalGRNQuantity = 385.00m;

            Result = RequisitionFormula.getGRNStatus("IMPORT", false, RequisitionQuantity, TotalGRNQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 7
            Expected = "GRN_COMPLETED";
            TotalGRNQuantity = 380.00m;

            Result = RequisitionFormula.getGRNStatus("LOCAL", false, RequisitionQuantity, TotalGRNQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 8
            Expected = "GRN_NOT_DONE";
            TotalGRNQuantity = 0.00m;

            Result = RequisitionFormula.getGRNStatus("LOCAL", false, RequisitionQuantity, TotalGRNQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 9
            Expected = "GRN_NOT_DONE";
            TotalGRNQuantity = 0.00m;

            Result = RequisitionFormula.getGRNStatus("IMPORT", false, RequisitionQuantity, TotalGRNQuantity);
            if (Expected == Result) TestPassed++;

            Assert.AreEqual(TotalTest, TestPassed);
        }

        [TestMethod()]
        public void getRequisitionRemainingQuantity()
        {
            int TotalTest = 4, TestPassed = 0;

            //TEST 1
            decimal Expected = 300.0m;

            Nullable<decimal> RequisitionQuantity = 400.0m;
            Nullable<decimal> TotalLCQuantity = 100.00m;
            Nullable<decimal> TotalPOQuantity = 100.00m;
            Nullable<decimal> TotalGRNQuantity = 100.00m;

            decimal Result = RequisitionFormula.getRequisitionRemainingQuantity(RequisitionQuantity, TotalPOQuantity, TotalLCQuantity, TotalGRNQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 2
            Expected = 0.0m;
            TotalLCQuantity = 400.00m;
            TotalGRNQuantity = 380.00m;

            Result = RequisitionFormula.getRequisitionRemainingQuantity(RequisitionQuantity, TotalPOQuantity, TotalLCQuantity, TotalGRNQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 3
            Expected = 0.0m;
            TotalLCQuantity = 0.00m;
            TotalGRNQuantity = 370.00m;

            Result = RequisitionFormula.getRequisitionRemainingQuantity(RequisitionQuantity, TotalPOQuantity, TotalLCQuantity, TotalGRNQuantity);
            if (Expected == Result) TestPassed++;

            //TEST 4
            Expected = 0.0m;
            TotalLCQuantity = 0.00m;
            TotalGRNQuantity = 400.00m;

            Result = RequisitionFormula.getRequisitionRemainingQuantity(RequisitionQuantity, TotalPOQuantity, TotalLCQuantity, TotalGRNQuantity);
            if (Expected == Result) TestPassed++;

            Assert.AreEqual(TotalTest, TestPassed);
        }
    }
}