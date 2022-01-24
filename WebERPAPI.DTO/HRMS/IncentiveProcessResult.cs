using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.HRMS
{

	public class IncentiveReportBrandWiseProcessDto
	{
		
		public Nullable<int> ProductBrandID { get; set; }
		public string BrandName { get; set; }
		
		public Nullable<decimal> Month1Target { get; set; }
		public Nullable<decimal> Month1Sale { get; set; }

		public Nullable<decimal> Month2Target { get; set; }
		public Nullable<decimal> Month2Sale { get; set; }

		public Nullable<decimal> Month3Target { get; set; }
		public Nullable<decimal> Month3Sale { get; set; }

		public Nullable<decimal> MustAchievePercent { get; set; }
		public Nullable<decimal> Achieve { get; set; }
	}


	public class IncentiveReportBrandWiseDto
	{
		public Nullable<int> IncentiveYear { get; set; }

		public Nullable<int> IncentiveQuarter { get; set; }
		public string EmployeeID { get; set; }
		public string Designation { get; set; }
		public string TerritoryID { get; set; }
		public string AreaID { get; set; }
		public string RegionID { get; set; }
		public Nullable<int> MonthNo { get; set; }
		public Nullable<int> ProductBrandID { get; set; }
		public string BrandName { get; set; }
		public Nullable<int> ProductCount { get; set; }
		public Nullable<decimal> Target { get; set; }

		public Nullable<decimal> Sales { get; set; }
		public Nullable<decimal> MustAchievePercent { get; set; }
		public Nullable<decimal> Achieve { get; set; }
	}


	public class IncentiveProcessResult
    {
        public bool Result { get; set; }
    }
	public class IncentiveReportLocationListDto
	{
		public string RegionID { get; set; }

		public string RegionName { get; set; }
		public string AreaID { get; set; }
		public string AreaName { get; set; }
	}

	public class IncentiveReultDto
	{
		public Nullable<int> ID { get; set; }

		public string IncentiveCode { get; set; }
		public string IncentiveCategory { get; set; }
		public Nullable<int> IncentiveYear { get; set; }
		public Nullable<int> IncentiveQuarter { get; set; }
		public string EmployeeID { get; set; }

		public string Designation { get; set; }
		public Nullable<DateTime> DOJ { get; set; }
		public Nullable<DateTime> DOS { get; set; }
		public string MonthlTerritoryID { get; set; }
		public Nullable<decimal> Month1Target { get; set; }

		public Nullable<decimal> Month1TSale { get; set; }
		public Nullable<decimal> Month1Achieve { get; set; }
		public string Month2TerritoryID { get; set; }
		public Nullable<decimal> Month2Target { get; set; }
		public Nullable<decimal> Month2TSale { get; set; }

		public Nullable<decimal> Month2Achieve { get; set; }
		public string Month3TerritoryID { get; set; }
		public Nullable<decimal> Month3Target { get; set; }
		public Nullable<decimal> Month3TSale { get; set; }
		public Nullable<decimal> Month3Achieve { get; set; }

		public Nullable<decimal> QuarterlyTarget { get; set; }
		public Nullable<decimal> QuarterlySale { get; set; }
		public Nullable<decimal> QuarterlyAchieve { get; set; }
		public Nullable<decimal> QuarterlyAchieveExtra { get; set; }
		public Nullable<Boolean> IsEligibleForIncentive { get; set; }

		public Boolean IsIncentive { get; set; }
		public Nullable<decimal> IncentiveAmount { get; set; }
		public Nullable<decimal> ExtraIncentiveAmount { get; set; }
		public Nullable<Boolean> IsProductIncentive { get; set; }
		public Nullable<decimal> ProductAchieveAmount { get; set; }

		public Nullable<Boolean> IsOwnEmployee { get; set; }
		public Nullable<Boolean> IsDisqualified { get; set; }
		public string DisqualifiedRemark { get; set; }
		public string DisqualifiedByID { get; set; }
		public Nullable<DateTime> DisqualifiedOn { get; set; }

		public string CreatedByID { get; set; }
		public string MPOID { get; set; }
		public string MPO { get; set; }
		public string TerritoryID { get; set; }

		public string TerritoryName { get; set; }
		public string AreaID { get; set; }
		public string AreaName { get; set; }
		public string ASMID { get; set; }
		public string ASMName { get; set; }

		public string RegionID { get; set; }
		public string RegionName { get; set; }
		public string RSMID { get; set; }
		public string RSMName { get; set; }


		public Nullable<decimal> SalesDesignationAmount { get; set; }
		public Nullable<decimal> ProductDesignationAmount { get; set; }
	}
}
