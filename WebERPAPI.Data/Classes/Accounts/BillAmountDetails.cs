using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class BillAmountDetails
    {
        public Nullable<decimal> TotalBillAmount { get; set; }
        public Nullable<decimal> AdvancePaid { get; set; }
        public Nullable<decimal> CarryingCharge { get; set; }
        public Nullable<decimal> LoadingCharge { get; set; }
        public Nullable<decimal> OtherCharge { get; set; }
    }
}