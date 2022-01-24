using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.Accounts
{
    public class DecideToPayDto
    {
        public int ID { get; set; }
        public string BillCode { get; set; }

        public Nullable<decimal> AmountToPay { get; set; }
        public Nullable<int> BankID { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string PaymentTypeName { get; set; }

        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Boolean IsCanceled { get; set; }
    }
}