using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class PPICNewRequisitionData
    {
        public string EmployeeCode { get; set; }
        public string MaterialTypeCode { get; set; }
        public DateTime RequisitionDate { get; set; }
        public string Remarks { get; set; }
        public string Data { get; set; }
    }

    public class PPICNewRequisition
    {
        public string MaterialCode { get; set; }
        public string MaterialGrade { get; set; }
        public string ModeOfShipment { get; set; }

        public DateTime DeliveryDate { get; set; }
        public decimal RequisitionQuantity { get; set; }
        public string VersionNo { get; set; }
    }
}