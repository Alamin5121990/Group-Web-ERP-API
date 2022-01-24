using System.Net.Http;
using System.Web.Http;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.PurchaseOrdersNP;

namespace WebERPAPI.Controllers.InventoryNonProduction
{
    [Authorize]
    public class PurchaseOrderNPController : ApiController
    {
        private PurchaseOrderNP service = new PurchaseOrderNP();

        [HttpGet]
        [Route("~/api/inventory/np/purchase/order/bill/report/{SupplierId}")]
        public HttpResponseMessage getPurchaseOrderBillReport(string SupplierId)
        {
            return MISResponse.Return(service.getPurchaseOrderBillReport(SupplierId), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/purchase/order/supplier")]
        public HttpResponseMessage getAllSupplierforPurchaseOrder()
        {
            return MISResponse.Return(service.getAllSupplierforPurchaseOrder(), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/cs/suppliers/for/newpo/{employeeid}")]
        public HttpResponseMessage getComparativeStudySuppliersNP(string employeeid)
        {
            return MISResponse.Return(service.getComparativeStudySuppliersNP(employeeid), service.Error, Request);
        }
        [HttpPost]
        [Route("~/api/inventory/np/cancelled/check/save/")]
        public HttpResponseMessage saveCancelledCheck(CheckCancelledList CancelledCheck)
        {
            return MISResponse.Return(service.saveCancelledCheck(CancelledCheck), service.Error, Request);
        }
        [HttpGet]
        [Route("~/api/inventory/np/comparative/study/for/purchase/order/{maingroupid}/{suppliercode}")]
        public HttpResponseMessage getComparativeStudyForPurchaseNP(int maingroupid, string suppliercode)
        {
            return MISResponse.Return(service.getComparativeStudyForPurchaseNP(maingroupid, suppliercode), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/comparative/study/items/for/purchase/order/{csid}/{suppliercode}")]
        public HttpResponseMessage getComparativeStudyItemsForPurchaseOrder(int csid, string suppliercode)
        {
            return MISResponse.Return(service.getComparativeStudyItemsForPurchaseOrder(csid, suppliercode), service.Error, Request);
        }

        //START PURCHASE ORDER ADVANCE PAID
        [HttpGet]
        [Route("~/api/inventory/np/purchase/order/advancepaid/list/{PoCode}")]
        public HttpResponseMessage getAdvancePaymentListByPoCode(string PoCode)
        {
            return MISResponse.Return(service.getAdvancePaymentListByPoCode(PoCode), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/np/purchase/order/advancepaid/saveupdate")]
        public HttpResponseMessage saveUpdateAdvancePaid([FromBody] Inventory_Purchase_Order_AdvancePaid POData)
        {
            return MISResponse.Return(service.saveUpdateAdvancePayment(POData), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/np/purchase/order/advancepaid/delete/{Remarks}")]
        public HttpResponseMessage getAdvancePaymentListByPoCode(Inventory_Purchase_Order_AdvancePaid PO, string Remarks)
        {
            return MISResponse.Return(service.deleteAdvancePayment(PO, Remarks), service.Error, Request);
        }

        //END PURCHASE ORDER ADVANCE PAID

        // PURCHASE ORDER
        [HttpPost]
        [Route("~/api/inventory/np/purchase/order/save")]
        public HttpResponseMessage savePurchaseOrder([FromBody] PurchaseOrderNPNew POData)
        {
            return MISResponse.Return(service.savePurchaseOrder(POData), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/np/purchase/order/update")]
        public HttpResponseMessage updatePurchaseOrder([FromBody] PurchaseOrderNPNew POData)
        {
            return MISResponse.Return(service.updatePurchaseOrder(POData), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/np/purchase/order/status/update")]
        public HttpResponseMessage updatePurchaseOrderStatus([FromBody] CommonDataEntryClass POData)
        {
            return MISResponse.Return(service.updatePurchaseOrderStatus(POData), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/purchase/order/to/verify")]
        public HttpResponseMessage getPurchaseOrderToVerify()
        {
            return MISResponse.Return(service.getPurchaseOrderToVerify(), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/purchase/order/report/{pocode}/{poid}")]
        public HttpResponseMessage getPurchaseOrderReport(string pocode, int poid)
        {
            return MISResponse.Return(service.getPurchaseOrderReport(pocode, poid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/purchase/order/status/report/{datefrom}/{dateto}/{inventoryTypeID}/{suppliercode}/{SearchText}")]
        public HttpResponseMessage getPurchaseOrderStatusReport(string datefrom, string dateto, int inventoryTypeID, string suppliercode, string SearchText)
        {
            return MISResponse.Return(service.getPurchaseOrderStatusReport(datefrom, dateto, inventoryTypeID, suppliercode, SearchText), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/purchase/order/supplier/list/")]
        public HttpResponseMessage getPurchaseOrderSupplierList()
        {
            return MISResponse.Return(service.getPurchaseOrderSupplierList(), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/purchase/order/search/{searchtext}")]
        public HttpResponseMessage getPurchaseOrderStatusReport(string searchtext)
        {
            return MISResponse.Return(service.getPurchaseOrderStatusReport("0", "0", 0, "All", searchtext), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/np/purchase/order/auto/close")]
        public HttpResponseMessage autoPurchaseOrderClose([FromBody] CommonDataEntryClass Data)
        {
            return MISResponse.Return(service.autoPurchaseOrderClose(Data), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/purchase/order/close/{POID}/{EmployeeCode}")]
        public HttpResponseMessage PurchaseOrderClose(int POID, string EmployeeCode)
        {
            return MISResponse.Return(service.PurchaseOrderClose(POID, EmployeeCode), service.Error, Request);
        }
    }
}