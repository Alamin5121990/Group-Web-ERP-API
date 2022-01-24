using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.Inventory
{
    public class MaterialStockLedgerDateBetween
    {
		public string MaterialCode { get; set; }

		public string GRNID { get; set; }
		public Nullable<DateTime> TransactionDate { get; set; }
		public Nullable<decimal> Rate { get; set; }
		public string UOM { get; set; }
		public string SupplierID { get; set; }

		public string SupplierName { get; set; }
		public Nullable<decimal> Opening { get; set; }
		public Nullable<decimal> PreviousStock { get; set; }
		public Nullable<decimal> GRNQty { get; set; }
		public Nullable<decimal> PositiveAdjustmentQty { get; set; }

		public Nullable<decimal> BatchReturnQty { get; set; }
		public Nullable<decimal> ReTestPassedQty { get; set; }
		public Nullable<decimal> NegativeAdjustmentQty { get; set; }
		public Nullable<decimal> ExpiredQty { get; set; }
		public Nullable<decimal> RejectedQty { get; set; }

		public Nullable<decimal> OtherNegativeAdjustment { get; set; }
		public Nullable<decimal> BatchIssueQty { get; set; }
		public Nullable<decimal> TestConsumptionQty { get; set; }
		public Nullable<decimal> TransferQty { get; set; }
		public Nullable<decimal> ReTestQty { get; set; }

		public Nullable<decimal> ReTestConsumptionQty { get; set; }
		public Nullable<decimal> Closing { get; set; }
	}
}
