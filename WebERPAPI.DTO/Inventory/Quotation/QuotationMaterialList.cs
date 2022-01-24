using System;

namespace WebERPAPI.DTO.Inventory
{
    public class QuotationMaterialList
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string RequisitionCode { get; set; }

        public string VersionNo { get; set; }
        public string MaterialGrade { get; set; }
        public string ModeOfShipment { get; set; }

        public Nullable<int> IsReceived { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public Nullable<Boolean> IsCanceled { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }

        public string ReasonToCanceled { get; set; }
        public string CanceledBy { get; set; }
    }
}