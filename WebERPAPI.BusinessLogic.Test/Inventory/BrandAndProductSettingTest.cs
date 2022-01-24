using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.BusinessLogic.Inventory;
using WebERPAPI.DTO.Inventory;
using WebERPAPI.DTO.Inventory.Products;

namespace WebERPAPI.BusinessLogic.Test.Inventory
{
    [TestClass]
    public class BrandAndProductSettingTest
    {
        public ProductSettingService service = new ProductSettingService();

        [TestMethod]
        public void GenericsaveUpdateCancelTest()
        {
            GenericDto dto = new GenericDto();
            dto.ID = 0;
            dto.CreatedByID = 2456;
            dto.GenericName = "aaaa Generic Name test case";
            dto.Remarks = "Test Remarks";
            dto.Description = "Test Description";
            dto.IsActive = true;
            dto.CreatedOn = DateTime.Now;

            //save test
            var saveResult = service.saveGeneric(dto);
            Assert.IsNotNull(saveResult, service.Error.Message);

            dto.ID = saveResult.ID;
            dto.GenericName = dto.GenericName + "- updated";
            //update test
            var updateResult = service.updateGeneric(dto);
            Assert.IsNotNull(updateResult, service.Error.Message);

            //cancel test
            var cancelResult = service.cancelGeneric(dto);
            Assert.IsNotNull(cancelResult, service.Error.Message);
            Assert.IsFalse(cancelResult.IsActive == true, service.Error.Message);
        }

        [TestMethod]
        public void getBranListByGenericIDTest()
        {
            Assert.IsNotNull(service.getBranListByGenericID(2), service.Error.Message);
        }

        [TestMethod]
        public void getPriorityListTest()
        {
            Assert.IsNotNull(service.getPriorityList(), service.Error.Message);
        }

        [TestMethod]
        public void getBrandStateListTest()
        {
            Assert.IsNotNull(service.getBrandStateList(), service.Error.Message);
        }

        [TestMethod]
        public void saveUpdateCancelbrandTest()
        {
            BrandListDto brandDto = new BrandListDto();
            brandDto.BrandName = "Test case";
            brandDto.IsActive = true;
            brandDto.CreatedByID = 5334;
            brandDto.CreatedOn = DateTime.Now;
            brandDto.GenericID = 2;
            brandDto.BrandPriorityID = 2;
            brandDto.StateID = 2;

            var SaveResult = service.savebrand(brandDto);
            Assert.IsNotNull(SaveResult, service.Error.Message);

            brandDto.ID = SaveResult.ID;

            brandDto.BrandName = "test case update";
            brandDto.UpdatedByID = 1342;

            Assert.IsNotNull(service.Updatebrand(brandDto), service.Error.Message);

            Assert.IsNotNull(service.cancelbrand(brandDto), service.Error.Message);
        }

        //product table services
        [TestMethod]
        public void saveCancelProductTest()
        {
            ProductNewDto product = new ProductNewDto();

            product.BrandID = 1;
            product.CreatedByID = 5336;
            product.DarNo = "dr-1212";
            product.Description = "Test";
            product.DosageFormID = 2;
            product.IsActive = true;
            product.MPS = "12ab";
            product.MRP = 1212;
            product.PackSize = "23x5";
            product.PPS = "pps";
            product.ProductFormID = 2;
            product.ProductTypeID = 2;
            product.Vat = 34;
            product.VatPayable = 100;
            product.Strength = "334s";
            product.ProductLocationIDs = ",1,2,4";
            product.ProductName = "trst pp";
            product.UOM = "Piece";
            product.SalesCode = "1223";
            product.ShelfMonth = 1;
            product.ShelfYear = 4;
            product.TP = 34;
            product.UOM = "Test";
            product.Vat = 30;
            product.VatPayable = 100;

            var SavedProduct = service.saveProduct(product);
            //save test
            Assert.IsNotNull(SavedProduct, service.Error.Message);

            product.ID = SavedProduct.ID;
            product.ProductName = SavedProduct.ProductName + " update 1";
            product.ProductID = SavedProduct.ProductID;
            product.ProductStateID = 2;
            product.UpdatedByID = 5336;

            var UpdateProduct = service.updateProduct(product);
            //update test
            Assert.IsNotNull(UpdateProduct, service.Error.Message);
            //cancel test
            //Assert.IsNotNull(service.cancelProduct(product), service.Error.Message);
        }

        [TestMethod]
        public void updateProductTest()
        {
            //List<ProductListDto> products = service.getProductList(2);

            //products[0].UpdatedByID = 5336;
            //products[0].ProductName = "updated name";
            //var UpdateProduct = service.updateProduct(products[0]);
            //update test
            //Assert.IsNotNull(UpdateProduct, service.Error.Message);
        }
    }
}