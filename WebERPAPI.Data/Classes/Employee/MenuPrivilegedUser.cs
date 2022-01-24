using System;

namespace LabaidMIS.Data.Classes.Employee
{
    public class MenuPrivilegedUser
    {
        public string EmployeeID { get; set; }
        public int UserID { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Nullable<System.DateTime> JoinningDate { get; set; }
        public string ProfileImagename { get; set; }
        public string SignatureFilename { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> TotalRequest { get; set; }
    }

    public class UserFavoriteMenus
    {
        public string MenuName { get; set; }
        public string Route { get; set; }
    }

    public class UserOfficeEmailDetails
    {
        public string Email { get; set; }
        public string EmailPassword { get; set; }
    }

    public class Departments
    {
        public string Department { get; set; }
    }

    public class MulitpleUserPrivilege
    {
        public int MenuID { get; set; }
        public string UserIds { get; set; }
        public int CreatedById { get; set; }
    }

    public class NewPrivilegeDetails
    {
        public string privilegedetails { get; set; }
    }

    public class UserSMS
    {
        public string RecipientMobileNo { get; set; }
        public string RecipientEmployeeID { get; set; }
        public string SenderEmployeeID { get; set; }
        public string SMSContent { get; set; }
        public string Reason { get; set; }
    }
}