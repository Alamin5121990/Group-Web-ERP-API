using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.Inventory.Purchase_Orders
{
    public class POBillPaymentStatusDto
    {
        public string POID { get; set; }

        public Nullable<DateTime> PODate { get; set; }
        public Nullable<decimal> POAmount { get; set; }
        public Nullable<int> NumberOfGRN { get; set; }
        public Nullable<DateTime> RequiredDate { get; set; }
        public string SupplierID { get; set; }

        public string ManufacturerID { get; set; }
        public Nullable<Boolean> IsApproved { get; set; }
        public Nullable<Boolean> IsPOClosed { get; set; }
        public string POClosedRemarks { get; set; }
        public Nullable<DateTime> POClosedOn { get; set; }

        public Nullable<decimal> TotalBillSubmitted { get; set; }
        public Nullable<DateTime> BillSubmitDate { get; set; }
        public Nullable<DateTime> ForwardOn { get; set; }
        public Nullable<decimal> ForwardAmount { get; set; }
        public Nullable<decimal> ReviewAmount { get; set; }

        public Nullable<decimal> TotalVAT { get; set; }
        public Nullable<decimal> TotalAIT { get; set; }

        public Nullable<Boolean> IsAccountVerified { get; set; }
        public Nullable<DateTime> AccountsVerifiedOn { get; set; }
        public Nullable<decimal> TotalPayable { get; set; }

        public Nullable<int> DueDiff { get; set; }

        public string IsGRN { get; set; }

        public Nullable<DateTime> AccountsReceiveDate { get; set; }

        public Nullable<decimal> BRAdvanceVAT { get; set; }

        public Nullable<decimal> BRAIT { get; set; }
        public Nullable<decimal> OutstandingAmt { get; set; }

        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<DateTime> PaidDate { get; set; }
        public string SupplierCategoryName { get; set; }
        public string SupplierName { get; set; }
        public string BillCode { get; set; }

        public Nullable<DateTime> SBillDate { get; set; }

        public string SupplierBillNo { get; set; }

        public Nullable<DateTime> BillDate { get; set; }




    }
}