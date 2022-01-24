using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.InventoryNonProduction
{
   public class InventoryPurchaseOrderAdvancePaidDTO
    {
        public int ID { get; set; }
        public string SupplierCode { get; set; }
        public string POID { get; set; }
        public Nullable<decimal> AdvancePercent { get; set; }
        public Nullable<decimal> AdvanceAmount { get; set; }
        public Nullable<bool> IsUrgent { get; set; }
        public string Remarks { get; set; }
        public string CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}
