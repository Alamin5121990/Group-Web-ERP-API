using System;
using System.Collections.Generic;
using WebERPAPI.DTO.Inventory.ComparativeStudyNP;

namespace WebERPAPI.DTO.Inventory.PurchaseOrdersNP
{
    public class ComparativeStudySuppliersNP
    {
        public string SupplierCode { get; set; }

        public string SupplierName { get; set; }
        public Nullable<int> NumberOfRequisition { get; set; }
        public string InventoryTypeName { get; set; }
        public string MainGroupName { get; set; }
        public Nullable<int> InventoryTypeID { get; set; }

        public Nullable<int> MainGroupID { get; set; }
        public Nullable<DateTime> LastCSON { get; set; }

        public List<ComparativeStudyForPurchaseNP> poList = new List<ComparativeStudyForPurchaseNP>();
    }
}