using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebERPAPI.BusinessLogic.Inventory;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.Inventory;

namespace WebERPAPI.BusinessLogic.Test
{
    [TestClass()]
    public class SupplierTest
    {
        private SupplierService service = new SupplierService();

        [TestMethod()]
        public void getPurchaseOrderSupplier()
        {
            List<PurchaseOrderSupplier> result = new List<PurchaseOrderSupplier>();

            //TEST 1
            result = service.getPurchaseOrderSupplier("local");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

            //TEST 2
            result = service.getPurchaseOrderSupplier("import");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

            //TEST 3
            result = service.getPurchaseOrderSupplier("0");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

            //TEST 4
            //result = service.getPurchaseOrderSupplier("latest");
            //Assert.IsNotNull(result);
            //Assert.IsTrue(result.Count > 0);
        }

        //SUPPLIER ADD TEST METHODS

        [TestMethod()]
        public void getSupplierTypeListTest()
        {
           var result = service.getSupplierTypeList();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

        }

        [TestMethod()]
        public void getSupplierCategoryListTest()
        {
            var result = service.getSupplierCategoryList();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

        }

        [TestMethod()]
        public void saveSupplierTest()
        {
            Supplier supplier = new Supplier();
            supplier.Addedby = "Test";
            supplier.DateAdded = DateTime.Now;
            supplier.Address = "Test";
            supplier.ContactPerson = "Test";
            supplier.Country = "Bangladesh";
            supplier.Email = "test";
            supplier.Fax = "123";
            supplier.ID = 0;
            supplier.Location = "HO";
            supplier.Phone = "01222";
            supplier.MachineNameIP = "test";
            supplier.Webaddress = "123.com";
            supplier.Transfered = false;
            supplier.SupplierTypeID = 1;
            supplier.SupplierType = "test";
            supplier.SupplierName = "test";
            supplier.SupplierCategory = "test";
            supplier.SupplierCategoryID = 0;
            supplier.Remarks = "test";
            supplier.HOTransfered = false;
            var result = service.saveSupplier(supplier);
            Assert.IsNotNull(result, service.Error.Message);
        }

        [TestMethod()]
        public void saveUpdateRemoveSupplierCategoryTest()
        {
            //save test
            Supplier_Categories category = new Supplier_Categories();
            category.CreatedOn = DateTime.Now;
            category.CreatedByID = 2347;
            category.IsActive = true;
            category.SupplierCategoryName = "Test case";
            category.Remarks = "Test cases";
            
            var result = service.saveSupplierCategory(category);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ID > 0);

            //update test
            result.UpdatedByID = 246;
            result.UpdatedOn = DateTime.Now;
            result.Remarks = "Test update";
            result = service.updateSupplierCategory(result);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ID > 0);

            //remove test
            result = service.removeSupplierCategory(result);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ID > 0);
        }

        [TestMethod()]
        public void saveUpdateRemoveSupplierTypeTest()
        {
            Supplier_Types item = new Supplier_Types();
            item.CreatedOn = DateTime.Now;
            item.CreatedByID = 2347;
            item.IsActive = true;
            item.SupplierTypeName = "Test case";
            item.Remarks = "Test cases";

            var result = service.saveSupplierType(item);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ID > 0);

            //update test
            result.UpdatedByID = 246;
            result.UpdatedOn = DateTime.Now;
            result.Remarks = "Test update";
            result = service.updateSupplierType(result);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ID > 0);

            //remove test
            result = service.removeSupplierType(result);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ID > 0);
        }


    }
}