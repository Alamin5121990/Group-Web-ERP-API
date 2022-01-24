using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.BusinessLogic.InventoryNonProduction;

namespace WebERPAPI.BusinessLogic.Test.InventoryNonProduction
{
    [TestClass]
    public class BillSubmitNPTest
    {
       public BillSubmitNPService service = new BillSubmitNPService();

        [TestMethod]
        public void getSupplierListByInventoryTypeIdTest()
        {
            int InventoryTypeId = 5;
            Assert.IsNotNull(service.getSupplierListByInventoryTypeId(InventoryTypeId));

        }

        [TestMethod]
        public void getPOListNPBySupplierCodeInventoryTypeIDTest()
        {
            Assert.IsNotNull(service.getPOListNPBySupplierCodeInventoryTypeID("S-0484", 5), service.Error.Message);

        }

        [TestMethod]
        public void getPOMaterialListNPByPoCodeTest()
        {
            Assert.IsNotNull(service.getPOMaterialListNPByPoCode("S-0484"), service.Error.Message);

        }


      
    }
    
}
