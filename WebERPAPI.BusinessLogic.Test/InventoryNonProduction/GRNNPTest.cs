using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.Inventory.PurchaseOrdersNP;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.BusinessLogic.Test
{
    [TestClass]
    public class GRNNPTest
    {
        private string EmployeeID = "LPL02693";
        private int QuotationID = 0;
        private int RequisitionID = 0;
        private int MainGroupID = 0;
        private int CSID = 4;

        private GRNAndStockNP service = new GRNAndStockNP();

        [TestMethod]
        public void saveGRNTest()
        {
            List<Inventory_GRN_Items> items = new List<Inventory_GRN_Items>();
            Inventory_GRN_Items item = new Inventory_GRN_Items();

            item.ItemID = 20; //Mouse (USB)
            item.Quantity = 10;
            item.Rate = 220;
            item.OrderNumber = 1;

            items.Add(item);

            string jsonstr = Library.JSONSerialize.ObjectToJSONText(items);
            string itemInBase64 = Library.JSONSerialize.EncodeBase64(jsonstr);

            GRNNewDTO Data = new GRNNewDTO();

            Data.MainGroupID = 22;
            Data.POID = 6;
            Data.SupplierCode = "S-0693";
            Data.ChallanNumber = "00011";
            Data.ChallanDate = DateTime.Now;

            Data.VATChallanNumber = "2222";
            Data.VATChallanDate = DateTime.Now;
            Data.IsVDSAllowed = false;

            Data.GRNCode = "TEST_CODE";
            Data.StoreID = 1;

            Data.CreatedByID = "LPL02693";
            Data.Remarks = "CREATED BY UNIT TEST";
            Data.Data = itemInBase64;

            // CREATE GRN
            Inventory_GRN newGRN = service.saveGRN(Data);
            Assert.IsNotNull(newGRN, service.Error.Message);
        }

        [TestMethod]
        public void saveQRNTest()
        {
            List<Inventory_QRN_Items> items = new List<Inventory_QRN_Items>();
            Inventory_QRN_Items item = new Inventory_QRN_Items();

            item.ItemID = 20; //Mouse (USB)
            item.PassedQuantity = 10;
            item.RejectedQuantity = 5;
            item.OrderNumber = 1;

            items.Add(item);

            string jsonstr = Library.JSONSerialize.ObjectToJSONText(items);
            string itemInBase64 = Library.JSONSerialize.EncodeBase64(jsonstr);

            QRNNewDTO Data = new QRNNewDTO();

            Data.GRNID = 9;
            Data.CreatedByID = "LPL02693";
            Data.Remarks = "CREATED BY UNIT TEST";
            Data.Data = itemInBase64;

            // CREATE QRN
            Inventory_QRN newQRN = service.saveQRN(Data);
            Assert.IsNotNull(newQRN, service.Error.Message);
        }

        [TestMethod]
        public void getUserStoresTest()
        {
            List<UserStoresDTO> stores = service.getUserStores("LPL02693", 1);
            Assert.IsNotNull(stores, service.Error.Message);

            List<UserStoresDTO> stores2 = service.getUserStores("LPL02693", 0);
            Assert.IsNotNull(stores2, service.Error.Message);
        }

        [TestMethod]
        public void getGRNStatusReportNPTest()
        {
            List<GRNStatusReportNPDTO> statusReport = service.getGRNStatusReportNP("0", "2019-11-20", "2019-12-31");
            Assert.IsTrue(statusReport.Count > 0, service.Error.Message);
            Assert.IsNotNull(statusReport, service.Error.Message);
        }

        [TestMethod]
        public void getPurchaseOrderGRNListTest()
        {
            List<PurchaseOrderGRNsNPDTO> grnList = service.getPurchaseOrderGRNList("0", 3);
            Assert.IsTrue(grnList.Count > 0, service.Error.Message);
            Assert.IsNotNull(grnList, service.Error.Message);
        }

        [TestMethod]
        public void getPurchaseOrderForGRNTest()
        {
            List<PurchaseOrderNPDto> polist = service.getPurchaseOrderForGRN(EmployeeID, "");
            Assert.IsNotNull(polist, service.Error.Message);

            Assert.IsTrue(polist.Count > 0, service.Error.Message);
        }

        [TestMethod]
        public void GRNPendingNPTest()
        {
            List<GRNPendingNP> grnPending = service.getGRNPending();
            Assert.IsNotNull(grnPending, service.Error.Message);

            Assert.IsTrue(grnPending.Count > 0, service.Error.Message);
        }
    }
}