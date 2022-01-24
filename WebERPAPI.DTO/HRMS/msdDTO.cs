using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.HRMS
{
    class msdDTO
    {

    }
    public class MPORecruitment_BatchDTO
    {
        public Nullable<int> Id { get; set; }

        public Nullable<int> BatchNo { get; set; }

	public string BatchMonth { get; set; }
	public Nullable<int> BatchYear { get; set; }
	public string BatchType { get; set; }
	public Nullable<int> WrittenScore { get; set; }
	public Nullable<int> VivaScore { get; set; }
	public Nullable<int>  TotalScore { get; set; }
	public string BatchStartTime { get; set; }
	public string BatchEndTime { get; set; }
	public DateTime BatchStartDate { get; set; }
	public DateTime BatchEndDate { get; set; }

    public DateTime UpdatedOn { get; set; }
    public DateTime CreatedOn { get; set; }

    public string CreatedById { get; set; }
    public string UpdatedById { get; set; }
    
    public bool IsActive { get; set; }



    }
    public class MPORecruitment_BatchwiseMPOListDTO
    {
        public Nullable<int> Id { get; set; }

        public Nullable<int> BatchNo { get; set; }

        public string ApplicantName { get; set; }
        public Nullable<int> BatchYear { get; set; }
        public string Mobile { get; set; }
        public Nullable<decimal> WrittenScore { get; set; }
        public Nullable<decimal> VivaScore { get; set; }
        public Nullable<decimal> TotalScore { get; set; }
        public string Location { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }

        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }

        public bool IsActive { get; set; }

        public bool IsAssesmentAbsent { get; set; }

        public Nullable<int> PresentMPOId { get; set; }
        public string Thana { get; set; }
        public string District { get; set; }
        public string TerritoryName { get; set; }
        public string TerritoryCode { get; set; }
        public string AreaCode { get; set; }
        public string Region { get; set; }
        public int? NoOfTrainingDays { get; set; }
        public Nullable<decimal> AllowancePerDay { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }

        public string SuperVisorId { get; set; }





    }
    public class MPORecruitment_AssesmentsDTO
    {
        public Nullable<int> Id { get; set; }

        public Nullable<int> BatchNo { get; set; }

        public Nullable<int> ApplicantId { get; set; }
        public string AssesmentType { get; set; }

        public string AssesmentName { get; set; }
        public Nullable<int> AssesmentMarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }

        public string CreatedByID { get; set; }
        public string UpdatedByID { get; set; }


    }
    public class MPO_Recruitment_Applicant
    {
        public int Id { get; set; }
      
        public string ApplicantName { get; set; }

        public Nullable<int> BatchNo { get; set; }

        public Nullable<int> PresentMPOId { get; set; }

        public List<MPO_Recruitment_AssesmentList> assesmentList = new List<MPO_Recruitment_AssesmentList>();

    }

    public class MPO_Recruitment_AssesmentList
    {
        public int ID { get; set; }
        public string AssesmentName { get; set; }
        public decimal? Assesmentmarks { get; set; }

        public Nullable<int> MPOMarksId { get; set; }
    }
    public class MPORecruitment_MPOAssesmentsMarksDTO
    {
        public Nullable<int> Id { get; set; }

        public Nullable<int> MPOId { get; set; }

        public Nullable<int> AssesmentId { get; set; }

        public Nullable<decimal> AssesmentMarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }

        public string CreatedByID { get; set; }
        public string UpdatedByID { get; set; }


    }
    public class MPORecruitment_MPOAssesmentFinalResultDTO
    {
        public string ApplicantName { get; set; }

        public Nullable<int> PresentMPOId { get; set; }

        public Nullable<decimal> BasicAssesmentTotal { get; set; }

        public Nullable<decimal> ProductAssesmentTotal { get; set; }

        public Nullable<decimal> AverageNumber { get; set; }
        public int Id { get; set; }
        public string PermanentAddress { get; set; }





    }
}
