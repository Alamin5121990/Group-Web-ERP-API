using WebERPAPI.DTO.User.Complain;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.PROCESSERVER;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace WebERPAPI.Data.Repository.User
{
    public class UserComplainRepository
    {
        private SystemManagerGenericRepository<User_Complains> _complain = null;

        public UserComplainRepository()
        {
            _complain = new SystemManagerGenericRepository<User_Complains>();
        }

        // Find
        public List<User_Complain_Types> getUserComplainTypes()
        {
            return new SystemManagerGenericRepository<User_Complain_Types>().Find(t => t.IsActive == true).OrderBy(c => c.OrderNo).ToList();
        }

        // SAVE
        public User_Complains saveUserComplains(User_Complains Entity)
        {
            Entity.IsActive = true;
            Entity.CreatedOn = DateTime.Now;
            return _complain.Insert(Entity);
        }

        public Boolean saveUserComplainRecepients(int ComplainID, int EmployeeID, string NotifyTo)
        {
            return _complain.ExecuteCommand("saveUserComplainRecepients @ComplainID, @EmployeeID, @NotifyTo",
                new SqlParameter("@ComplainID", ComplainID), new SqlParameter("@EmployeeID", EmployeeID), new SqlParameter("@NotifyTo", NotifyTo));
        }

        public List<UserComplainsDto> getUserComplains()
        {
            return new SystemManagerGenericRepository<UserComplainsDto>().FindUsingSP("getUserComplains");
        }
    }
}