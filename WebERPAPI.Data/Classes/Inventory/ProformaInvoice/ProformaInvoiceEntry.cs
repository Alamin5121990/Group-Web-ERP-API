using System;

namespace LabaidMIS.Data.Classes.Inventory.ProformaInvoice
{
    public class ProformaInvoiceEntry
    {
        public string PICode { get; set; }
        public string PINumber { get; set; }
        public Nullable<System.DateTime> RevisedDate { get; set; }

        public string Data { get; set; }

        public string OriginOfGoods { get; set; }
        public string PackingInfo { get; set; }
        public string TransShipment { get; set; }
        public string PartShipment { get; set; }
        public string ShelfLife { get; set; }
        public string DocumentsForExporter { get; set; }
        public string Payment { get; set; }
        public string Delivery { get; set; }
        public string DeliveryTerm { get; set; }

        public string EmployeeID { get; set; }
    }

    public class ProformaInvoiceDetails
    {
        public string HSCode { get; set; }
        public Nullable<int> CSID { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string ModeOfShipment { get; set; }

        public Nullable<int> CurrencyID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
    }
}