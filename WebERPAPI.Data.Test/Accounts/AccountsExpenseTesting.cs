using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.Data.Repository.Accounts;

namespace WebERPAPI.Data.Test.Accounts
{
    [TestClass]
    public class AccountsExpenseTesting
    {
        private AccountsExpenseRepositories repo = new AccountsExpenseRepositories();
        private string testDate = "2019-07-22";

        [TestMethod]
        public void checkExpenseDateForAcccountsEntry()
        {
            //bool expected = true;
            //var result = repo.checkExpenseDateForAcccountsEntry(testDate);

            //Assert.IsNotNull(result);
            //Assert.AreEqual(expected, result);
        }
    }
}