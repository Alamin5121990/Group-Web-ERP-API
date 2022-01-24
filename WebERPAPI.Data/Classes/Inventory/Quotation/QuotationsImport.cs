using System;

namespace LabaidMIS.Data.Classes.Inventory.Quotation
{
    public class QuotationsImport
    {
        public string MaterialCode { get; set; }
        public Nullable<int> QuotationID { get; set; }
        public string QuotationCode { get; set; }
        public string MaterialName { get; set; }
        public string MaterialGrade { get; set; }
        public string UOM { get; set; }

        public string ModeOfShipment { get; set; }
        public Nullable<DateTime> LastReceivedDate { get; set; }
        public Nullable<decimal> InvitedQuantity { get; set; }

        public Nullable<int> TotalInvitedIndentor { get; set; }
        public Nullable<int> TotalQuotationReceived { get; set; }

        public string RequisitionCode { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
    }
}