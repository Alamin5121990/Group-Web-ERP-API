using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Employee;
using WebERPAPI.DTO.User;
using static WebERPAPI.DTO.EmployeeDetails;

namespace WebERPAPI.Data.Repository
{
    public class UserRepositories
    {
        private SystemManagerGenericRepository<tblUser> _user = null;
        public Exception error = new Exception();

        public UserRepositories()
        {
            _user = new SystemManagerGenericRepository<tblUser>();
        }
        public List<UserLocationDto> getLocationList()
        {
            return new SystemManagerGenericRepository<UserLocationDto>().FindUsingSP("getLocationList");
        }
        public List<EmployeeDetails> getOfficeEmployees(string LocationID)
        {
            try
            {
                var locationID = new SqlParameter("@LocationID", LocationID);
                using (HRMSEntities db = new HRMSEntities())
                {
                    return db.Database.SqlQuery<EmployeeDetails>("getOfficeActiveEmployees @LocationID,''", locationID).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<EmployeeDetails> searchEmployee(string SearchText)
        {
            try
            {
                SearchText = Library.JSONSerialize.DecodeBase64(SearchText);
                var searchText = new SqlParameter("@SearchText", SearchText);
                using (HRMSEntities db = new HRMSEntities())
                {
                    return db.Database.SqlQuery<EmployeeDetails>("getEmployeesSearch @SearchText", searchText).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<EmployeeDetails> getOfficeEmployeeDetailsWithImages(string LocationID)
        {
            try
            {
                var locationID = new SqlParameter("@LocationID", LocationID);
                using (HRMSEntities db = new HRMSEntities())
                {
                    return db.Database.SqlQuery<EmployeeDetails>("getOfficeEmployeeDetailsWithImages @LocationID,''", locationID).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public EmployeeDetails getEmployeeDetails(string EmployeeID)
        {
            try
            {
                var empid = new SqlParameter("@EmployeeID", EmployeeID);
                using (HRMSEntities db = new HRMSEntities())
                {
                    return db.Database.SqlQuery<EmployeeDetails>("getOfficeActiveEmployees '',@EmployeeID", empid).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<UserPrivilege> getUserPrivileges(int UserID)
        {
            try
            {
                var userid = new SqlParameter("@UserID", UserID);

                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    var Data = db.Database.SqlQuery<UserPrivilege>("getUserPrivilegedMenu @UserId", userid).ToList();
                    return Data;
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public Boolean sendEmailWithAttachment(string EmployeeCode, string EmailTo, string EmailCC, string Subject, string HtmlContent, List<string> attachments)
        {
            try
            {
                //Ignoring email If it comes from TEST SERVER
               

                LPLMailer mailer = new LPLMailer();
                UserOfficeEmailDetails emp = new UserOfficeEmailDetails();
                emp = getUserOfficeEmailDetails(EmployeeCode);

                if (emp.Email == null && emp.EmailPassword == null)
                {
                    emp = new UserOfficeEmailDetails();
                    emp.Email = "softadmin@labaidpharma.com";
                    emp.EmailPassword = "XaJ7@I1FkG";
                }
                else emp.EmailPassword = new LPLERP.Common.Encryption().DecryptWord(emp.EmailPassword);

                if (string.IsNullOrEmpty(emp.EmailPassword) || string.IsNullOrEmpty(emp.Email)) return false;

                var result = mailer.SendMailWithAttachment(emp.Email, emp.EmailPassword, EmailTo, getEmailCC(EmailCC, emp.Email), Subject, HtmlContent, true, attachments);

                if (result) return true;
                else
                {
                    error = mailer.error;
                    string allError = mailer.error.Message + ", " + mailer.MailError;
                    try
                    {
                        
                    }
                    catch (Exception ex)
                    {
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                try
                {
                   
                }
                catch { }
                error = ex;
                return false;
            }
        }

        public Boolean sendEmail(string EmployeeCode, string EmailTo, string EmailCC, string Subject, string HtmlContent)
        {
            try
            {
                // Ignoring email If it comes from TEST SERVER
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    if (db.Database.Connection.DataSource.ToString().IndexOf("42.6") > -1)
                    {
                        return false;
                    }
                }

                LPLMailer mailer = new LPLMailer();

                UserOfficeEmailDetails emp = getUserOfficeEmailDetails(EmployeeCode);

                if (emp == null)
                {
                    emp = new UserOfficeEmailDetails();
                    emp.Email = "softadmin@labaidpharma.com";
                    emp.EmailPassword = "XaJ7@I1FkG";
                }
                else emp.EmailPassword = new LPLERP.Common.Encryption().DecryptWord(emp.EmailPassword);

                if (string.IsNullOrEmpty(emp.EmailPassword) || string.IsNullOrEmpty(emp.Email)) return false;

                var result = mailer.SendMail(emp.Email, emp.EmailPassword, EmailTo, getEmailCC(EmailCC, emp.Email), Subject, HtmlContent, true);

                if (result) return true;
                else
                {
                    error = mailer.error;
                    string allError = mailer.error.Message + ", " + mailer.MailError;
                    try
                    {
                    }
                    catch (Exception ex)
                    {
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                try
                {
                }
                catch { }
                error = ex;
                return false;
            }
        }
        public Boolean saveUserPrivilege(int UserID, int MenuId, int Indx, Boolean action, int UpdatedById)
        {
            try
            {
                var privilege = new SystemManagerGenericRepository<Web_UserPrivileges>().Find(p => p.UserId == UserID && p.MenuId == MenuId).FirstOrDefault();

                if (privilege == null)
                {
                    // SAVE NEW
                    Web_UserPrivileges up = new Web_UserPrivileges();
                    up.MenuId = MenuId;
                    up.UserId = UserID;
                    if (Indx == 0) up.HasInsert = action;
                    else if (Indx == 1) up.HasUpdate = action;
                    else if (Indx == 2) up.HasDelete = action;
                    else if (Indx == 3) up.HasPrint = action;
                    else if (Indx == 4) up.HasFullAccess = action;
                    else if (Indx == 5) up.HasView = action;
                    else if (Indx == 6) up.HasReview = action;
                    else if (Indx == 7) up.HasVerify = action;
                    else if (Indx == 8) up.HasApprove = action;
                    else if (Indx == 9) up.HasRecommendation = action;
                    else if (Indx == 10) up.HasAudit = action;
                    up.UpdatedById = UpdatedById;
                    up.UpdatedOn = DateTime.Now;
                    new SystemManagerGenericRepository<Web_UserPrivileges>().Insert(up);
                }
                else
                {
                    //UPDATE

                    if (Indx == 0) privilege.HasInsert = action;
                    else if (Indx == 1) privilege.HasUpdate = action;
                    else if (Indx == 2) privilege.HasDelete = action;
                    else if (Indx == 3) privilege.HasPrint = action;
                    else if (Indx == 4) privilege.HasFullAccess = action;
                    else if (Indx == 5) privilege.HasView = action;
                    else if (Indx == 6) privilege.HasReview = action;
                    else if (Indx == 7) privilege.HasVerify = action;
                    else if (Indx == 8) privilege.HasApprove = action;
                    else if (Indx == 9) privilege.HasRecommendation = action;
                    else if (Indx == 10) privilege.HasAudit = action;

                    privilege.UpdatedById = UpdatedById;
                    privilege.UpdatedOn = DateTime.Now;
                    new SystemManagerGenericRepository<Web_UserPrivileges>().Update(privilege, p => p.PrivilegeId == privilege.PrivilegeId);
                }

                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public Employee getEmployeeDetailsByID(int? employeeID)
        {
            return new HRMSGenericRepository<Employee>().FindOne(i => i.ID == employeeID);
        }

        public Web_UserDevices updateLogDetails(Web_UserDevices details)
        {
            return new SystemManagerGenericRepository<Web_UserDevices>().Insert(details);
        }

        public Boolean updateUserContact(EmployeeDetails emp)
        {
            try
            {
                using (SystemManagerEntities sms = new SystemManagerEntities())
                {
                    tblUser user = sms.tblUsers.Where(u => u.EmployeeCode == emp.EmployeeID).FirstOrDefault();
                    if (user != null)
                    {
                        user.Email = emp.Email;
                        sms.SaveChanges();
                    }
                }

                using (HRMSEntities sms = new HRMSEntities())
                {
                    Employee employee = sms.Employees.Where(u => u.EmployeeID == emp.EmployeeID).FirstOrDefault();

                    if (employee != null)
                    {
                        employee.Email = emp.Email;
                        employee.Mobile = emp.Mobile;

                        sms.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public Boolean updateUserPassword(int UserID, string CurrentPassword, string NewPassword)
        {
            try
            {
                string currentPass = new LPLERP.Common.Encryption().EncryptWord(CurrentPassword);
                string encodedPass = new LPLERP.Common.Encryption().EncryptWord(NewPassword);

                using (SystemManagerEntities sms = new SystemManagerEntities())
                {
                    tblUser user = sms.tblUsers.Where(u => u.UserId == UserID).FirstOrDefault();
                    if (user != null)
                    {
                        if (user.Password.CompareTo(currentPass) == 0)
                        {
                            user.Password = encodedPass;
                            sms.SaveChanges();
                        }
                        else
                        {
                            error = new Exception("Incorrect current password");
                            return false;
                        }
                    }
                    else
                    {
                        error = new Exception("Failed to find user information");
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public Boolean updateUserEmailPassword(int UserID, string NewPassword)
        {
            try
            {
                string encodedPass = new LPLERP.Common.Encryption().EncryptWord(NewPassword);

                using (SystemManagerEntities sms = new SystemManagerEntities())
                {
                    tblUser user = sms.tblUsers.Where(u => u.UserId == UserID).FirstOrDefault();
                    if (user != null)
                    {
                        user.EmailPassword = encodedPass;
                        sms.SaveChanges();
                    }
                    else
                    {
                        error = new Exception("Failed to find user information");
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

    
        public List<SalesManagerEmployeeReport> getSalesManagerEmployees()
        {
            try
            {
                var locationLevel = new SqlParameter("@LocationLevelName", "ALL");
                var parentLocationID = new SqlParameter("@ParentLocationID", -1);

                using (Models.MIS.MISEntities db = new Models.MIS.MISEntities())
                {
                    var employees = db.Database.SqlQuery<SalesManagerEmployee>("getLocationWiseEmployees @LocationLevelName, @ParentLocationID", locationLevel, parentLocationID).ToList();

                    List<SalesManagerEmployeeReport> list = new List<SalesManagerEmployeeReport>();

                    for (int x = 0; x < 5; x++)
                    {
                        SalesManagerEmployeeReport sm = new SalesManagerEmployeeReport();
                        if (x == 0) sm.LocationName = "Operation Area";
                        else if (x == 1) sm.LocationName = "Zone";
                        else if (x == 2) sm.LocationName = "Region";
                        else if (x == 3) sm.LocationName = "Area";
                        else if (x == 4) sm.LocationName = "Territory";

                        sm.Employees = employees.Where(e => e.OrderNo == x).ToList();

                        list.Add(sm);
                    }

                    return list;
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<SalesManagerEmployee> getLocationWiseEmployeeList(string LocationLevel, string ParentLocationID)
        {
            try
            {
                if (LocationLevel.CompareTo("0") == 0) LocationLevel = "OA";
                else if (LocationLevel.CompareTo("1") == 0) LocationLevel = "ZONE";
                else if (LocationLevel.CompareTo("2") == 0) LocationLevel = "REGION";
                else if (LocationLevel.CompareTo("3") == 0) LocationLevel = "AREA";
                else if (LocationLevel.CompareTo("4") == 0) LocationLevel = "TERRITORY";

                var locationLevel = new SqlParameter("@LocationLevelName", LocationLevel);
                var parentLocationID = new SqlParameter("@ParentLocationID", ParentLocationID);

                using (Models.MIS.MISEntities db = new Models.MIS.MISEntities())
                {
                    return db.Database.SqlQuery<SalesManagerEmployee>("getLocationWiseEmployees @LocationLevelName, @ParentLocationID", locationLevel, parentLocationID).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<EmployeesByLocationCode> getLocationCodeWiseEmployeeList(string LocationID)
        {
            try
            {
                var locationCode = new SqlParameter("@LocationCode", LocationID);

                using (HRMSEntities db = new HRMSEntities())
                {
                    return db.Database.SqlQuery<EmployeesByLocationCode>("getOfficeEmployeeDetailsByLocationCode @LocationCode,1", locationCode).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

    
        public LoggedUserDetails getUserShortDetails(string EmployeeID)
        {
            try
            {
                using (HRMSEntities db = new HRMSEntities())
                {
                    var employeeID = new SqlParameter("@EmployeeID", EmployeeID);
                    return db.Database.SqlQuery<LoggedUserDetails>("getUserShortDetails @EmployeeID", employeeID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }


      
        public Boolean employeeImageGenerate()
        {
            try
            {
                using (HRMSEntities db = new HRMSEntities())
                {
                    var emps = db.Database.SqlQuery<EmployeesImage>("getEmployeesImage").ToList();

                    foreach (var empi in emps)
                    {
                        MemoryStream ms = new MemoryStream(empi.EmployeeImage);
                        //Image img = Image.FromStream(ms);
                        //img.Save(empi.EmployeeID, ImageFormat.Bmp);
                       
                            using (FileStream fs = new FileStream("c:\\empimg\\" + empi.EmployeeID + ".png", FileMode.Create, FileAccess.ReadWrite))
                        {
                            //thumbBMP.Save(ms, ImageFormat.Jpeg);
                            byte[] bytes = ms.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

       
        public string getEmailCC(string EmailCC, string SenderEmail)
        {
            try
            {
                if (EmailCC.Substring(EmailCC.Length - 1, 1) == ";") return EmailCC + SenderEmail;
                else return EmailCC + ";" + SenderEmail;
            }
            catch { return EmailCC; }
        }

        public string getEmailSignature(string EmployeeCode)
        {
            try
            {
                string signature = "Regards<br/>";

                using (HRMSEntities sms = new HRMSEntities())
                {
                    Employee employee = sms.Employees.Where(u => u.EmployeeID == EmployeeCode).FirstOrDefault();

                    signature += "<strong>" + employee.EmployeeName + "</strong><br/>";
                    signature += "<strong>" + employee.Designation + "</strong><br/>";
                    signature += "<strong>" + employee.Department + "</strong><br/>";
                    signature += "<strong> Mobile : " + employee.Mobile + "</strong><br/>";
                    signature += "<i>Labaid Pharmaceuticals Ltd.</i>";
                }

                return signature;
            }
            catch { return ""; }
        }

        public List<UserFavoriteMenus> getUserFavoriteMenus(string UserID)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    var userid = new SqlParameter("@UserID", UserID);
                    return db.Database.SqlQuery<UserFavoriteMenus>("getUserFavoriteMenus @UserID", userid).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public UserOfficeEmailDetails getUserOfficeEmailDetails(string EmployeeCode)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    var empCode = new SqlParameter("@EmployeeCode", EmployeeCode);
                    return db.Database.SqlQuery<UserOfficeEmailDetails>("getUserOfficeEmailDetails @EmployeeCode", empCode).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public LoggedUserDetails2 setITLoging(string EmployeeCode)
        {
            try
            {
                tblUser user = new tblUser();
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    user = db.tblUsers.Where(e => e.EmployeeCode == EmployeeCode).FirstOrDefault();
                }

                using (HRMSEntities db = new HRMSEntities())
                {
                    var userCode = new SqlParameter("@UserCode", user.UserCode);
                    var ituser = db.Database.SqlQuery<LoggedUserDetails2>("getLoggedUserDetails @UserCode", userCode).FirstOrDefault();
                    ituser.isitlogin = true;
                    return ituser;
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public Employee GetEmployeeById(string EmpID)
        {
            return new HRMSGenericRepository<Employee>().Find(e => e.EmployeeID == EmpID).FirstOrDefault();
        }

        public Boolean userIsExist(NewUserDetails NewUser, string username)
        {
            tblUser user = new SystemManagerGenericRepository<tblUser>().Find(u => u.UserCode == NewUser.UserCode || u.UserName == username || u.EmployeeCode == NewUser.EmployeeID && u.IsActive == true).FirstOrDefault();

            if (user != null) return true;

            return false;
        }

        public tblUser createUserAccount(tblUser NewUser)
        {
            return new SystemManagerGenericRepository<tblUser>().Insert(NewUser);
        }

        public List<Web_Menu_Privilege_Group> getPrivilegeByDesignationIDandDeptID(int DesignationID, int DeptID)
        {
            return new SystemManagerGenericRepository<Web_Menu_Privilege_Group>().Find(d => d.DepartmentID == DeptID && d.DesignationID == DesignationID && d.IsActive == true).ToList();
        }

        //ADDING DESIGNATION WISE PRIVILLEGES TO NEW USERS

        public Web_UserPrivileges saveDesignationWisePrivilege(Web_UserPrivileges privilege)
        {
            return new SystemManagerGenericRepository<Web_UserPrivileges>().Insert(privilege);
        }

        public List<UserPrivilegeNew> getUserPrivilegeNewList(string UserId)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    var userId = new SqlParameter("@UserId", UserId);
                    var data = db.Database.SqlQuery<UserPrivilegeNew>("getUserPrivilegeNew @UserId", userId).ToList();

                    return data;
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<UserMenuBrowsingHistory> getUserMenuBrowsingHistory(string UserID)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    var userID = new SqlParameter("@UserID", UserID);

                    return db.Database.SqlQuery<UserMenuBrowsingHistory>("getUserMenuBrowsingHistory @UserID", userID).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<LastNotification> getLastNotification(string UserID, string LastNotificationID, string RoutePath)
        {
            try
            {
                if (string.IsNullOrEmpty(LastNotificationID)) LastNotificationID = "0";

                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    var userID = new SqlParameter("@UserID", UserID);
                    var lastNotificationID = new SqlParameter("@LastNotificationID", LastNotificationID);
                    var routePath = new SqlParameter("@LastActiveRoute", RoutePath);

                    return db.Database.SqlQuery<LastNotification>("getLastNotification @UserID, @LastNotificationID, @LastActiveRoute", userID, lastNotificationID, routePath).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public Boolean saveNewNotification(int UserID, int RecipientID, string Title, string Message)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    Notification notify = new Notification();

                    notify.RecepientUserID = RecipientID;
                    notify.Message = Message;
                    notify.Title = Title;
                    notify.IsActive = true;
                    notify.CreatedByID = UserID;
                    notify.CreatedOn = DateTime.Now;

                    db.Notifications.Add(notify);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public Boolean saveUserNotification(string SenderID, string Title, string Message, string RecepientID, string NotificationModuleName)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    var senderID = new SqlParameter("@SenderID", SenderID);
                    var recepientID = new SqlParameter("@RecepientID", RecepientID);
                    var title = new SqlParameter("@Title", Title);
                    var message = new SqlParameter("@Message", Message);
                    var notificationModuleName = new SqlParameter("@NotificationModuleName", NotificationModuleName);

                    db.Database.ExecuteSqlCommand("saveUserNotification @SenderID, @Title, @Message, @RecepientID, @NotificationModuleName", senderID, title, message, recepientID, notificationModuleName);

                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public Boolean saveNewNotification(string UserID, string RecipientID, string Title, string Message)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    var senderID = new SqlParameter("@SenderID", UserID);
                    var recepientID = new SqlParameter("@RecepientID", RecipientID);
                    var title = new SqlParameter("@Title", Title);
                    var message = new SqlParameter("@Message", Message);

                    db.Database.ExecuteSqlCommand("saveNewNotification @SenderID, @RecepientID, @Title, @Message", senderID, recepientID, title, message);

                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public List<SalesEmployeeHasNoUserAccount> getSalesEmployeeHasNoUserAccount()
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    return db.Database.SqlQuery<SalesEmployeeHasNoUserAccount>("getSalesEmployeeHasNoUserAccount").ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<UserBrowsingHistory> getUserBrowsingHistory(string UserID)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    var userID = new SqlParameter("@UserID", UserID);
                    return db.Database.SqlQuery<UserBrowsingHistory>("getUserBrowsingHistory @UserID", userID).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<ActiveUserMenu> getActiveUserList()
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    return db.Database.SqlQuery<ActiveUserMenu>("getActiveUserList").ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public SingleValueInt getActiveUserTotal()
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    return db.Database.SqlQuery<SingleValueInt>("getActiveUserTotal").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<EmployeeInfo> getActiveUserInfo(string SearchType, string SearchValue)
        {
            try
            {
                List<EmployeeInfo> empList = new List<EmployeeInfo>();

                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                  
                    var sType = new SqlParameter("@SearchType", SearchType);
                    var sValue = new SqlParameter("@SearchValue", SearchValue);
                    empList = db.Database.SqlQuery<EmployeeInfo>("getUserList @SearchType, @SearchValue", sType, sValue).ToList();

                    foreach(var emp in empList.Where(e=>e.UserSystem == "LPLERP"))
                    {
                        emp.Password = new LPLERP.Common.Encryption().DecryptWord(emp.Password);
                        emp.ShowPassword = "*****";
                    }

                    //foreach (var emp in emps)
                    //{
                    //    EmployeeInfo empInfo = new EmployeeInfo();

                    //    empInfo.ID = emp.ID;
                    //    empInfo.UserId = emp.UserId;
                    //    empInfo.EmployeeName = emp.EmployeeName;
                    //    empInfo.UserCode = emp.UserCode;
                    //    empInfo.Email = emp.Email;
                    //    empInfo.Designation = emp.Designation;
                    //    empInfo.Department = emp.Department;
                    //    empInfo.Location = emp.Location;
                    //    empInfo.UserName = new LPLERP.Common.Encryption().DecryptWord(emp.UserName);
                    //    empInfo.Password = new LPLERP.Common.Encryption().DecryptWord(emp.Password);
                    //    empInfo.EmployeeID = emp.EmployeeID;
                    //    empInfo.ProfileImageName = emp.ProfileImageName;
                    //    empInfo.Mobile = emp.Mobile;
                    //    empInfo.JoinningDate = emp.JoinningDate;
                    //    empList.Add(empInfo);
                    //}
                }

                return empList;
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public tblUser validateUser(string UserCode, string EncryptedPassword)
        {
            return _user.FindOne(t => (t.UserCode == UserCode || t.Email == UserCode || t.EmployeeCode == UserCode) && t.Password == EncryptedPassword);
        }

        public string getApplicationCurrentVersion(string AppName)
        {
            var data = new SystemManagerGenericRepository<ApplicationList>().FindOne(a => a.ShortName == AppName).CurrentVersion;

            return data == null ? "" : data;
        }

        public ApplicationList getApplicationVersion(int ID)
        {
            return new SystemManagerGenericRepository<ApplicationList>().Find(a => a.IsActive == true && a.ID == ID).FirstOrDefault();
        }

        public List<ApplicationListDto> getApplicationVersionList()
        {
            try
            {
                List<ApplicationListDto> applicationListDtoList = new List<ApplicationListDto>();

                List<ApplicationList> applicationLists = new SystemManagerGenericRepository<ApplicationList>().Find(a => a.IsActive == true).ToList();

                foreach (var item in applicationLists)
                {
                    ApplicationListDto applicationListDto = new ApplicationListDto();
                    applicationListDto.ApplicationName = item.ApplicationName;
                    applicationListDto.CreatedByID = item.CreatedByID;
                    applicationListDto.CreatedOn = item.CreatedOn;
                    applicationListDto.ID = item.ID;
                    applicationListDto.IsActive = item.IsActive;
                    applicationListDto.ShortName = item.ShortName;
                    applicationListDto.CurrentVersion = item.CurrentVersion;
                    applicationListDto.NextVersion = ApplicationNextVersionCatculate(item.CurrentVersion);
                    applicationListDto.CreatedBy = new HRMSGenericRepository<Employee>().Find(e => e.EmployeeID == item.CreatedByID).FirstOrDefault().EmployeeName;
                    applicationListDtoList.Add(applicationListDto);
                }

                return applicationListDtoList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ApplicationList updateVersion(int AppID, string newVersion, string CreatedBy)
        {
            ApplicationList application = getApplicationVersion(AppID);
            application.CurrentVersion = newVersion;
            application.CreatedOn = DateTime.Now;
            application.CreatedByID = CreatedBy;
            return new SystemManagerGenericRepository<ApplicationList>().Update(application, a => a.ID == application.ID);
        }

        public string ApplicationNextVersionCatculate(string CurrentVersion)
        {
            if (CurrentVersion == null || CurrentVersion == "")
            {
                return "0.0.0";
            }

            string NextVersion = string.Empty;

            string[] SplitNumbers = CurrentVersion.Split('.');

            if (SplitNumbers.Length != 3)
            {
                return "-1.0.0";
            }

            if (Convert.ToInt32(SplitNumbers[2]) + 1 == 10)
            {
                if (Convert.ToInt32(SplitNumbers[1]) + 1 == 10)
                {
                    NextVersion = (Convert.ToInt32(SplitNumbers[0]) + 1).ToString() + ".0.0";
                }
                else
                {
                    NextVersion = SplitNumbers[0] + "." + (Convert.ToInt32(SplitNumbers[1]) + 1).ToString() + ".0";
                }
            }
            else
            {
                NextVersion = SplitNumbers[0] + "." + SplitNumbers[1] + "." + (Convert.ToInt32(SplitNumbers[2]) + 1).ToString();
            }

            return NextVersion;
        }
    }
}