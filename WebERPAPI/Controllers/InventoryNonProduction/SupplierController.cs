using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebERPAPI.BusinessLogic.Inventory;
using WebERPAPI.DTO.Accounts;
using WebERPAPI.DTO.Inventory;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.Inventory;


namespace WebERPAPI.Controllers.InventoryNonProduction
{
    [Authorize]
    public class SupplierController : ApiController
    {
        private SupplierRepositories repo = new SupplierRepositories();

        private SupplierService service = new SupplierService();

        [HttpGet]
        [Route("~/api/inventory/supplier/list")]
        public HttpResponseMessage getSupplierList()
        {
            return MISResponse.Return(repo.getSupplierList(), repo.error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/supplier/indentor/list")]
        public HttpResponseMessage getSupplierAndIndentorList()
        {
            try
            {
                return MISResponse.Return(repo.getSupplierAndIndentorList(), repo.error, Request);
            }
            catch (Exception ex) { return MISResponse.Error(ex, Request); }
        }

        [HttpGet]
        [Route("~/api/inventory/supplier/profile/{suppliercode}")]
        public HttpResponseMessage getSupplierProfile(string suppliercode)
        {
            try
            {
                BillMasterRepositories bRepo = new BillMasterRepositories();

                // SUPPLIER INFO
                var supplierInfo = repo.getSupplierDetails(suppliercode);

                // PURCHASE HISTORY
                var purchaseHistory = repo.getSupplierPurchaseHistory(suppliercode);

                // BILL DETAILS
                var pendingBills = bRepo.getSupplierBills(suppliercode, 0, DateTime.Now.AddYears(-2).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                var settledBills = bRepo.getSupplierBills(suppliercode, 1, DateTime.Now.AddYears(-2).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));

                if (supplierInfo != null) return Request.CreateResponse(HttpStatusCode.OK, new { supplierInfo, purchaseHistory, pendingBills, settledBills });
                else return Request.CreateResponse(HttpStatusCode.OK, repo.error);
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }

        [HttpGet]
        [Route("~/api/inventory/supplier/details/{suppliercode}")]
        public HttpResponseMessage getSupplierDetails(string suppliercode)
        {
            try
            {
                return MISResponse.Return(repo.getSupplierDetails(suppliercode), repo.error, Request);
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }

        [HttpGet]
        [Route("~/api/inventory/supplier/pending/bills/summery/details/{datefrom}/{dateto}")]
        public HttpResponseMessage getMaterialProfile(string datefrom, string dateto)
        {
            try
            {
                BillMasterRepositories repo = new BillMasterRepositories();
                return MISResponse.Return(repo.getSupplierPendingMasterBillTotal(datefrom, dateto), repo.error, Request);
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }


        [HttpPost]
        [Route("~/api/inventory/supplier/update")]
        public HttpResponseMessage updateSupplier([FromBody] Supplier supplier)
        {
            try
            {
                return MISResponse.Return(repo.updateSupplier(supplier), repo.error, Request, "Successfully updated");
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }

        [HttpGet]
        [Route("~/api/inventory/purchase/order/supplier/list/{suppliertype}")]
        public HttpResponseMessage getPurchaseOrderSupplier(string suppliertype)
        {
            return MISResponse.Return(service.getPurchaseOrderSupplier(suppliertype), repo.error, Request);
        }

        // SUPPLIER COMPONENT CRUD

        [HttpGet]
        [Route("~/api/inventory/supplier/category/list/")]
        public HttpResponseMessage getSupplierCategoryList()
        {
            return MISResponse.Return(service.getSupplierCategoryList(), repo.error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/supplier/type/list/")]
        public HttpResponseMessage getSupplierTypeList()
        {
            return MISResponse.Return(service.getSupplierTypeList(), repo.error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/supplier/save")]
        public HttpResponseMessage saveSupplier(Supplier supplier)
        {
            return MISResponse.Return(service.saveSupplier(supplier), repo.error, Request);
        }

        //SUPPLIER SETTING COMPONENT API

        [HttpGet]
        [Route("~/api/inventory/supplier/setting/list/{TypeID}/{CategoryID}")]
        public HttpResponseMessage getSupplierListByTypeAndCategory(int TypeID, int CategoryID)
        {
            return MISResponse.Return(service.getSupplierListByTypeAndCategory(TypeID, CategoryID), repo.error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/supplier/setting/category/save")]
        public HttpResponseMessage saveSupplierCategory(Supplier_Categories item)
        {
            return MISResponse.Return(service.saveSupplierCategory(item), repo.error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/supplier/setting/type/save")]
        public HttpResponseMessage saveSupplierType(Supplier_Types item)
        {
            return MISResponse.Return(service.saveSupplierType(item), repo.error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/supplier/setting/category/update")]
        public HttpResponseMessage updateSupplierCategory(Supplier_Categories item)
        {
            return MISResponse.Return(service.updateSupplierCategory(item), repo.error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/supplier/setting/type/update")]
        public HttpResponseMessage updateSupplierType(Supplier_Types item)
        {
            return MISResponse.Return(service.updateSupplierType(item), repo.error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/supplier/setting/category/remove")]
        public HttpResponseMessage removeSupplierCategory(Supplier_Categories item)
        {
            return MISResponse.Return(service.removeSupplierCategory(item), repo.error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/supplier/setting/type/remove")]
        public HttpResponseMessage removeSupplierType(Supplier_Types item)
        {
            return MISResponse.Return(service.removeSupplierType(item), repo.error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/supplier/list/with/po/total")]
        public HttpResponseMessage getSupplierListWithPOAndBillTotal()
        {
            return MISResponse.Return(service.getSupplierListWithPOAndBillTotal(), repo.error, Request);
        }
    }
}