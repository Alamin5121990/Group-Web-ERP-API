using System;
using System.Net.Http;
using System.Web.Http;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.DTO;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.Controllers.InventoryNonProduction
{
    public class ConsumptionRequisitionController : ApiController
    {
        private ConsumptionRequisition service = new ConsumptionRequisition();

     


        [HttpGet]
        [Route("~/api/inventory/np/consumption/requisition/approval/pending/{employeeid}")]
        public HttpResponseMessage getRequisitionApprovalPending(string employeeid)
        {
            return MISResponse.Return(service.getRequisitionsApprovalPending(employeeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/consumption/requisition/list/{employeeid}")]
        public HttpResponseMessage getRequisitionList(string employeeid)
        {
            return MISResponse.Return(service.getRequisitionList(employeeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/consumption/requisition/report/{requisitioncode}/{requisitionid}")]
        public HttpResponseMessage getRequisitionReport(string requisitioncode, int requisitionid)
        {
            return MISResponse.Return(service.getRequisitionReport(requisitioncode, requisitionid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/consumption/requisition/for/approval/item/issue/{employeeid}")]
        public HttpResponseMessage getRequisitionForApprovalItemIssue(string employeeid)
        {
            return MISResponse.Return(service.getRequisitionForApprovalItemIssue(employeeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/consumption/requisition/for/item/issue/{employeeid}")]
        public HttpResponseMessage getRequisitionForItemIssue(string employeeid)
        {
            return MISResponse.Return(service.getRequisitionForItemIssue(employeeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/consumption/requisition/item/stockout/report/{fromdate}/{todate}")]
        public HttpResponseMessage getConsumptionItemStockout(DateTime fromdate, DateTime todate)
        {
            return MISResponse.Return(service.getConsumptionItemStockout(fromdate, todate), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/consumption/requisition/item/stockin/report/{fromdate}/{todate}")]
        public HttpResponseMessage getConsumptionItemStockin(DateTime fromdate, DateTime todate)
        {
            return MISResponse.Return(service.getConsumptionItemStockin(fromdate, todate), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/item/list/{employeeid}/{searchtext1}/{searchtext2}")]
        public HttpResponseMessage getEmployeeInventoryItems(string employeeid, string searchtext1, string searchtext2)
        {
            return MISResponse.Return(service.getEmployeeInventoryItems(employeeid, searchtext1, searchtext2), service.Error, Request);
        }

        //[HttpGet]
        //[Route("~/api/inventory/np/consumption/requisition/status/report/{requisitioncode}/{requisitionid}")]
        //public HttpResponseMessage getRequisitionReport(string requisitioncode, int requisitionid)
        //{
        //    return MISResponse.Return(service.getRequisitionReport(requisitioncode, requisitionid), service.Error, Request);
        //}
    }
}