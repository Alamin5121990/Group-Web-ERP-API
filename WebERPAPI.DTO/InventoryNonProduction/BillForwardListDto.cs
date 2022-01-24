using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class BillForwardListMasterDto
    {
        public string SupplierName { get; set; }
        public string SupplierID { get; set; }
        public List<BillForwardListDto> bills = new List<BillForwardListDto>();
    }

    public class BillForwardListDto
    {
        public string BillID { get; set; }

        public string ChallanID { get; set; }
        public string POID { get; set; }
        public string GRNID { get; set; }
        public Nullable<decimal> BillAmount { get; set; }
        public Nullable<decimal> VatAmt { get; set; }
        public string AddedBy { get; set; }
        public Nullable<DateTime> BillDate { get; set; }
        public string BillGroup { get; set; }
        public string SupplierName { get; set; }
        public string SupplierID { get; set; }

        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
    }

    public class InventoryAccountReceivePendingListDto
    {
        public string POID { get; set; }

        public string BillID { get; set; }
        public Nullable<DateTime> BillDate { get; set; }
        public string SubmittedBy { get; set; }
        public string BillGroup { get; set; }
        public string SupplierID { get; set; }

        public string ItemID { get; set; }
        public string ItemName { get; set; }

        public Nullable<Boolean> IsForwarded { get; set; }
        public Nullable<Boolean> IsCanceled { get; set; }
        public Nullable<Boolean> IsAccountsReceived { get; set; }
        public Nullable<DateTime> AccountsReceiveDate { get; set; }
        public string AccountReceivedBy { get; set; }

        public string AddedBy { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }

        public Nullable<decimal> BillAmount { get; set; }

        public Nullable<decimal> VatAmt { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public string SupplierName { get; set; }
        public string CreatedBy { get; set; }

        public int AccountReceiveDue { get; set; }
    }

    public class SupplierListForBillForwardDto
    {
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public Nullable<int> NumberOfBill { get; set; }
    }

    public class InventoryBillForwardedListMasterDto
    {
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }

        public List<InventoryAccountReceivePendingListDto> Bills = new List<InventoryAccountReceivePendingListDto>();
    }

    public class InventoryAdvancePaymentPendingListDto
    {
        public string POID { get; set; }

        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> POAmount { get; set; }
        public Nullable<decimal> AdvancePercent { get; set; }
        public Nullable<decimal> AdvancePaymentAmount { get; set; }

        public Nullable<Boolean> IsUrgent { get; set; }
        public string CreatedBy { get; set; }
        public bool IsReceivedFromAccounts { get; set; }

        public string ApprovalRemarks { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedById { get; set; }

        public int AccountReceiveDue { get; set; }
    }
}