using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.Procurement.CS;

namespace WebERPAPI.Controllers.InventoryNonProduction
{
    [Authorize]
    public class ComparativeStudyNPController : ApiController
    {
        private ComparativeStudyNP service = new ComparativeStudyNP();

        [HttpGet]
        [Route("~/api/inventory/management/approval/{itemtype}/{employeeid}/{referencecode}")]
        public HttpResponseMessage getComparativeStudy(string itemtype, string employeeid, string referencecode)
        {
            return MISResponse.Return(service.ManagementApproval(itemtype, employeeid, referencecode), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/np/comparative/study/save")]
        public HttpResponseMessage saveComparativeStudy([FromBody] CommonDataEntryClass Quotation)
        {
            return MISResponse.Return(service.saveComparativeStudy(Quotation), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/np/comparative/study/update")]
        public HttpResponseMessage updateComparativeStudy([FromBody] CommonDataEntryClass CSData)
        {
            return MISResponse.Return(service.updateComparativeStudy(CSData), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/comparative/study/list/{empid}/{actiongroupid}")]
        public HttpResponseMessage getComparativeStudy(int empid, int actiongroupid)
        {
            return MISResponse.Return(service.getComparativeStudy(empid, "0", actiongroupid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/item/requisition/purchase/history/list/{requisitionid}")]
        public HttpResponseMessage getRequisitionItemPurchaseHistory(int requisitionid)
        {
            return MISResponse.Return(service.getItemPurchaseHistory(requisitionid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/comparative/study/report/{cscode}/{csid}")]
        public HttpResponseMessage getComparativeStudyReport(string cscode, int csid)
        {
            return MISResponse.Return(service.getComparativeStudyReport(cscode, csid), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/np/comparative/study/cancel")]
        public HttpResponseMessage cancelComparativeStudy([FromBody] CommonDataEntryClass Data)
        {
            return MISResponse.Return(service.cancelComparativeStudy(Data), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/comparative/study/status/report/{empid}/{inventoryid}")]
        public HttpResponseMessage getComparativeStudyStatusReport(int empid, int inventoryid)
        {
            return MISResponse.Return(service.getComparativeStudyStatusReport(empid, inventoryid), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/np/cs/list/approve/{employeeid}")]
        public HttpResponseMessage approveCSList(string employeeid, List<ComparativeStudyListNP> cslist)
        {
            return MISResponse.Return(service.approveCSList(cslist, employeeid), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/np/cs/list/recommend/{employeeid}")]
        public HttpResponseMessage recommendCSList(string employeeid, List<ComparativeStudyListNP> cslist)
        {
            return MISResponse.Return(service.recommendCSList(cslist, employeeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/comparative/study/items/purchase/history/{csid}")]
        public HttpResponseMessage getCSItemPurchaseHistory(string csid)
        {
            return MISResponse.Return(service.getCSItemPurchaseHistory(csid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/requisition/items/purchase/history/{rid}")]
        public HttpResponseMessage geRequisitionItemPurchaseHistory(int rid)
        {
            return MISResponse.Return(service.geRequisitionItemPurchaseHistory(rid), service.Error, Request);
        }
    }
}