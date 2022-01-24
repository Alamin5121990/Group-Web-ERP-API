using AutoMapper;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.BusinessLogic.Map
{
    public class ItemStockOpeningMap
    {
        public Inventory_Stock_Opening map(ItemStockOpeningNewDto source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItemStockOpeningNewDto, Inventory_Stock_Opening>();
            });

            return config.CreateMapper().Map<ItemStockOpeningNewDto, Inventory_Stock_Opening>(source);
        }
    }
}