using AutoMapper;
using WebERPAPI.DTO.Inventory.PurchaseOrdersNP;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.BusinessLogic.Map
{
    public class PurchaseOrderNPMap
    {
        public Inventory_Purchase_Orders map(PurchaseOrderNPNew source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PurchaseOrderNPNew, Inventory_Purchase_Orders>()
                .ForMember(dest => dest.CreatedByID, option => option.MapFrom(src => src.EmployeeCode));
            });

            return config.CreateMapper().Map<PurchaseOrderNPNew, Inventory_Purchase_Orders>(source);
        }

        public Inventory_Purchase_Order_Detail map(PurchaseOrderDetailsNew source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PurchaseOrderDetailsNew, Inventory_Purchase_Order_Detail>();
            });

            return config.CreateMapper().Map<PurchaseOrderDetailsNew, Inventory_Purchase_Order_Detail>(source);
        }
    }
}