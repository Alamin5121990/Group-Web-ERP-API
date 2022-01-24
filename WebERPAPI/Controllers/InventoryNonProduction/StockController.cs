using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using WebERPAPI.BusinessLogic.InventoryNonProduction;
using WebERPAPI.DTO;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.Controllers.InventoryNonProduction
{
    public class StockController : ApiController
    {
        private ItemStock service = new ItemStock();

        [HttpGet]
        [Route("~/api/inventory/item/stock/{storeid}/{maingroupid}/{itemid}/{searchtext}")]
        public HttpResponseMessage getItemStock(int storeid, int maingroupid, int itemid, string searchtext)
        {
            return MISResponse.Return(service.getItemStock(storeid, maingroupid, itemid, searchtext), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/all/item/stock/{storeid}/{maingroupid}")]
        public HttpResponseMessage getItemStockList(int storeid, int maingroupid)
        {
            return MISResponse.Return(service.getItemStockList(storeid, maingroupid), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/inventory/item/stock/transfer/")]
        public HttpResponseMessage ItemStockTransfer(List<InventoryItemStockTransferDto> list)
        {
            return MISResponse.Return(service.ItemStockTransfer(list), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/item/stock/receive/list/{storeid}")]
        public HttpResponseMessage getStockTransitList(int storeid)
        {
            return MISResponse.Return(service.getStockTransitList(storeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/item/stock/receive/save/{transitid}/{employeeid}")]
        public HttpResponseMessage itemStockReceive(int transitid, string employeeid)
        {
            return MISResponse.Return(service.itemStockReceive(transitid, employeeid), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/inventory/item/stock/update/history/{storeid}/{itemid}")]
        public HttpResponseMessage getItemStockUpdateHistory(int storeid, int itemid)
        {
            return MISResponse.Return(service.getItemStockUpdateHistory(storeid, itemid), service.Error, Request);
        }

    }
}