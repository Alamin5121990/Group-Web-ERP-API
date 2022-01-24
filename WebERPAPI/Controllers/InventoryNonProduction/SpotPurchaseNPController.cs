using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.Controllers.InventoryNonProduction
{
    public class SpotPurchaseNPController : ApiController
    {
        private SpotPurchaseNP service = new SpotPurchaseNP();

        [HttpGet]
        [Route("~/api/inventory/requisition/for/spot/purchase/{employeeid}")]
        public HttpResponseMessage getRequisitionsForSpotPurchase(int employeeid)
        {
            return MISResponse.Return(service.getRequisitionsForSpotPurchase(employeeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/requisition/for/spot/purchase/approvallist")]
        public HttpResponseMessage getSpotPurchaseApprovalList()
        {
            return MISResponse.Return(service.getSpotPurchaseApprovalList(), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/requisition/for/spot/purchase/save")]
        public HttpResponseMessage saveSpotPurchaseNP(SpotPurchasesaveDto spotPurchase)
        {
            return MISResponse.Return(service.saveSpotPurchase(spotPurchase), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/spot/purchase/report/{pocode}")]
        public HttpResponseMessage getSpotPurchaseReport(string pocode)
        {
            return MISResponse.Return(service.getSpotPurchaseReport(pocode), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/spot/purchase/approve/{pocode}/{employeeid}/{approveremark}")]
        public HttpResponseMessage SpotPurchaseApprove(string pocode, int employeeid, string approveremark)
        {
            return MISResponse.Return(service.SpotPurchaseApprove(pocode, employeeid, approveremark), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/spot/purchase/supplier/list/")]
        public HttpResponseMessage SpotPurchasesupplierList()
        {
            return MISResponse.Return(service.SpotPurchasesupplierList(), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/spot/purchase/list/by/supplier/{supplierid}")]
        public HttpResponseMessage getSpotPOlistBySupplier(string supplierid)
        {
            return MISResponse.Return(service.getSpotPOlistBySupplier(supplierid), service.Error, Request);
        }
    }
}