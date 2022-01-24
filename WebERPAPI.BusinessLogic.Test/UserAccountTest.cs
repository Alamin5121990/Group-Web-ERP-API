using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebERPAPI.BusinessLogic.User;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Employee;
using WebERPAPI.DTO.User;

namespace WebERPAPI.BusinessLogic.Test
{
    [TestClass()]
    public class UserAccountTest
    {
        private UserAccountService ua = new UserAccountService();

        [TestMethod()]
        public void getOfficeEmployees()
        {
            List<EmployeeDetails> result = ua.getOfficeEmployees("HO");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void getEmployeeDetails()
        {
            EmployeeDetails result = ua.getEmployeeDetails("LPL02693");
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void getUserPrivileges()
        {
            List<UserPrivilege> result = ua.getUserPrivileges(136);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void updateUserPrivilege()
        {
            CommonDataEntryClass pData = new CommonDataEntryClass
            {
                Data = "136;140;3;true;136"
            };
            Assert.IsTrue(ua.updateUserPrivilege(pData));
        }

        [TestMethod()]
        public void getActiveUserInfo()
        {
            List<EmployeeInfo> result = ua.getActiveUserInfo("Office", "IkhlYWQgT2ZmaWNlIg==");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void setMultipleUserPrivilege()
        {
            MulitpleUserPrivilege data = new MulitpleUserPrivilege
            {
                UserIds = "1426,2,310,87,275,136,387,",
                CreatedById = 136,
                MenuID = 13
            };
            Assert.IsTrue(ua.setMultipleUserPrivilege(data));
        }

        [TestMethod()]
        public void getOfficeLocations()
        {
            Assert.IsNotNull(ua.getOfficeLocations());
        }
    }
}