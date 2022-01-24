using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.BusinessLogic.HRMS;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO;
using WebERPAPI.DTO.HRMS;

namespace WebERPAPI.BusinessLogic.Test
{
    [TestClass]
    public class DepartmentTest
    {
        private string EmployeeID = "LPL02693";

        private DepartmentService service = new DepartmentService();

        [TestMethod]
        public void saveDepartmentInchargeTest()
        {
            CommonDataEntryClass Data = new CommonDataEntryClass();

            Data.EmployeeCode = EmployeeID;
            Data.ID = 15; // IT
            Data.Code = "LPL00039"; //Fedu

            // CREATE CS
            Department_Incharge newIncharge = service.saveDepartmentIncharge(Data);
            Assert.IsNotNull(newIncharge, service.Error.Message);
        }

        [TestMethod]
        public void saveDepartmentMenusTest()
        {
            CommonDataEntryClass Data = new CommonDataEntryClass();

            DepartmentMenuDto menu = new DepartmentMenuDto();
            menu.DepartmentID = 15;
            menu.MenuID = 25;

            List<DepartmentMenuDto> menus = new List<DepartmentMenuDto>();
            menus.Add(menu);

            string jsonstr = Library.JSONSerialize.ObjectToJSONText(menus);
            string menuInBase64 = Library.JSONSerialize.EncodeBase64(jsonstr);

            Data.EmployeeCode = EmployeeID;
            Data.Data = menuInBase64;

            // CREATE
            Assert.IsTrue(service.saveDepartmentMenus(Data), service.Error.Message);
        }

        //TEST METHODS OF Department & Designation wise menu mapping SERVICES

        [TestMethod]
        public void getAllMenulistTest()
        {
            Assert.IsNotNull(service.getAllMenulist(), service.Error.Message);
        }

        [TestMethod]
        public void getDepartmentListTest()
        {
            Assert.IsNotNull(service.getDepartmentList(), service.Error.Message);
        }

        [TestMethod]
        public void getDesignationListTest()
        {
            Assert.IsNotNull(service.getDesignationList(), service.Error.Message);
        }

        [TestMethod]
        public void getMenulistByDeptAndDesignWiseTest()
        {
            Assert.IsNotNull(service.getMenulistByDeptAndDesignWise(2,18), service.Error.Message);
        }
        [TestMethod]
        public void UpdateMenuPrivilegeGroupTest()
        {
            WebMenuDto dto = new WebMenuDto();
            dto.GroupID = 101;
            dto.HasFullAccess = true;
            dto.IsNonPrivilegedMenu = true;
            Assert.IsNotNull(service.UpdateMenuPrivilegeGroupPermission(dto), service.Error.Message);
        }
        
    }
}