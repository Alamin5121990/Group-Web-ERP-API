using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class POBillSubmitMasterNPDTO
    {
        public string SupplierBillNo { get; set; }
        public string Remarks { get; set; }
        public decimal SupplierAdvance { get; set; }
        public decimal CarryingCharge { get; set; }
        public decimal LoadingCharge { get; set; }
        public decimal OtherCharge { get; set; }
        public decimal Discount { get; set; }
        public int InventoryID { get; set; }
        public string SupplierCode { get; set; }
        public string selectedPOCode { get; set; }
        public Nullable<DateTime> SupplierBillDate { get; set; }
        public Nullable<DateTime> BillDate { get; set; }
        public List<POBillSubmitNPDTO> MaterialList { get; set; }

        public string SubmittedBy { get; set; }
        public string Location { get; set; }
        public string MachineNameIP { get; set; }
        public string AddedBy { get; set; }
        public System.DateTime DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }

    public class POBillSubmitNPDTO
    {
        public int POID { get; set; }
        public string POCode { get; set; }
        public int ItemID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public string ChallanNumber { get; set; }
        public DateTime ChallanDate { get; set; }
        public decimal Rate { get; set; }
        public decimal OrderedQty { get; set; }
        public decimal ReceivedQty { get; set; }
        public decimal ItemVATAmount { get; set; }
        public decimal ItemAmount { get; set; }
        public decimal TotalOrderAmount { get; set; }
        public string GRNCode { get; set; }

        public Nullable<decimal> AdvanceAmount { get; set; }
    }
}
