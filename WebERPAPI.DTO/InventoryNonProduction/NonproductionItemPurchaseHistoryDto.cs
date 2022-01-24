using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class NonproductionItemPurchaseHistoryDto
    {
        public string GRNCode { get; set; }

        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> GRNReceiveQty { get; set; }
        public Nullable<decimal> GRNRate { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }

        public string POCode { get; set; }
        public Nullable<int> POID { get; set; }
        public Nullable<decimal> POQty { get; set; }
        public Nullable<decimal> PORate { get; set; }
        public Nullable<int> RequisitionID { get; set; }

        public string RequisitionCode { get; set; }
        public Nullable<decimal> RequisitionQty { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }
    }
}