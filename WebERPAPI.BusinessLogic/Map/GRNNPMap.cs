using AutoMapper;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.BusinessLogic.Map
{
    public class GRNNPMap
    {
        public Inventory_GRN map(GRNNewDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GRNNewDTO, Inventory_GRN>();
            });
            return config.CreateMapper().Map<GRNNewDTO, Inventory_GRN>(source);
        }

        public Inventory_GRN_Items map(GRNNewItemsDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GRNNewItemsDTO, Inventory_GRN_Items>();
            });

            return config.CreateMapper().Map<GRNNewItemsDTO, Inventory_GRN_Items>(source);
        }

        public Inventory_QRN map(QRNNewDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QRNNewDTO, Inventory_QRN>();
            });
            return config.CreateMapper().Map<QRNNewDTO, Inventory_QRN>(source);
        }

        public Inventory_QRN_Items map(QRNNewItemsDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QRNNewItemsDTO, Inventory_QRN_Items>();
            });

            return config.CreateMapper().Map<QRNNewItemsDTO, Inventory_QRN_Items>(source);
        }

        public Inventory_UserStores map(UserStoreNewDTO UserStore)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserStoreNewDTO, Inventory_UserStores>();
            });

            return config.CreateMapper().Map<UserStoreNewDTO, Inventory_UserStores>(UserStore);
        }
    }
}