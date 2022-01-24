using LabaidMIS.Data.Classes.Inventory.Requisitions;
using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class MaterialApprovedSources
    {
        public string IndentorID { get; set; }
        public string IndentorName { get; set; }
        public string IndentatorEmail { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Webaddress { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierEmail { get; set; }
        public string ManufacturerID { get; set; }
        public string ManufactrerName { get; set; }
        public string ManufacturerEmail { get; set; }

        public string ColorCode { get; set; }
        public List<ColorCodes> ColorCodeList { get; set; }
        public Nullable<Boolean> IsSelected { get; set; }
    }
}