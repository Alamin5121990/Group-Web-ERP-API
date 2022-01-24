using System.Net.Http;
using System.Web.Http;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.DTO;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.Controllers.InventoryNonProduction
{
    public class GRNAndStockNPController : ApiController
    {
        private GRNAndStockNP service = new GRNAndStockNP();

        [HttpPost]
        [Route("~/api/inventory/np/grn/save")]
        public HttpResponseMessage saveGRN([FromBody] GRNNewDTO GRNData)
        {
            return MISResponse.Return(service.saveGRN(GRNData), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/np/user/store/save")]
        public HttpResponseMessage saveUserStore([FromBody] UserStoreNewDTO UserStore)
        {
            return MISResponse.Return(service.saveUserStore(UserStore), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/user/stores/{employeeid}/{showall}")]
        public HttpResponseMessage getUserStores(string employeeid, int showall)
        {
            return MISResponse.Return(service.getUserStores(employeeid, showall), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/purchase/orders/for/grn/{employeeid}/{searchtext}")]
        public HttpResponseMessage getPurchaseOrderForGRN(string employeeid, string searchtext)
        {
            return MISResponse.Return(service.getPurchaseOrderForGRN(employeeid, searchtext), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/grn/pending")]
        public HttpResponseMessage getGRNPending()
        {
            return MISResponse.Return(service.getGRNPending(), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/grn/pending/for/approve")]
        public HttpResponseMessage getGRNPendingForApproveNP()
        {
            return MISResponse.Return(service.getGRNPendingForApproveNP(), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/grn/report/{grncode}/{grnid}")]
        public HttpResponseMessage getGRNReport(string grncode, int grnid)
        {
            return MISResponse.Return(service.getGRNReport(grncode, grnid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/grn/approve/save/{empid}/{grncode}")]
        public HttpResponseMessage approveGRN(string empid, string grncode)
        {
            return MISResponse.Return(service.approveGRN(empid, grncode), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/purchase/order/grn/list/{pocode}/{poid}")]
        public HttpResponseMessage getPurchaseOrderGRNList(string pocode, int poid)
        {
            return MISResponse.Return(service.getPurchaseOrderGRNList(pocode, poid), service.Error, Request);
        }

        [HttpDelete]
        [Route("~/api/inventory/np/grn/cancel/{cancelby}/{grncode}/{remark}")]
        public HttpResponseMessage cancelGRN(string cancelby, string grncode, string remark)
        {
            return MISResponse.Return(service.cancelGRN(cancelby, grncode, remark), service.Error, Request);
        }

        // QRN
        [HttpPost]
        [Route("~/api/inventory/np/qrn/save")]
        public HttpResponseMessage saveQRN([FromBody] QRNNewDTO QRNData)
        {
            return MISResponse.Return(service.saveQRNM(QRNData), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/grn/status/report/{suppliercode}/{datefrom}/{dateto}")]
        public HttpResponseMessage getGRNStatusReportNP(string suppliercode, string datefrom, string dateto)
        {
            return MISResponse.Return(service.getGRNStatusReportNP(suppliercode, datefrom, dateto), service.Error, Request);
        }
    }
}