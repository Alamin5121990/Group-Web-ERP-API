using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.BusinessLogic.HRMS;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.Employee;

namespace WebERPAPI.BusinessLogic.Test
{
    [TestClass]
    public class EmployeeExamTest
    {
        public EmloyeeExamService service = new EmloyeeExamService();

        [TestMethod]
        public void getExamListTest()
        {
            var result = service.getExamList();
            Assert.IsNotNull(result, service.Error.Message);
            Assert.IsTrue(result.Count > 0, "Result is empty");
        }

        [TestMethod]
        public void getExamTypeListTest()
        {
            var result = service.getExamTypeList();
            Assert.IsNotNull(result, service.Error.Message);
            Assert.IsTrue(result.Count > 0, "Result is empty");
        }

        [TestMethod]
        public void saveUpdateDeleteEmployeeExamTest()
        {
            Employee_Exams exam = new Employee_Exams();
            exam.CreatedByID = 123;
            exam.CreatedOn = DateTime.Now;
            exam.ExamDate = DateTime.Now.AddDays(10);
            exam.ExamName = "Test";
            exam.ExamVenueLocation = "test location";
            exam.IsActive = true;
            exam.TotalMarks = 50;
            exam.PassMark = 10;
            exam.IsEditLocked = false;

            //saving new exam
            var result = service.saveUpdateEmployeeExam(exam);
            Assert.IsNotNull(result, service.Error.Message);
            Assert.IsTrue(result.ExamID > 0, "Not saved");

            //updating exam
            result.ExamName = "test updateing";
            result.UpdatedOn = DateTime.Now;
            result.UpdatedByID = 890;

            result = service.saveUpdateEmployeeExam(exam);
            Assert.IsNotNull(result, service.Error.Message);
            Assert.IsTrue(result.ExamID > 0, "Not saved");

            //deleting exam
            EmployeeExamDTO examDTO = new EmployeeExamDTO();
            examDTO.ExamID = result.ExamID;
            examDTO.ExamName = exam.ExamName;
            examDTO.ExamTypeID = exam.ExamTypeID;
            examDTO.IsActive = exam.IsActive;
            examDTO.IsEditLocked = exam.IsEditLocked;

            result = service.deleteExam(examDTO);
            Assert.IsNotNull(result, service.Error.Message);
            Assert.IsTrue(result.ExamID > 0, "Not saved");
        }

        [TestMethod]
        public void saveEmployeeExamMarksTest()
        {
            //List<EmployeesExamMarkDto> data = new List<EmployeesExamMarkDto>();
            //EmployeesExamMarkDto mark = new EmployeesExamMarkDto();
            //mark.ExamID = 13;
            //mark.EmployeeID = "123";
            //mark.CreatedOn = DateTime.Now;
            //mark.CreatedByID = 123;
            //mark.EmpID = 123;
            //mark.PKETMarks = 10;
            //mark.DetailingScore = 5;
            //data.Add(mark);
            //var result = service.saveEmployeeExamMarks(data);
            //Assert.IsNotNull(result, service.Error.Message);
            //Assert.IsTrue(result.Count > 0, "Mark not saved");
        }

        [TestMethod]
        public void deleteExamMarkTest()
        {
            var result = service.deleteExamMark(29);
            Assert.IsNotNull(result, service.Error.Message);
            Assert.IsTrue(result.ID > 0, "Mark not saved");
        }
    }
}