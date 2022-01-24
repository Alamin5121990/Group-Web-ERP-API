using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.DTO;

namespace WebERPAPI.Controllers.InventoryNonProduction
{
    [Authorize]
    public class QuotationNPController : ApiController
    {
        private QuotationNP service = new QuotationNP();

        [HttpGet]
        [Route("~/api/user/inventory/type/list/{employeeid}")]
        public HttpResponseMessage getUserInventoryTypeList(string employeeid)
        {
            return MISResponse.Return(service.getUserInventoryTypeList(employeeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/user/main/group/list/{employeeid}/{inventorytypeid}")]
        public HttpResponseMessage getUserMainGroupList(string employeeid, int inventorytypeid)
        {
            return MISResponse.Return(service.getUserMainGroupList(employeeid, inventorytypeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/requisition/pending/list/{empid}")]
        public HttpResponseMessage getRequisitionNPPending(int empid)
        {
            return MISResponse.Return(service.getRequisitionNPPending(empid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/requisition/suppliers/{requisitionid}")]
        public HttpResponseMessage getRequisitionSuppliersNP(int requisitionid)
        {
            return MISResponse.Return(service.getRequisitionSuppliersNP(requisitionid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/quotation/new/{requisitionid}")]
        public HttpResponseMessage getQuotationNew(int requisitionid)
        {
            return MISResponse.Return(service.getQuotationNew(requisitionid), service.Error, Request);
        }

        // QUOTATION INVITATION

        [HttpPost]
        [AllowAnonymous]
        [Route("~/api/inventory/np/quotation/invite")]
        public HttpResponseMessage inviteQuotation()
        {
            CommonDataEntryClass Quotation = new CommonDataEntryClass();
            var httpForm = HttpContext.Current.Request.Form;

            Quotation.Date = Convert.ToDateTime(httpForm["Date"]);
            Quotation.Data = httpForm["Data"];
            Quotation.Remarks = httpForm["Remarks"];
            Quotation.EmployeeCode = httpForm["EmployeeCode"];

            List<HttpPostedFileBase> AttachmentFiles = new List<HttpPostedFileBase>();
            List<string> AttachmentFileNames = new List<string>();

            foreach (string file in HttpContext.Current.Request.Files)
            {
                AttachmentFiles.Add(new HttpPostedFileWrapper(HttpContext.Current.Request.Files[file]));
            }

            var fullPath = HttpContext.Current.Server.MapPath("~/StaticContent/emailformat/");
            var filePath = Path.Combine(fullPath, "QuatitionInvitationEmailFormatNP.html");

            if (AttachmentFiles.Count == 0) return MISResponse.Return(service.inviteQuotation(Quotation, filePath), service.Error, Request);
            else
            {
                //first upload the files to folder

                foreach (var item in AttachmentFiles)
                {
                    string nameAndLocation = "~/EmailAttachmentFiles/" + item.FileName;
                    item.SaveAs(System.Web.HttpContext.Current.Server.MapPath(nameAndLocation));
                    AttachmentFileNames.Add(item.FileName);
                }
                return MISResponse.Return(service.inviteQuotationWithAttachment(Quotation, filePath, AttachmentFileNames), service.Error, Request);
            }
        }

        // QUOTATION RECEIVE
        [HttpGet]
        [Route("~/api/inventory/np/quotations/{empid}/{actiongroupid}")]
        public HttpResponseMessage getQuotationsNonProduction(int empid, int actiongroupid)
        {
            return MISResponse.Return(service.getQuotationsNonProduction(empid, actiongroupid), service.Error, Request);
        }

        // QUOTATION cancel list
        [HttpGet]
        [Route("~/api/inventory/np/quotations/cancel/list/{empid}")]
        public HttpResponseMessage getQuotationsCancelList(int empid)
        {
            return MISResponse.Return(service.getQuotationsCancelList(empid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/quotations/details/{quotationid}/{quotationcode}")]
        public HttpResponseMessage getQuotationsDetailsNP(int quotationid, string quotationcode)
        {
            return MISResponse.Return(service.getQuotationsDetailsNP(quotationid, quotationcode), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/np/bill/payment/type/list")]
        public HttpResponseMessage getBillPaymentTypes()
        {
            return MISResponse.Return(service.getBillPaymentTypes(), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/np/quotation/receive/save")]
        public HttpResponseMessage receiveQuotation([FromBody] CommonDataEntryClass Quotation)
        {
            return MISResponse.Return(service.receiveQuotation(Quotation), service.Error, Request);
        }

        [HttpDelete]
        [Route("~/api/inventory/np/quotation/cancel/{quotationid}/{remark}/{empid}")]
        public HttpResponseMessage cancelQuotation(int quotationid, string remark, string empid)
        {
            return MISResponse.Return(service.cancelQuotation(quotationid, remark, empid), service.Error, Request);
        }
    }
}