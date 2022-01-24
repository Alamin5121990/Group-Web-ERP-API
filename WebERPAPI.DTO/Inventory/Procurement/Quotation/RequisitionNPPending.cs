using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO.Inventory.Procurement.Quotation
{
    public class RequisitionNPPending
    {
        public string RequisitionCode { get; set; }

        public Nullable<int> RequisitionID { get; set; }
        public string StoreName { get; set; }
        public Nullable<int> TotalMaterial { get; set; }
        public string ItemNames { get; set; }
        public string RequisitionType { get; set; }
        public string RequisitionRemarks { get; set; }

        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string CreatedByDesignation { get; set; }
        public string CreatedByLocation { get; set; }
        public string VerifiedBy { get; set; }
        public Nullable<DateTime> VerifiedOn { get; set; }
        public string VerifyRemarks { get; set; }

        public string ApprovedBy { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public string ApprovalRemarks { get; set; }

        public bool IsApproved { get; set; }

        public int Age { get; set; }

        //public List<InventoryRequisitionDetails> ItemList = new List<InventoryRequisitionDetails>();
    }
}