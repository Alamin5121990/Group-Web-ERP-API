using System;

namespace WebERPAPI.DTO.Inventory.Products
{
    public class ProductNewDto : BaseEntity2DTO
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Nullable<int> BrandID { get; set; }

        public Nullable<int> ProductTypeID { get; set; }
        public Nullable<int> GenericID { get; set; }
        public Nullable<int> ProductStateID { get; set; }
        public Nullable<int> ProductFormID { get; set; }
        public Nullable<int> DosageFormID { get; set; }
        public string DarNo { get; set; }
        public string PackSize { get; set; }
        public string UOM { get; set; }
        public string SalesCode { get; set; }

        public string PPS { get; set; }
        public string SPS { get; set; }
        public string MPS { get; set; }
        public string Strength { get; set; }
        public Nullable<decimal> TP { get; set; }

        public Nullable<decimal> Vat { get; set; }
        public Nullable<decimal> VatPayable { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public Nullable<int> ShelfMonth { get; set; }
        public Nullable<int> ShelfYear { get; set; }

        public Nullable<DateTime> ExpectedLaunchDate { get; set; }

        public string ProductLocationIDs { get; set; }

        public int CommericalProductID { get; set; }
    }
}