//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using WebERPAPI.DTO.Inventory;

//namespace WebERPAPI.BusinessLogic.Test
//{
//    [TestClass()]
//    public class PurchaseOrderTest
//    {
//        private Inventory.SCM.PurchaseOrder PO = new Inventory.SCM.PurchaseOrder();

//        [TestMethod()]
//        public void getTermsAndConditions()
//        {
//            Assert.IsNotNull(PO.getTermsAndConditions());
//        }

//        [TestMethod()]
//        public void getInternalApprovalMaterialsForPurchaseOrder()
//        {
//            List<InternalApprovalMaterialsForPurchaseOrderReport> result = PO.getInternalApprovalMaterialsForPurchaseOrder();
//            Assert.IsNotNull(result);
//            Assert.IsTrue(result.Count > 0);
//        }

//        [TestMethod()]
//        public void getPurchaseOrders()
//        {
//            List<PurchaseOrderReport> result = PO.getPurchaseOrders(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
//            Assert.IsNotNull(result);
//            Assert.IsTrue(result.Count > 0);
//        }

//        [TestMethod()]
//        public void getPurchaseOrderDetails()
//        {
//            List<PurchaseOrderDetails> result = PO.getPurchaseOrderDetails("PO-01912");
//            Assert.IsNotNull(result);
//            Assert.IsTrue(result.Count > 0);
//        }

//        [TestMethod()]
//        public void getPurchaseOrderReport()
//        {
//            Assert.IsNotNull(PO.getPurchaseOrderReport("PO-01912"));
//        }

//        [TestMethod()]
//        public void deletePurchaseOrder()
//        {
//            Assert.IsTrue(PO.deletePurchaseOrder("PO-01912"));
//        }
//    }
//}