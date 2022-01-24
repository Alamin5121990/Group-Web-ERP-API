using System;

namespace LabaidMIS.Data.Classes.Inventory.Requisitions
{
    public class RequisitionUpdate
    {
        public string RequisitionID { get; set; }
        public string Remarks { get; set; }
        public string EmployeeCode { get; set; }

        public string Data { get; set; }
    }

    public class RequisitionMaterialUpdate
    {
        public string MaterialCode { get; set; }
        public string VersionNo { get; set; }
        public decimal Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}