using System.Net.Http;
using System.Web.Http;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.DTO;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.Controllers.InventoryNonProduction
{
    public class BillSubmitNPController : ApiController
    {
        public BillSubmitNPService service = new BillSubmitNPService();

        [HttpGet]
        [Route("~/api/inventory/np/supplier/list/{inventorytypeid}")]
        public HttpResponseMessage getSupplierListByInventoryTypeId(int inventorytypeid)
        {
            return MISResponse.Return(service.getSupplierListByInventoryTypeId(inventorytypeid), service.Error, Request);
        }

      

        [HttpGet]
        [Route("~/api/inventory/np/po/material/list/{pocode}")]
        public HttpResponseMessage getPOMaterialListNPByPoCode(string pocode)
        {
            return MISResponse.Return(service.getPOMaterialListNPByPoCode(pocode), service.Error, Request);
        }

        //Bill submit and forward NP
        [HttpGet]
        [Route("~/api/inventory/np/po/list/{suppliercode}/{inventorytypeid}")]
        public HttpResponseMessage getSupplierListByInventoryTypeId(string suppliercode, int inventorytypeid)
        {
            return MISResponse.Return(service.getPOListNPBySupplierCodeInventoryTypeID(suppliercode, inventorytypeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/bill/report/{billcode}")]
        public HttpResponseMessage getBillReport(string billcode)
        {
            return MISResponse.Return(service.getBillReport(billcode), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/np/po/bill/submit")]
        public HttpResponseMessage saveBillSubmitNP(POBillSubmitMasterNPDTO accountBill)
        {
            return MISResponse.Return(service.saveBillForNP(accountBill), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/po/bill/forward/list/")]
        public HttpResponseMessage getBillForwardList()
        {
            return MISResponse.Return(service.getBillForwardList(), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/np/account/bill/forward")]
        public HttpResponseMessage forwardBillNP([FromBody] CommonDataEntryClass BillDetails)
        {
            return MISResponse.Return(service.forwardBillNP(BillDetails), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/np/account/multiple/bill/forward")]
        public HttpResponseMessage multipleBillForward([FromBody] CommonDataEntryClass BillList)
        {
            return MISResponse.Return(service.multipleBillForward(BillList), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/account/receive/bill/pending/list/{employeeid}")]
        public HttpResponseMessage accountReceiveBillPendingList(string employeeid)
        {
            return MISResponse.Return(service.accountReceiveBillPendingList(employeeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/account/advance/bill/pending/list/{employeeid}")]
        public HttpResponseMessage getInventoryAdvancePaymentPendingList(string employeeid)
        {
            return MISResponse.Return(service.getInventoryAdvancePaymentPendingList(employeeid), service.Error, Request);
        }
    }
}