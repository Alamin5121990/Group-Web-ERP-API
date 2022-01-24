using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class PurcaseOrderBillReportDto
    {
        public string SupplierID { get; set; }

        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string SupplierType { get; set; }
        public string SupplierCategory { get; set; }
        public string ContactPerson { get; set; }

        public string Fax { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Webaddress { get; set; }

        public string Remarks { get; set; }
        public string Location { get; set; }
        public string MachineNameIP { get; set; }
        public Nullable<Boolean> Transfered { get; set; }
        public Nullable<Boolean> HOTransfered { get; set; }

        public string Addedby { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }
        public string Updatedby { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }
        public Nullable<int> ID { get; set; }

        public Nullable<int> SupplierTypeID { get; set; }
        public Nullable<int> SupplierCategoryID { get; set; }
        public Nullable<Boolean> IsCanceled { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
        public string CanceledByID { get; set; }

        public string CanceledRemark { get; set; }

        public int POCount { get; set; }

        public string SupplierCategoryName { get; set; }

        public string SupplierTypeName { get; set; }
        public string SupplierTypeNameUD { get; set; }
        public string SupplierCategoryNameUD { get; set; }


        public List<POBillDetailsforPOReportDto> POBillDetailsList = new List<POBillDetailsforPOReportDto>();
    }

    public class POBillDetailsforPOReportDto
    {
        public string SupplierID { get; set; }

        public string ManufacturerID { get; set; }
        public string POID { get; set; }
        public Nullable<Boolean> IsVerified { get; set; }
        public string VerifiedBy { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public Nullable<decimal> POAmount { get; set; }
        public Nullable<decimal> POVat { get; set; }
        public Nullable<decimal> PODiscount { get; set; }
        public Nullable<Boolean> IsPOClosed { get; set; }

        public Nullable<DateTime> POClosedOn { get; set; }
        public string POClosedBy { get; set; }
        public Nullable<Boolean> IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<DateTime> ApprovedDate { get; set; }

        public string ModeofPayment { get; set; }
        public string Subject { get; set; }
        public string BillID { get; set; }
        public Nullable<DateTime> BillDate { get; set; }

        public Nullable<Boolean> IsBillForwarded { get; set; }
        public Nullable<DateTime> BillForwardOn { get; set; }
        public Nullable<Boolean> AccountsReceived { get; set; }
        public Nullable<DateTime> AccountsReceiveDate { get; set; }

        public Nullable<decimal> BillAmount { get; set; }
        public Nullable<decimal> BillVat { get; set; }
        public Nullable<decimal> BillAIT { get; set; }
        public Nullable<decimal> BillReviewAmount { get; set; }

        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<DateTime> PaidDate { get; set; }
    }
}