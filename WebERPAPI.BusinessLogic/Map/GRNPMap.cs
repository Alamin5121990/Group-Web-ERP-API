using AutoMapper;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.Inventory.GRN;

namespace WebERPAPI.BusinessLogic.Map
{
    public class GRNPMap
    {
        public GRNMaster map(GRNMasterDto source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GRNMasterDto, GRNMaster>();
            });
            return config.CreateMapper().Map<GRNMasterDto, GRNMaster>(source);
        }

        public GRNDetail GRNDetailMap(GRNDetailDto source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GRNDetailDto, GRNDetail>();
            });
            return config.CreateMapper().Map<GRNDetailDto, GRNDetail>(source);
        }

        public GRNVatDto GRNVATMap(GRNVat source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GRNVat, GRNVatDto>();
            });
            return config.CreateMapper().Map<GRNVat, GRNVatDto>(source);
        }
    }
}