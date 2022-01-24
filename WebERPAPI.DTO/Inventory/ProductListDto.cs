using System;

namespace WebERPAPI.DTO.Inventory
{
    public class ProductListDto : BaseEntity2DTO
    {
        public string ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Nullable<int> BrandID { get; set; }

        public string BrandName { get; set; }
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
        public Nullable<int> ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }

        public Nullable<int> GenericID { get; set; }
        public string GenericName { get; set; }
        public Nullable<int> ProductStateID { get; set; }
        public string ProductStateName { get; set; }
        public Nullable<int> ProductFormID { get; set; }

        public string FormName { get; set; }
        public Nullable<int> DosageFormID { get; set; }
        public Nullable<int> CommericalProductID { get; set; }
        public string DosageFormName { get; set; }
        public string CommericalProductName { get; set; }
    }

    public class ProductionLocationListDto
    {
        public Nullable<int> ID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
    }
}