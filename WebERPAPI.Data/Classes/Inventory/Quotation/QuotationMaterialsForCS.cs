using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class QuotationMaterialsForCS
    {
        public string MaterialCode { get; set; }
        public string QuotationCode { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialName { get; set; }

        public Nullable<DateTime> RequisitionDate { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }

        public string UOM { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public string Source { get; set; }
        public string ShortSpec { get; set; }
        public Nullable<int> LeadTime { get; set; }
        public string LeadTimeDetails { get; set; }

        public string ModeOfShipment { get; set; }
        public string CurrencyName { get; set; }

        public Nullable<Boolean> InCS { get; set; }

        //public Nullable<DateTime> PurchaseDate { get; set; }
        //public Nullable<decimal> PurchaseRate { get; set; }
        //public Nullable<decimal> PurchaseQuantity { get; set; }
        public string CSMaterialCode { get; set; }

        public string VersionNo { get; set; }
    }
}