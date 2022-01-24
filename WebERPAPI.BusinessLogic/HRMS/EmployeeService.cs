using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebERPAPI.BusinessLogic.Interfaces;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.HRMS;
using WebERPAPI.DTO.HRMS;
using WebERPAPI.DTO.User;

namespace WebERPAPI.BusinessLogic.HRMS
{
    public class EmployeeService : IEmployeeService
    {
        public Exception Error = new Exception();
        public EmployeeRepositories repo = new EmployeeRepositories();


        public List<EmployeeEvaluationReportDto> getEmployeeEvaluationReport()
        {
            try
            {
                return repo.getEmployeegetEmployeeEvaluationReportt();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<Employee> getEmployeeActiveList()
        {
            try
            {
                return repo.getEmployeeActiveList();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<EmployeeEvaluationDto> getEmployeeListForEvaluationReport()
        {
            try
            {
                return repo.getEmployeeListForEvaluationReport();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }
        
        public List<EmployeeBankInfoDto> getEmployeeBankInformationList()
        {
            try
            {
                return repo.getEmployeeBankInformationList();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }


        public List<PFEmployeeDepartmentListDto> getDepartmentListForPF(string empid)
        {
            try
            {
                return new HRMSGenericRepository<PFEmployeeDepartmentListDto>().FindUsingSP("getPFEmployeeDepartmentList @EmployeeID",
                    new SqlParameter("@EmployeeID", empid));
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<PFEmployeeListDto> getPFEmployeelist(string SearchType, string empid)
        {
            try
            {
                var data = new HRMSGenericRepository<PFEmployeeListDto>().FindUsingSP("getPFEmployeeList @SearchType, @EmployeeID",
                    new SqlParameter("@SearchType", SearchType), new SqlParameter("@EmployeeID", empid));
                return data;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<EmployeePFDataList> getEmployeePFData(string EmployeeID)
        {
            try
            {
                var data = new HRMSGenericRepository<EmployeePFDataList>().FindUsingSP("getEmployeePFList @EmployeeID",
                    new SqlParameter("@EmployeeID", EmployeeID));
                return data;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<EmployeePFDataList> getEmployeePFDataDateRange(string fromdate, string todate, string empid)
        {
            try
            {
                var data = new HRMSGenericRepository<EmployeePFDataList>().FindUsingSP("getPFListDateRange @FromDate, @ToDate, @EmployeeID",
                    new SqlParameter("@FromDate", fromdate), new SqlParameter("@ToDate", todate), new SqlParameter("@EmployeeID", empid));
                return data;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<PFEmployeeDepartmentListDto> getOfficeLocations(string empid)
        {
            return new HRMSGenericRepository<PFEmployeeDepartmentListDto>().FindUsingSP("getPFEmployeeLocationList @EmployeeID", new SqlParameter("@EmployeeID", empid));
        }
     
    }
}