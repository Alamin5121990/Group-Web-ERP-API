using System;

namespace LabaidMIS.Data.Classes.Product
{
    public partial class Brands
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public string CategoryName { get; set; }
        public Nullable<bool> IsTopBrand { get; set; }
    }
}