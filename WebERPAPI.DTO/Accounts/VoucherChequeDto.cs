using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.Accounts
{
    public class VoucherChequeDto
    {
        public string Narration { get; set; }
        public string VoucherID { get; set; }

        public string VoucherNo { get; set; }
        public Nullable<DateTime> VoucherDate { get; set; }
        public string BillID { get; set; }
        public Nullable<DateTime> IssueDate { get; set; }
        public Nullable<decimal> Debit { get; set; }

        public string AddedBy { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }

        public string ACode { get; set; }
        public string ChequeBookRef { get; set; }
        public string ChequeNumber { get; set; }
        public string ChequeBookPrefix { get; set; }
        public string ChequeStatus { get; set; }

        public string Remarks { get; set; }
        public Nullable<Boolean> ChequeIssued { get; set; }
        public Nullable<Boolean> ChequeHandover { get; set; }
        public Nullable<Boolean> ChequePlaced { get; set; }
        public Nullable<Boolean> ChequeCanceled { get; set; }

        public string Location { get; set; }
        public string MachineNameIP { get; set; }
        public Nullable<Boolean> Transfered { get; set; }
        public Nullable<Boolean> HOTransfered { get; set; }
        public string Addedby { get; set; }

        public Nullable<DateTime> DateAdded { get; set; }
        public string Updatedby { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }
    }
}