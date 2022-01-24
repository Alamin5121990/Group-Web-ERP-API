using System;

namespace WebERPAPI.DTO.Accounts
{
    public class QuotationByToken
    {
        public string RequisitionCode { get; set; }

        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string MaterialGrade { get; set; }
        public string ShortSpec { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<DateTime> LastReceivedDate { get; set; }
    }
}