using System;

namespace WebERPAPI.DTO.Accounts
{
    public class SupplierTDS
    {
        public int BillGroupID { get; set; }
        public string BillGroupName { get; set; }
        public Nullable<decimal> TDSPercent { get; set; }
    }

    public class SupplierTDSNew
    {
        public string SupplierCode { get; set; }
        public string BillGroupName { get; set; }
        public Nullable<decimal> TDSPercent { get; set; }
    }
}