using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.DTO.Employee;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.User;
using WebERPAPI.Data.GenericRepository;
using System.Data.Entity.Migrations;
using WebERPAPI.DTO.HRMS;

namespace WebERPAPI.Data.Repository.HRMS
{
    public class EmployeeRepositories 
    {
        public Exception error = new Exception();
        private HRMSGenericRepository<Employee> _employee = null;

        public EmployeeRepositories()
        {
            _employee = new HRMSGenericRepository<Employee>();
        }


        public List<Employee> getEmployeeActiveList()
        {
            return new HRMSGenericRepository<Employee>().Find(e => e.DOS == null).ToList();
        }

        public List<EmployeeEvaluationReportDto> getEmployeegetEmployeeEvaluationReportt()
        {
            return new HRMSGenericRepository<EmployeeEvaluationReportDto>().FindUsingSP("exec getEmployeeEvaluationReport");
        }
        
        public List<EmployeeBankInfoDto> getEmployeeBankInformationList()
        {
            return new HRMSGenericRepository<EmployeeBankInfoDto>().FindUsingSP("exec getEmployeeBankInformationList");
        }

        public List<EmployeeEvaluationDto> getEmployeeListForEvaluationReport()
        {
            return new HRMSGenericRepository<EmployeeEvaluationDto>().FindUsingSP("exec getEmployeeListForEvaluationReport");
        }

        
        public List<EmployeeGrossSalaryDto> getEmployeeGrossSalaryList(DateTime FromDate, DateTime ToDate, bool IsSeparated)
        {
            return new HRMSGenericRepository<EmployeeGrossSalaryDto>().FindUsingSP("exec getEmployeeGrossSalary @EmployeeDateFrom, @EmployeeDateTo, @IsSeparated",
                new SqlParameter("@EmployeeDateFrom", FromDate),
                new SqlParameter("@EmployeeDateTo", ToDate),
                new SqlParameter("@IsSeparated", IsSeparated));
        }

     
        public List<EmployeeGrossSalaryDto> getEmployeeGrossSalaryByEmpCode(string EMPCode, bool IsSeparated)
        {
            var data = new HRMSGenericRepository<EmployeeGrossSalaryDto>().FindUsingSP("exec getEmployeeGrossSalaryByEmployeeCode @EMPCode, @IsSeparated",
                new SqlParameter("@EMPCode", EMPCode), new SqlParameter("@IsSeparated", IsSeparated)).ToList();

            return data;
        }

        public List<LoggedUserDetails> getLoggedUserDetails(string UserCode)
        {
            try
            {
                return new HRMSGenericRepository<LoggedUserDetails>().FindUsingSP("exec getLoggedUserDetails @UserCode",
               new SqlParameter("@UserCode", UserCode));
            }
            catch(Exception EX)
            {
                return null;
            }
        }

     
    }
}