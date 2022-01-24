using System.Net.Http;
using System.Web.Http;
using WebERPAPI.BusinessLogic.Inventory;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.Controllers.Inventory
{
    [Authorize]
    public class InventoryNPController : ApiController
    {
        private InventorySettings service = new InventorySettings();

        [HttpGet]
        [Route("~/api/inventory/type/list")]
        public HttpResponseMessage getInventoryTypes()
        {
            return MISResponse.Return(service.getInventoryTypes(), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/type/save")]
        public HttpResponseMessage saveInventoryTypes([FromBody] CommonDataEntryClass Data)
        {
            return MISResponse.Return(service.saveInventoryTypes(Data), service.Error, Request);
        }

        [HttpDelete]
        [Route("~/api/inventory/type/delete/{typeid}/{employeeid}")]
        public HttpResponseMessage deleteInventoryType(int typeid, string employeeid)
        {
            return MISResponse.Return(service.deleteInventoryType(typeid, employeeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/store/list/{inventorytypeid}")]
        public HttpResponseMessage getInventoryStores(int inventorytypeid)
        {
            return MISResponse.Return(service.getInventoryStores(inventorytypeid), service.Error, Request);
        }

        //STORE

        [HttpPost]
        [Route("~/api/inventory/store/save")]
        public HttpResponseMessage saveInventoryStore([FromBody] CommonDataEntryClass Data)
        {
            return MISResponse.Return(service.saveInventoryStore(Data), service.Error, Request);
        }

        // will be deleted
        [HttpGet]
        [Route("~/api/inventory/type/store/list")]
        public HttpResponseMessage getInventoryTypesAndStores()
        {
            return MISResponse.Return(service.getInventoryTypesAndStores(), service.Error, Request);
        }

        //new version
        [HttpGet]
        [Route("~/api/inventory/type/store/list/{employeeid}")]
        public HttpResponseMessage getInventoryTypesAndStores(string employeeid)
        {
            return MISResponse.Return(service.getInventoryTypesAndStores(employeeid), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/type/store/save")]
        public HttpResponseMessage saveInventoryTypeAndStore([FromBody] CommonDataEntryClass Data)
        {
            return MISResponse.Return(service.saveInventoryTypeAndStore(Data), service.Error, Request);
        }

        //[HttpDelete]
        //[Route("~/api/inventory/stores/delete/{typeid}/{employeeid}")]
        //public HttpResponseMessage deleteInventoryType(int typeid, string employeeid)
        //{
        //    return MISResponse.Return(service.deleteInventoryType(typeid, employeeid), service.Error, Request);
        //}

        //ITEM GROUP

        [HttpGet]
        [Route("~/api/inventory/item/main/group/list/{inventorytypeid}")]
        public HttpResponseMessage getItemGroupList(int inventorytypeid)
        {
            return MISResponse.Return(service.getItemGroupList(inventorytypeid), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/item/main/group/save")]
        public HttpResponseMessage saveItemMainGroup([FromBody] ItemGroupNew Data)
        {
            return MISResponse.Return(service.saveItemMainGroup(Data), service.Error, Request);
        }

        [HttpDelete]
        [Route("~/api/inventory/item/main/group/delete/{groupid}/{employeeid}")]
        public HttpResponseMessage deleteItemMainGroup(int groupid, string employeeid)
        {
            return MISResponse.Return(service.deleteItemMainGroup(groupid, employeeid), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/requisition/subgroup/supplier/save")]
        public HttpResponseMessage saveSubGroupSupplier([FromBody] CommonDataEntryClass Data)
        {
            return MISResponse.Return(service.saveSubGroupSupplier(Data), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/item/subgroup/suppliers/{subgroupid}")]
        public HttpResponseMessage getSubGroupSuppliers(int subgroupid)
        {
            return MISResponse.Return(service.getSubGroupSuppliers(subgroupid), service.Error, Request);
        }

        [HttpDelete]
        [Route("~/api/inventory/item/subgroup/suppliers/delete/{subgroupid}/{suppliercode}/{employeeid}")]
        public HttpResponseMessage deleteSubGroupSupplier(int subgroupid, string suppliercode, string employeeid)
        {
            return MISResponse.Return(service.deleteSubGroupSupplier(subgroupid, suppliercode, employeeid), service.Error, Request);
        }

        //SUB GROUP

        [HttpGet]
        [Route("~/api/inventory/item/sub/group/list/{maingroupid}")]
        public HttpResponseMessage getItemSubGroupList(int maingroupid)
        {
            return MISResponse.Return(service.getItemSubGroupList(maingroupid), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/item/sub/group/save")]
        public HttpResponseMessage saveItemSubGroup([FromBody] ItemGroupNew Data)
        {
            return MISResponse.Return(service.saveItemSubGroup(Data), service.Error, Request);
        }

        [HttpDelete]
        [Route("~/api/inventory/item/sub/group/delete/{groupid}/{employeeid}")]
        public HttpResponseMessage deleteItemSubGroup(int groupid, string employeeid)
        {
            return MISResponse.Return(service.deleteItemSubGroup(groupid, employeeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/item/sub/group/specification/{subgroupid}")]
        public HttpResponseMessage getItemSubGroupSpecification(int subgroupid)
        {
            return MISResponse.Return(service.getItemSubGroupSpecification(subgroupid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/item/sub/group/specification/{subgroupid}/{inventorytypeid}")]
        public HttpResponseMessage getInventorySubGroupSpecification(int subgroupid, int inventorytypeid)
        {
            return MISResponse.Return(service.getInventorySubGroupSpecification(subgroupid, inventorytypeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/specification/{inventorytypeid}")]
        public HttpResponseMessage getInventorySpecification(int inventorytypeid)
        {
            return MISResponse.Return(service.getInventorySpecification(inventorytypeid), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/item/sub/group/specification/save")]
        public HttpResponseMessage saveItemSubGroupSpecification([FromBody] CommonDataEntryClass Data)
        {
            return MISResponse.Return(service.saveItemSubGroupSpecification(Data), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/item/specifications/{subgroupid}/{itemid}")]
        public HttpResponseMessage getItemSpecifications(int subgroupid, int itemid)
        {
            return MISResponse.Return(service.getItemSpecifications(subgroupid, itemid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/item/addupdate/specifications/{inventorytypeid}/{subgroupid}/{itemid}")]
        public HttpResponseMessage getInventoryItemSpecifications(int inventorytypeid, int subgroupid, int itemid)
        {
            return MISResponse.Return(service.getInventoryItemSpecifications(subgroupid, itemid, inventorytypeid), service.Error, Request);
        }

        // VERSION & SPECIFICATION

        [HttpGet]
        [Route("~/api/inventory/item/specification/list/{inventorytypeid}")]
        public HttpResponseMessage getItemSpecificationList(int inventorytypeid)
        {
            return MISResponse.Return(service.getItemSpecificationList(inventorytypeid), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/item/specification/save")]
        public HttpResponseMessage saveItemSpecification([FromBody] CommonDataEntryClass Data)
        {
            return MISResponse.Return(service.saveItemSpecification(Data), service.Error, Request);
        }

        [HttpDelete]
        [Route("~/api/inventory/item/specification/delete/{id}/{employeeid}")]
        public HttpResponseMessage deleteItemSpecification(int id, string employeeid)
        {
            return MISResponse.Return(service.deleteItemSpecification(id, employeeid), service.Error, Request);
        }

        // REQUISITION ITEM

        [HttpGet]
        [Route("~/api/inventory/version/state/list")]
        public HttpResponseMessage getVersionStates()
        {
            return MISResponse.Return(service.getVersionStates(), service.Error, Request);
        }

        // ITEM
        [HttpPost]
        [Route("~/api/inventory/item/save")]
        public HttpResponseMessage saveInventoryItem([FromBody] InventoryItemNew Data)
        {
            var data = service.saveInventoryItem(Data);
            var error = service.Error;
            var req = Request;

            return MISResponse.Return(data, error, req);
        }


        // ITEM VERSION
        [HttpPost]
        [Route("~/api/inventory/item/version/save")]
        public HttpResponseMessage saveInventoryItemVersion([FromBody] InventoryItemVersionNew Data)
        {
            return MISResponse.Return(service.saveInventoryItemVersion(Data), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/item/list/{subgroupid}")]
        public HttpResponseMessage getInventoryItems(int subgroupid)
        {
            return MISResponse.Return(service.getInventoryItems(subgroupid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/item/usage/type/list")]
        public HttpResponseMessage getItemUsageType()
        {
            return MISResponse.Return(service.getItemUsageType(), service.Error, Request);
        }

        //Unit of measurment CRUD Start

        [HttpGet]
        [Route("~/api/inventory/uom/list")]
        public HttpResponseMessage getUOMList()
        {
            return MISResponse.Return(service.getUOMList(), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/uom/add")]
        public HttpResponseMessage addUOM([FromBody] UOMDto uom)
        {
            return MISResponse.Return(service.AddUOM(uom), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/uom/update")]
        public HttpResponseMessage updateUOM([FromBody] UOMDto uom)
        {
            return MISResponse.Return(service.updateUOM(uom), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/uom/delete/")]
        public HttpResponseMessage deleteUOM([FromBody] UOMDto uom)
        {
            return MISResponse.Return(service.deleteUOM(uom), service.Error, Request);
        }

        //Unit of measurment CRUD End

        [HttpGet]
        [Route("~/api/non/production/item/purchase/history/{itemid}")]
        public HttpResponseMessage nonProductionItemHistory(int itemid)
        {
            return MISResponse.Return(service.nonProductionItemHistory(itemid), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/non/production/inventory/item/sesrch/list/")]
        public HttpResponseMessage getInventoryAllItemListAndSearch([FromBody] InventoryItemListSearchPostDto data)
        {
            return MISResponse.Return(service.getInventoryAllItemListAndSearch(data), service.Error, Request);
        }
    }
}