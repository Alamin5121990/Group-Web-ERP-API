using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.Inventory.GRN
{
    public class GRNDetailDto
    {
        public string GRNID { get; set; }

        public string MaterialCode { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> ReceiveQty { get; set; }
        public Nullable<decimal> Rate { get; set; }

        public string BatchNo { get; set; }
        public Nullable<DateTime> MFGDate { get; set; }
        public Nullable<DateTime> ExpiryDate { get; set; }
        public string PackingInfo { get; set; }
        public string Damage { get; set; }

        public string RoomNo { get; set; }
        public string RackNo { get; set; }
        public string Remarks { get; set; }
    }

    public class GRNNewID
    {
        public string NewGRNID { get; set; }
    }
}