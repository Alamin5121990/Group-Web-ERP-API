using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class ItemStockUpdateHistoryDto
    {
        public string GRNCode { get; set; }

        public Nullable<int> QRNID { get; set; }
        public Nullable<decimal> LastStockQuantity { get; set; }
        public Nullable<decimal> StockInQuantity { get; set; }
        public Nullable<decimal> StockOutQuantity { get; set; }
        public Nullable<decimal> CurrentStockQuantity { get; set; }

        public string UOM { get; set; }
        public Nullable<decimal> PassedQuantity { get; set; }
        public string Remarks { get; set; }
        public string StockChangeType { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public string LastUpdatedBy { get; set; }
    }
}