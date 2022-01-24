using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.BusinessLogic.Map
{
    public class SpotPurchaseMap
    {
        public SpotPurchasesaveDto map(Inventory_Spot_Purchase source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Inventory_Spot_Purchase, SpotPurchasesaveDto>();
            });

            return config.CreateMapper().Map<Inventory_Spot_Purchase, SpotPurchasesaveDto>(source);
        }

        public SpotPurchaseDetailDto Detailsmap(Inventory_Spot_Purchase_Details source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Inventory_Spot_Purchase_Details, SpotPurchaseDetailDto>();
            });

            return config.CreateMapper().Map<Inventory_Spot_Purchase_Details, SpotPurchaseDetailDto>(source);
        }
    }
}