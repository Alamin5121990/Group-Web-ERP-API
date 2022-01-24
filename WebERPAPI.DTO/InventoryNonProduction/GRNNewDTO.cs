using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class GRNNewDTO
    {
        public int ID { get; set; }
        public string GRNCode { get; set; }
        public int POID { get; set; }
        public string SupplierCode { get; set; }
        public string ChallanNumber { get; set; }
        public DateTime ChallanDate { get; set; }
        public int MainGroupID { get; set; }
        public int StoreID { get; set; }

        public string VATChallanNumber { get; set; }
        public Nullable<DateTime> VATChallanDate { get; set; }
        public Boolean IsVDSAllowed { get; set; }

        public string CreatedByID { get; set; }
        public string Remarks { get; set; }
        public string Data { get; set; }
        public string VATChallanData { get; set; }
    }

    public class GRNNewItemsDTO
    {
        public int OrderNumber { get; set; }
        public int ItemID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public string SerialNumber { get; set; }
    }
}