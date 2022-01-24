using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WebERPAPI.Test.BusinessLogicTesting
{
    [TestClass()]
    public class ProductionPlanningFormula
    {
        [TestMethod()]
        public void getMaterialAvailableQuantity()
        {
            Nullable<decimal> Expected = 2412.6446m;

            Nullable<decimal> StockQuantity = 3812.6446m;
            Nullable<decimal> TotalBatchRequiredQuantity = 1400.00m;

            Nullable<decimal> Result = BusinessLogic.Formulas.ProductionPlanningFormula.getMaterialAvailableQuantity(StockQuantity, TotalBatchRequiredQuantity);

            Assert.AreEqual(Expected, Result);
        }

        [TestMethod()]
        public void getMaterialNewRequisitionQuantity()
        {
            Nullable<decimal> Expected = 4261.3993m;

            Nullable<decimal> AvailableQuantity = -12261.3993m;
            Nullable<decimal> RequisitionQuantity = 8000.00m;
            Nullable<decimal> PurchaseOrderQuantity = 0;
            Nullable<decimal> PORemainingQuantity = 0;

            Nullable<decimal> Result = BusinessLogic.Formulas.ProductionPlanningFormula.getMaterialNewRequisitionQuantity(AvailableQuantity, RequisitionQuantity, PurchaseOrderQuantity, PORemainingQuantity);

            Assert.AreEqual(Expected, Result);
        }

        [TestMethod()]
        public void getPORemainingQuantity()
        {
            Nullable<decimal> Expected = 2450m;

            Nullable<decimal> RequisitionQuantity = 5000m;
            Nullable<decimal> PODoneQuantity = 2550m;

            Nullable<decimal> Result = BusinessLogic.Formulas.ProductionPlanningFormula.getPORemainingQuantity(RequisitionQuantity, PODoneQuantity);

            Assert.AreEqual(Expected, Result);
        }

        [TestMethod()]
        public void getActualFreeStockQuantity()
        {
            Nullable<decimal> Expected = 37.992m;

            Nullable<decimal> FreeStockQuantity = 21.928m;
            Nullable<decimal> QurantineQuantity = 20.0m;
            Nullable<decimal> BookingQuantity = 3.936m;

            Nullable<decimal> Result = BusinessLogic.Formulas.ProductionPlanningFormula.getActualFreeStockQuantity(FreeStockQuantity, QurantineQuantity, BookingQuantity);

            Assert.AreEqual(Expected, Result);
        }
    }
}