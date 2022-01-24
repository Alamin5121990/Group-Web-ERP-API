using AutoMapper;
using System.Collections.Generic;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.Procurement.CS;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.Inventory.ComparativeStudy;

namespace WebERPAPI.BusinessLogic.Map
{
    public class ComparativeStudyNPMap
    {
        public Inventory_Comparative_Study map(CommonDataEntryClass source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommonDataEntryClass, Inventory_Comparative_Study>()
                .ForMember(dest => dest.CreatedByID, option => option.MapFrom(src => src.EmployeeCode));
            });

            return config.CreateMapper().Map<CommonDataEntryClass, Inventory_Comparative_Study>(source);
        }

        public List<Inventory_Comparative_Study_Details> map(List<ComparativeStudyDetailsNew> source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ComparativeStudyDetailsNew, Inventory_Comparative_Study_Details>();
            });

            return config.CreateMapper().Map<List<ComparativeStudyDetailsNew>, List<Inventory_Comparative_Study_Details>>(source);
        }

        public Comparative_Study_StatusComment map(StatusCommentNewDto source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StatusCommentNewDto, Comparative_Study_StatusComment>();
            });

            return config.CreateMapper().Map<StatusCommentNewDto, Comparative_Study_StatusComment>(source);
        }
    }
}