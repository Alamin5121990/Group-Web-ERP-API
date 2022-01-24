using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebERPAPI.BusinessLogic.Accounts;
using WebERPAPI.DTO.Accounts;

namespace WebERPAPI.BusinessLogic.Test
{
    [TestClass()]
    public class BillTest
    {
        private BillService service = new BillService();

        [TestMethod()]
        public void getBillsByUser()
        {
            List<BillsByUser> result = new List<BillsByUser>();
            string EmployeeID = "LPL03397";
            string SupplierID = "S-0405";

            //TEST 1
            result = service.getBillsByUser(EmployeeID, "0");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

            //TEST 2
            result = service.getBillsByUser(EmployeeID, SupplierID);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

            //TEST 3
            result = service.getBillsByUser(EmployeeID, "latest");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}