using System.Collections.Generic;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Employee;
using WebERPAPI.DTO.User;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.Data.Repository
{
    public interface IUserRepositories
    {
        bool createUserAccount(NewUserDetails NewUser);

        bool employeeImageGenerate();

        EmployeeDetails getEmployeeDetails(string EmployeeID);

        string getEmailCC(string EmailCC, string SenderEmail);

        string getEmailSignature(string EmployeeCode);

        List<LastNotification> getLastNotification(string UserID, string LastNotificationID);

        List<EmployeesByLocationCode> getLocationCodeWiseEmployeeList(string LocationID);

        List<SalesManagerEmployee> getLocationWiseEmployeeList(string LocationLevel, string ParentLocationID);

        List<EmployeeDetails> getOfficeEmployees(string LocationID);

        List<EmployeeDetails> getOfficeEmployeeDetailsWithImages(string LocationID);

        List<SalesManagerEmployeeReport> getSalesManagerEmployees();

        List<SalesManagerOrganizationalChart> getSalesManagerOrgChart(string LocationLevel, string ParentLocationID);

        List<UserFavoriteMenus> getUserFavoriteMenus(string UserID);

        List<UserMenuBrowsingHistory> getUserMenuBrowsingHistory(string UserID);

        UserOfficeEmailDetails getUserOfficeEmailDetails(string EmployeeCode);

        List<UserPrivilegeNew> getUserPrivilegeNewList(string UserId);

        List<UserPrivilege> getUserPrivileges(int UserID);

        LoggedUserDetails getUserShortDetails(string EmployeeID);

        bool saveNewNotification(int UserID, int RecipientID, string Title, string Message);

        bool saveNewNotification(string UserID, string RecipientID, string Title, string Message);

        bool saveUserLogDetails(int userID, string userDetails);

        bool saveUserPrivilege(int UserID, int MenuId, int Indx, bool action, int UpdatedById);

        List<EmployeeDetails> searchEmployee(string SearchText);

        bool sendEmail(string EmployeeCode, string EmailTo, string EmailCC, string Subject, string HtmlContent);

        bool sendUserSMS(UserSMS sms);

        LoggedUserDetails2 setITLoging(string EmployeeCode);

        int updateExistingImage(string ImageSourceLocation);

        bool updateLogDetails(int UserID, string GUID, string DeviceInfo, string LocationInfo);

        bool updateUserContact(EmployeeDetails emp);

        bool updateUserEmailPassword(int UserID, string NewPassword);

        bool updateUserPassword(int UserID, string CurrentPassword, string NewPassword);

        bool uploadEmployeeProfilePicture(string employeeID, string ImageLocation);

        bool uploadEmployeeSignature(string employeeID, string ImageLocation);
    }
}