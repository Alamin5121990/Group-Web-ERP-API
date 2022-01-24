using System;

namespace LabaidMIS.Data.Classes.Sales.ConferenceProposal
{
    public class ConferenceProposal
    {
        public string CPCode { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<decimal> VenueCharge { get; set; }
        public string TypeOfCP { get; set; }
        public string MPOID { get; set; }
        public string TerritoryName { get; set; }
        public string AreaID { get; set; }
        public string AreaName { get; set; }
        public Nullable<DateTime> ConferenceDate { get; set; }
        public string ConferenceTopics { get; set; }
        public Nullable<int> DoctorCumChemistPerticipants { get; set; }
        public Nullable<int> InHousePerticipants { get; set; }
        public Nullable<int> PCOrRPMPerticipants { get; set; }
        public Nullable<int> TotalParticipantDoctors { get; set; }
        public Boolean IsPresentationSlideRequired { get; set; }
        public Boolean HasGiftItem { get; set; }
        public Boolean HasPrintedMaterials { get; set; }
        public Nullable<decimal> PerPersonFoodCharge { get; set; }
        public string OtherChargeName { get; set; }
        public Nullable<decimal> OtherCharge { get; set; }
        public string ExpectedOutcome { get; set; }

        public Nullable<DateTime> GMApprovedOn { get; set; }
        public Nullable<DateTime> ZMApprovedOn { get; set; }
        public Nullable<DateTime> PMDManagerApprovedOn { get; set; }

        public string VenueName { get; set; }
        public string InstituteName { get; set; }

        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
    }

    public class ConferenceProposalApproval
    {
        public string CPCode { get; set; }
        public string EmployeeID { get; set; }
        public string SalesLocationLevel { get; set; }
    }
}