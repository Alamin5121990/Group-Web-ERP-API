using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.HRMS
{
    public class PFEmployeeListDto
    {
        public Nullable<decimal> PFDeductionTotalAmount { get; set; }

        public Nullable<int> PFDeductionMonthCount { get; set; }
        public string ServiceLength { get; set; }

        public Nullable<DateTime> PFMemberShipFrom { get; set; }
        public Nullable<int> MonthFromPFMembership { get; set; }
        public Nullable<int> CompanyContributionPercent { get; set; }

        public Nullable<decimal> CompanyContributionAmount { get; set; }

        public string EmployeeID { get; set; }
        public Nullable<int> CardNo { get; set; }
        public string Salutation { get; set; }

        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string NickName { get; set; }
        public string EmployeeName { get; set; }

        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public Nullable<DateTime> DOB { get; set; }
        public string BloodGroup { get; set; }
        public string Height { get; set; }

        public string Weight { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string Sex { get; set; }
        public string MaritalStatus { get; set; }

        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }

        public string NationalIDNo { get; set; }
        public string EPersonName { get; set; }
        public string EPersonAddress { get; set; }
        public string EPersonTelephone { get; set; }
        public string EmployeeStatus { get; set; }

        public string EmployeeType { get; set; }
        public string CompanyID { get; set; }
        public string Department { get; set; }
        public string SubDepartment { get; set; }
        public string Designation { get; set; }

        public string Location { get; set; }
        public string Zone { get; set; }
        public string Region { get; set; }
        public string Area { get; set; }
        public string Territory { get; set; }

        public Nullable<DateTime> DOJ { get; set; }
        public Nullable<DateTime> DOS { get; set; }
        public string JoiningPosition { get; set; }
        public string JoiningGrade { get; set; }
        public string AcademicAward { get; set; }

        public string DrivingLicence { get; set; }
        public string Passport { get; set; }
        public string VisitCountry { get; set; }
        public string ExtraActivities { get; set; }
        public string MajorIllness { get; set; }

        public string SuperVisorID { get; set; }
        public Nullable<DateTime> ConfirmationDate { get; set; }
        public string ConfirmationStatus { get; set; }
        public Nullable<Boolean> Certification { get; set; }
        public Nullable<DateTime> LastAppDate { get; set; }

        public string LastAppType { get; set; }
        public string CostCenter { get; set; }
        public string Remarks { get; set; }
        public string LeaveRuleID { get; set; }
        public string MachineNameIP { get; set; }

        public Nullable<Boolean> Transfered { get; set; }
        public Nullable<Boolean> HOTransfered { get; set; }
        public string Addedby { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }
        public string Updatedby { get; set; }

        public Nullable<DateTime> DateUpdated { get; set; }
        public Nullable<int> ID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> DesignationID { get; set; }
        public Nullable<int> OfficeLocationID { get; set; }
    }

    public class PFEmployeeDepartmentListDto
    {
        public string DepartmentName { get; set; }

        public Nullable<int> PFEmpCount { get; set; }
    }

    public class EmployeePFDataList
    {
        public string MSCode { get; set; }

        public Nullable<DateTime> ProcessDate { get; set; }
        public Nullable<int> SalaryYear { get; set; }
        public Nullable<int> SalaryMonth { get; set; }
        public Nullable<DateTime> PFMemberShipFrom { get; set; }
        public Nullable<int> MonthFromPFMembership { get; set; }
        public string PFMembershipLength { get; set; }
        public Nullable<int> CompanyContributionPercent { get; set; }
        public Nullable<decimal> CompanyContributionAmount { get; set; }

        public string MonthName { get; set; }
        public Nullable<decimal> Amount { get; set; }

        public Nullable<decimal> BasicSalary { get; set; }
        public Nullable<decimal> GrossSalary { get; set; }
        public string ServiceLength { get; set; }
        public string EmployeeID { get; set; }
        public Nullable<int> CardNo { get; set; }

        public string Salutation { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string NickName { get; set; }

        public string EmployeeName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public Nullable<DateTime> DOB { get; set; }
        public string BloodGroup { get; set; }

        public string Height { get; set; }
        public string Weight { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string Sex { get; set; }

        public string MaritalStatus { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string PresentAddress { get; set; }

        public string PermanentAddress { get; set; }
        public string NationalIDNo { get; set; }
        public string EPersonName { get; set; }
        public string EPersonAddress { get; set; }
        public string EPersonTelephone { get; set; }

        public string EmployeeStatus { get; set; }
        public string EmployeeType { get; set; }
        public string CompanyID { get; set; }
        public string Department { get; set; }
        public string SubDepartment { get; set; }

        public string Designation { get; set; }
        public string Location { get; set; }
        public string Zone { get; set; }
        public string Region { get; set; }
        public string Area { get; set; }

        public string Territory { get; set; }
        public Nullable<DateTime> DOJ { get; set; }
        public Nullable<DateTime> DOS { get; set; }
        public string JoiningPosition { get; set; }
        public string JoiningGrade { get; set; }

        public string AcademicAward { get; set; }
        public string DrivingLicence { get; set; }
        public string Passport { get; set; }
        public string VisitCountry { get; set; }
        public string ExtraActivities { get; set; }

        public string MajorIllness { get; set; }
        public string SuperVisorID { get; set; }
        public Nullable<DateTime> ConfirmationDate { get; set; }
        public string ConfirmationStatus { get; set; }
        public Nullable<Boolean> Certification { get; set; }

        public Nullable<DateTime> LastAppDate { get; set; }
        public string LastAppType { get; set; }
        public string CostCenter { get; set; }
        public string Remarks { get; set; }
        public string LeaveRuleID { get; set; }

        public string MachineNameIP { get; set; }
        public Nullable<Boolean> Transfered { get; set; }
        public Nullable<Boolean> HOTransfered { get; set; }
        public string Addedby { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }

        public string Updatedby { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }
        public Nullable<int> ID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> DesignationID { get; set; }

        public Nullable<int> OfficeLocationID { get; set; }
    }
}