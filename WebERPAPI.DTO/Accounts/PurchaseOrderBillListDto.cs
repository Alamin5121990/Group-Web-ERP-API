using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.Accounts
{
    public class PurchaseOrderBillListDto
    {
        public string BillID { get; set; }

        public Nullable<decimal> TotalBillAmount { get; set; }
        public Nullable<decimal> TotalAIT { get; set; }
        public Nullable<int> TotalCH { get; set; }
        public Nullable<decimal> TotalVAT { get; set; }
        public Nullable<DateTime> BillDate { get; set; }

        public string BillGroup { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<decimal> AdvancePaid { get; set; }
        public Nullable<Boolean> IsForwarded { get; set; }

        public Nullable<DateTime> ForwardOn { get; set; }
        public string ForwardRemarks { get; set; }
        public string ForwardBy { get; set; }
        public Nullable<Boolean> IsAccountsReceived { get; set; }
        public Nullable<DateTime> AccountsReceiveDate { get; set; }

        public string AccountsReceiveBy { get; set; }
        public string AccountsRemarks { get; set; }
        public Nullable<Boolean> IsBillSettled { get; set; }
        public Nullable<DateTime> BillSettledOn { get; set; }
        public string BillSettleRemarks { get; set; }

        public string BillSettleBy { get; set; }
        public Nullable<decimal> CarryingCharge { get; set; }
        public Nullable<decimal> LoadingCharge { get; set; }
    }
}