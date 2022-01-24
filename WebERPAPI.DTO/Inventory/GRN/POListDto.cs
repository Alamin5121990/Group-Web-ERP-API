using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.Inventory.GRNProduction
{
    public class POListDto
    {
        public string POID { get; set; }

        public Nullable<DateTime> PODate { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }

        public string Manufacturer { get; set; }
        public string Subject { get; set; }
        public string RequiredFor { get; set; }
        public Nullable<DateTime> RequiredDate { get; set; }
        public string ModeofPayment { get; set; }

        public string Currency { get; set; }
        public string CurrencyName { get; set; }
        public string RequisitionID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialGrade { get; set; }

        public string MaterialName { get; set; }
        public Nullable<decimal> POQty { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public string UOM { get; set; }

        public Nullable<decimal> Vat { get; set; }
        public Nullable<decimal> TotalValue { get; set; }
        public Nullable<int> NumberOfGRN { get; set; }
        public Nullable<decimal> ReceiveQty { get; set; }
        public Nullable<decimal> PendingQty { get; set; }
    }

    public class LCListForProductionGRNEntryDto
    {
        public string LCID { get; set; }

        public string LCNo { get; set; }
        public Nullable<DateTime> LCDate { get; set; }
        public Nullable<DateTime> LastShipDate { get; set; }
        public string Currency { get; set; }
        public Nullable<decimal> ConvRate { get; set; }

        public Nullable<decimal> LCValue { get; set; }
        public Nullable<DateTime> ExpireDate { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string BankID { get; set; }

        public string BankName { get; set; }
        public string IndenterID { get; set; }
        public string IndenterName { get; set; }
        public string IndentNo { get; set; }
        public string InsuranceNo { get; set; }

        public Nullable<DateTime> InsuranceDate { get; set; }
        public Nullable<decimal> InsuranceValue { get; set; }
        public string LCTT { get; set; }
        public string RequisitionID { get; set; }
        public string MaterialCode { get; set; }

        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> TotalValue { get; set; }

        public string CountryOfOrigin { get; set; }
        public string ManufacturerID { get; set; }
        public string ProjectCD { get; set; }
        public string ManufacturerName { get; set; }
        public string ShipMode { get; set; }

        public Nullable<int> NumberOfGRN { get; set; }
        public Nullable<decimal> ReceiveQty { get; set; }
        public Nullable<decimal> PendingQty { get; set; }
    }
}