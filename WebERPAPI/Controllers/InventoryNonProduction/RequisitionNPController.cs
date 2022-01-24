using System.Net.Http;
using System.Web.Http;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.Procurement;

namespace WebERPAPI.Controllers.Inventorynp
{
    [Authorize]
    public class RequisitionNPController : ApiController
    {
        private RequisitionNP service = new RequisitionNP();

        /// --------------------
        //NEW REQUISITION
        /// --------------------

        [HttpPost]
        [Route("~/api/inventory/requisition/create")]
        public HttpResponseMessage createInventoryRequisition([FromBody] InventoryRequisitionNew Data)
        {
            var response = service.createInventoryRequisition(Data);
            var error = service.Error;
            var request = Request;
            return MISResponse.Return(response, error, request);
        }

        [HttpGet]
        [Route("~/api/inventory/item/report/{itemid}/{itemcode}")]
        public HttpResponseMessage getItemReport(int itemid, string itemcode)
        {
            return MISResponse.Return(service.getItemReport(itemid, itemcode), service.Error, Request);
        }

        // REQUISITION SEARCH

        [HttpGet]
        [Route("~/api/inventory/requisition/search/{employeeid}/{inventorytypeid}/{datefrom}/{dateto}/{searchtext}")]
        public HttpResponseMessage getRequisitionsBySearch(int employeeid, int inventorytypeid, string datefrom, string dateto, string searchtext)
        {
            return MISResponse.Return(service.getRequisitionsBySearch(employeeid, inventorytypeid, datefrom, dateto, searchtext), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/requisition/pending/list/{inventorytypeid}")]
        public HttpResponseMessage getPendingRequisitionList(int inventorytypeid)
        {
            return MISResponse.Return(service.getPendingRequisitionList(inventorytypeid), service.Error, Request);
        }

        // -- 2 = VERIFIED, 3 = APPROVED
        [HttpGet]
        [Route("~/api/inventory/requisition/for/approval/{employeeid}/{actionid}")]
        public HttpResponseMessage getRequisitionsForApproval(int employeeid, int actionid)
        {
            return MISResponse.Return(service.getRequisitionsForApproval(employeeid, actionid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/item/uom/list")]
        public HttpResponseMessage getItemUOM()
        {
            return MISResponse.Return(service.getItemUOM(), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/requisition/verify")]
        public HttpResponseMessage verifyInventoryRequisition([FromBody] CommonDataEntryClass Data)
        {
            return MISResponse.Return(service.verifyInventoryRequisition(ActionGroup.VERIFIED, Data), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/requisition/approve")]
        public HttpResponseMessage approveInventoryRequisition([FromBody] CommonDataEntryClass Data)
        {
            return MISResponse.Return(service.verifyInventoryRequisition(ActionGroup.APPROVED, Data), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/requisition/{requisitionid}")]
        public HttpResponseMessage getRequisitionDetails(int requisitionid)
        {
            return MISResponse.Return(service.getRequisitionDetails(requisitionid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/account/currency/list")]
        public HttpResponseMessage getCurrencies()
        {
            return MISResponse.Return(service.getCurrencies(), service.Error, Request);
        }
        // REQUISITION REPORT

        [HttpGet]
        [Route("~/api/inventory/np/requisition/report/{requisitioncode}/{requisitionid}")]
        public HttpResponseMessage getRequisitionReport(string requisitioncode, int requisitionid)
        {
            return MISResponse.Return(service.getRequisitionReport(requisitioncode, requisitionid), service.Error, Request);
        }

        // INVENTORY PRIVILEGE

        [HttpGet]
        [Route("~/api/inventory/main/group/privilege/{inventorytypeid}/{employeeid}")]
        public HttpResponseMessage getInventoryPrivilege(int inventorytypeid, int employeeid)
        {
            return MISResponse.Return(service.getInventoryPrivilege(inventorytypeid, employeeid), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/main/group/privilege/save")]
        public HttpResponseMessage saveInventoryPrivilege([FromBody] InventoryPrivilegeNew Data)
        {
            return MISResponse.Return(service.saveInventoryPrivilege(Data), service.Error, Request);
        }

        //REQUISITION UPDATE

        [HttpPost]
        [Route("~/api/inventory/np/requisition/update")]
        public HttpResponseMessage updateInventoryRequisition([FromBody] InventoryRequisitionNew Data)
        {
            return MISResponse.Return(service.updateInventoryRequisition(Data), service.Error, Request);
        }

        [HttpDelete]
        [Route("~/api/inventory/requisition/item/delete/{requisitionid}/{itemid}/{employeeid}")]
        public HttpResponseMessage deleteRequisitionItem(int requisitionid, int itemid, string employeeid)
        {
            return MISResponse.Return(service.deleteRequisitionItem(requisitionid, itemid, employeeid), service.Error, Request);
        }

        [HttpDelete]
        [Route("~/api/inventory/np/item/delete/{itemid}/{employeeid}")]
        public HttpResponseMessage deleteInventoryItem(int itemid, string employeeid)
        {
            return MISResponse.Return(service.deleteInventoryItem(itemid, employeeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/requisition/type/list")]
        public HttpResponseMessage getRequisitionTypes()
        {
            return MISResponse.Return(service.getRequisitionTypes(), service.Error, Request);
        }

        //Cancel Requisition
        [HttpDelete]
        [Route("~/api/inventory/np/requisition/cancel/{id}/{remark}/{canceledby}")]
        public HttpResponseMessage cancelInventoryRequisition(int id, string remark, string canceledby)
        {
            return MISResponse.Return(service.cancelInventoryRequisition(id, remark, canceledby), service.Error, Request);
        }
    }
}