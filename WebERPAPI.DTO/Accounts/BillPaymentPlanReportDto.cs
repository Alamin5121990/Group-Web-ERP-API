using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.Accounts
{
    public class BillPaymentPlanReportDto : BaseEntityDTO
    {
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }

        public string BillID { get; set; }

        public Nullable<DateTime> BillDate { get; set; }
        public Nullable<decimal> TotalBillSubmitAmount { get; set; }
        public Nullable<decimal> ApprovedTotal { get; set; }
        public string POID { get; set; }

        public Nullable<decimal> POTotalAmount { get; set; }

        public Nullable<decimal> TotalDecideToPay { get; set; }
        public string PaymentTypeName { get; set; }
    }
}