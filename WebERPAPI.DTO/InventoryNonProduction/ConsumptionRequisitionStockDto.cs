using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class ConsumptionRequisitionStockDto
    {
        public Nullable<int> ID { get; set; }

        public Nullable<int> StoreID { get; set; }
        public String StoreName { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> StockUpdateTypeID { get; set; }
        public Nullable<decimal> LastStockQuantity { get; set; }
        public Nullable<decimal> StockInQuantity { get; set; }

        public Nullable<decimal> CurrentStockQuantity { get; set; }
        public Nullable<decimal> StockOutQuantity { get; set; }
        public Nullable<int> QRNID { get; set; }
        public Nullable<int> ConsumptionRequisitionID { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }

        public string CreatedByID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string StockChangeType { get; set; }
        public string CreatedBy { get; set; }
        public string RequisitionCode { get; set; }
    }
}