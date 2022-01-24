using AutoMapper;
using WebERPAPI.DTO.User.Complain;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.BusinessLogic.Map
{
    public class User_ComplainsMap
    {
        public User_Complains map(UserComplainsNewDto source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserComplainsNewDto, User_Complains>();
            });

            return config.CreateMapper().Map<UserComplainsNewDto, User_Complains>(source);
        }
    }
}