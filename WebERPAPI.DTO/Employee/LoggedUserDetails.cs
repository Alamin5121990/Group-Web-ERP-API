using System;

namespace WebERPAPI.DTO.Employee
{
    public class LoggedUserDetails2
    {
        public Nullable<int> id { get; set; }
        public Nullable<int> userid { get; set; }
        public string usercode { get; set; }
        public string employeeid { get; set; }
        public string firstname { get; set; }
        public string employeename { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string department { get; set; }
        public string designation { get; set; }
        public string locationname { get; set; }
        public string profileimagename { get; set; }
        public string signaturefilename { get; set; }
        public string depotcode { get; set; }
        public string locationcode { get; set; }
        public string locationlevel { get; set; }
        public Boolean isitlogin { get; set; }
        public Nullable<DateTime> DOB { get; set; }
    }

    public class UserPrivilegeNew
    {
        public Nullable<int> MenuID { get; set; }
        public string MenuName { get; set; }
        public string Route { get; set; }
    }
}