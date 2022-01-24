using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.Data.Repository.Product;

namespace WebERPAPI.Data.Test.Inventory
{
    [TestClass()]
    public class ProductTesting
    {
        [TestMethod]
        public void getMaterialProductList()
        {
            ProductRepositories repo = new ProductRepositories();
            //Material Code = "PP-AB-001", name = Unprinted Alu-Bottom foil 206 mm, [Width: 206 mm, Thickness: 0.145 mm, GSM: 250]

            var result = repo.getMaterialProductList("PP-AB-001");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 1);
            //Assert.AreEqual(3, result.Count);
        }
    }
}