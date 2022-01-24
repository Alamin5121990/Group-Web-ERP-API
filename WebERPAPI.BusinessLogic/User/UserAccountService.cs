using System;
using System.Collections.Generic;
using System.Linq;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Employee;
using WebERPAPI.DTO.User;
using WebERPAPI.Data;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository;
using LPLERP.Common;
using WebERPAPI.Data.Repository.HRMS;

namespace WebERPAPI.BusinessLogic.User
{
    public class UserAccountService 
    {
        private UserRepositories repo = new UserRepositories();
        private EmployeeRepositories eRepo = new EmployeeRepositories();
        private MenuRepositories menu = new MenuRepositories();

        public Exception error = new Exception();


        public object getDepartment()
        {
            try
            {
                var data = new HRMSEntities().Department.ToList();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public object getOfficeLocations()
        {
            try
            {
                UserRepositories user = new UserRepositories();
                var locations = user.getLocationList();
                if (locations == null) return null;

                UserLocationDto location = new UserLocationDto();
                location.LocationID = "ALL";
                location.LocationCode = "ALL";
                location.LocationName = "ALL";

                locations.Add(location);

                return locations.Select(l => new { l.LocationID, l.LocationCode, l.LocationName }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean createUserAccount(NewUserDetails NewUser)
        {
            try
            {
                if (NewUser.UserCode.Length > 15) NewUser.UserCode = NewUser.UserCode.Substring(0, 15);

                string encodedPass = new LPLERP.Common.Encryption().EncryptWord(NewUser.Password);
                string username = new LPLERP.Common.Encryption().EncryptWord(NewUser.UserCode);
                tblUser nuser = new tblUser();

                string employeeName = "";
                Employee emp = repo.GetEmployeeById(NewUser.EmployeeID);
                if (emp != null) employeeName = emp.EmployeeName;

                if (repo.userIsExist(NewUser, username))
                {
                    throw new Exception("User Already Exist.");
                }

                nuser.UserCode = NewUser.UserCode;
                nuser.Password = encodedPass;
                nuser.EmployeeCode = NewUser.EmployeeID;
                nuser.UserName = username;
                nuser.DateAdded = DateTime.Now;
                nuser.IsInternal = true;
                nuser.IsActive = true;
                nuser.IsAdmin = false;
                nuser.IsLoggedIn = false;
                nuser.IsWebAppAllowed = true;
                nuser.AddedBy = NewUser.CreatedByID;
                nuser.Name = employeeName;

                nuser = repo.createUserAccount(nuser);

                if(nuser.UserId>0)
                {
                    saveDesignationWisePrivilege(emp,nuser);
                    return true;
                }

                return false;
            }

            catch(Exception ex)
            {
                error = ex;
                return false;
            }
        }


        public Boolean saveDesignationWisePrivilege(Employee emp,tblUser nuser)
        {
            try
            {
                List<Web_Menu_Privilege_Group> privilege_Groups = repo.getPrivilegeByDesignationIDandDeptID(Convert.ToInt32(emp.DesignationID), Convert.ToInt32(emp.DepartmentID));
                if (privilege_Groups.Count == 0) return true;

                int count = 0;

                foreach (var item in privilege_Groups)
                {
                    Web_UserPrivileges privilege = new Web_UserPrivileges();

                    privilege.UserId = nuser.UserId;
                    privilege.MenuId = item.MenuID;
                    privilege.HasFullAccess = item.HasApprove;
                    privilege.HasDelete = item.HasDelete;
                    privilege.HasInsert = item.HasInsert;
                    privilege.HasPrint = item.HasPrint;
                    privilege.HasRecommendation = item.HasRecommendation;
                    privilege.HasReview = item.HasReview;
                    privilege.HasUpdate = item.HasUpdate;
                    privilege.HasVerify = item.HasVerify;
                    privilege.HasView = item.HasView;
                    
                    privilege.UpdatedOn = DateTime.Now;
                    repo.saveDesignationWisePrivilege(privilege);
                    count++;
                }

                if (privilege_Groups.Count == count) return true;
                else throw new Exception("All Privileges was not saved. Please check log.");
            }

            catch(Exception ex)
            {
                error = ex;
                return false;
            }

            
        }

        public Boolean updateUserContact(EmployeeDetails employee)
        {
            return repo.updateUserContact(employee);
        }

        public List<EmployeeDetails> getOfficeEmployees(string LocationID)
        {
            return repo.getOfficeEmployees(LocationID);
        }

        public EmployeeDetails getEmployeeDetails(string LocationID)
        {
            return repo.getEmployeeDetails(LocationID);
        }

        public List<UserPrivilege> getUserPrivileges(int UserID)
        {
            try
            {
                var privileges = repo.getUserPrivileges(UserID);

                List<UserPrivilege> userPrivileges = new List<UserPrivilege>();
                var menus = menu.getWebMenusWithRequest();

                if (menus != null)
                {
                    var groups = menus.Where(m => m.ParentMenuId == 0);

                    foreach (var group in groups)
                    {
                        UserPrivilege up = new UserPrivilege();

                        up.MenuID = group.MenuID;
                        up.MenuName = group.MenuName;
                        up.IsParentMenu = true;

                        userPrivileges.Add(up);

                        var subMenus = menus.Where(m => m.ParentMenuId == group.MenuID).OrderBy(o => o.MenuName).ToList();

                        foreach (var sub in subMenus)
                        {
                            up = new UserPrivilege();

                            up.MenuID = sub.MenuID;
                            up.MenuName = sub.MenuName;
                            up.IsParentMenu = false;
                            up.TotalRequest = sub.TotalRequest;

                            var prv = privileges.Where(p => p.MenuID == sub.MenuID).FirstOrDefault();

                            if (sub.MenuID == 168)
                            {
                            }

                            if (prv != null)
                            {
                                up.HasInsert = prv.HasInsert;
                                up.HasUpdate = prv.HasUpdate;
                                up.HasDelete = prv.HasDelete;
                                up.HasPrint = prv.HasPrint;
                                up.HasAudit = prv.HasAudit;
                                up.HasFullAccess = prv.HasFullAccess;
                                up.HasView = prv.HasView;

                                up.HasReview = prv.HasReview;
                                up.HasVerify = prv.HasVerify;
                                up.HasRecommendation = prv.HasRecommendation;
                                up.HasApprove = prv.HasApprove;

                                up.UpdatedBy = prv.UpdatedBy;
                                up.UpdatedOn = prv.UpdatedOn;
                                up.HasAudit = prv.HasAudit;
                            }
                            else
                            {
                                up.HasInsert = false;
                                up.HasUpdate = false;
                                up.HasDelete = false;
                                up.HasPrint = false;
                                up.HasView = false;
                                up.HasAudit = false;
                                up.HasReview = false;
                                up.HasVerify = false;
                                up.HasRecommendation = false;
                                up.HasApprove = false;
                                up.HasAudit = false;
                                up.HasFullAccess = false;
                            }

                            userPrivileges.Add(up);
                        }
                    }

                    return userPrivileges;
                }
                else return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean updateUserPrivilege(CommonDataEntryClass Privilege)
        {
            try
            {
                string[] st = Privilege.Data.Split(';');
                int UserId = int.Parse(st[0]);
                int MenuId = int.Parse(st[1]);
                int Indx = int.Parse(st[2]);

                Boolean UserAction = false;
                if (st[3].CompareTo("1") == 0 || st[3].CompareTo("true") == 0) UserAction = true;
                int UpdatedById = int.Parse(st[4]);

                UserRepositories user = new UserRepositories();

                if (user.saveUserPrivilege(UserId, MenuId, Indx, UserAction, UpdatedById))
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<EmployeeInfo> getActiveUserInfo(string SearchType, string SearchValue)
        {
            try
            {
                SearchValue = Library.JSONSerialize.DecodeBase64(SearchValue).Replace("\"", "");
                return repo.getActiveUserInfo(SearchType, SearchValue);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean setMultipleUserPrivilege(MulitpleUserPrivilege data)
        {
            try
            {
                string[] users = data.UserIds.Split(',');

                UserRepositories user = new UserRepositories();

                foreach (string userid in users)
                {
                    if (string.IsNullOrEmpty(userid)) continue;

                    if (user.saveUserPrivilege(int.Parse(userid), data.MenuID, 4, true, data.CreatedById))
                    {
                    }
                    else return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public LoggedUserDetails getLoggedUserDetails(string UserCode)
        {
            try
            {
                return eRepo.getLoggedUserDetails(UserCode).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public LoggedUserDetails ValidateUserLogin(tblUser user)
        {
            try
            {
                var encryptedPass = new Encryption().EncryptWord(user.Password);
                tblUser result = repo.validateUser(user.UserCode, encryptedPass);

                if (result != null && result.UserCode != null)
                {
                    var s = getLoggedUserDetails(result.UserCode);
                    return s;
                }

                return null;
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public Web_UserDevices updateLogDetails(ClientDetails details)
        {
            try
            {
                Web_UserDevices log = new Web_UserDevices();
                log.DeviceDetails = details.DeviceInfo;
                log.User_GUID = details.GUID;
                log.IPAddress = details.IPAddress;
                log.UserID = details.UserID;
                log.LocationDetails = details.LocationInfo;
                log.CreatedOn = DateTime.Now;

                return repo.updateLogDetails(log);
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public string getApplicationCurrentVersion(string AppName)
        {
            try
            {
                return repo.getApplicationCurrentVersion(AppName);
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }
    }

    public class UserLocation
    {
        public int ID { get; set; }
        public string LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
    }
}