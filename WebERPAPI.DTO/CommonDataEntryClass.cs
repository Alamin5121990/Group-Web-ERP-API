using System;
using System.Collections.Generic;
using System.Web;

namespace WebERPAPI.DTO
{
    public class CommonDataEntryClass
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string ItemName { get; set; }
        public string Data { get; set; }
        public string EmployeeCode { get; set; }
        public int EmployeeID { get; set; }
        public string Remarks { get; set; }

        public decimal Quantity { get; set; }
        public int TypeID { get; set; }

        public Nullable<DateTime> Date { get; set; }

        // Add = 1 or Delete = 0
        public int ActionGroupID { get; set; }
    }
}