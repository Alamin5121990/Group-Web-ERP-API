using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.Data.Repository.Inventory;

namespace WebERPAPI.Data.Test.Inventory
{
    [TestClass()]
    public class MaterialTesting
    {
        private MaterialRepositories repo = new MaterialRepositories();
        private string MaterialCode = "PP-AB-001";

        [TestMethod]
        public void getMaterialFreeStock()
        {
            //Material Code = "PP-AB-001", name = Unprinted Alu-Bottom foil 206 mm, [Width: 206 mm, Thickness: 0.145 mm, GSM: 250]

            var result = repo.getMaterialFreeStock(MaterialCode);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
            //Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void getMaterialShortProfile()
        {
            Assert.IsNotNull(repo.getMaterialShortProfile(MaterialCode));
        }

        [TestMethod]
        public void getMaterialProductList()
        {
            var result = repo.getMaterialProductList(MaterialCode);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 1);
            //Assert.AreEqual(3, result.Count);
        }
    }
}