using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO.Inventory
{
    public class PurchaseOrderQCPassReport
    {
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }

        public Nullable<int> TotalPO { get; set; }

        public Nullable<int> TotalPOClosable { get; set; }

        public List<PurchaseOrderQCPassData> POList { get; set; }
    }

    public class PurchaseOrderQCPassData
    {
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }

        public string POID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public Nullable<decimal> QCPassedQuantity { get; set; }
        public Nullable<decimal> PendingQuantity { get; set; }
    }
}