using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class ItemGRNForItemConversionDto
    {
        public Nullable<int> ID { get; set; }

        public string GRNCode { get; set; }
        public string ChallanNumber { get; set; }
        public Nullable<DateTime> ChallanDate { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }

        public Nullable<int> StoreID { get; set; }
        public string StoreName { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> PassedQuantity { get; set; }
    }

    public class ItemConversionMasterDto
    {
        public int StoreID { get; set; }
        public int FromItemID { get; set; }
        public string FromItemName { get; set; }
        public decimal CurrentStockQty { get; set; }
        public string SelectedGRN { get; set; }
        public Nullable<int> SelectedGRNID { get; set; }
        public decimal ConversionQty { get; set; }
        public string EmployeeId { get; set; }
        public string Remark { get; set; }
        public string ToConversionItems { get; set; }
    }

    public class ItemConversionMasterReportDto
    {
        public int ID { get; set; }
        public Nullable<int> GRNID { get; set; }
        public string GRNCode { get; set; }
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal ConversionQuantity { get; set; }
        public string Remarks { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedById { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedByDesignation { get; set; }
        public string ApprovedByDepartment { get; set; }
        public Nullable<System.DateTime> ApprovedOn { get; set; }
        public string CreatedById { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByDesignation { get; set; }
        public string CreatedByDepartment { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ConversionRemark { get; set; }

        public List<ItemConversionDetailsReportDto> DetailItemList = new List<ItemConversionDetailsReportDto>();
    }

    public class ItemConversionDetailDto
    {
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public Nullable<decimal> StockQuantity { get; set; }
        public Nullable<decimal> OpeningQuantity { get; set; }
        public Nullable<decimal> PendingIssueQuantity { get; set; }
        public Nullable<decimal> ConversionQty { get; set; }
    }

    public class ItemConversionDetailsReportDto
    {
        public int ID { get; set; }
        public int CID { get; set; }
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> CurrentStock { get; set; }
        public decimal Quantity { get; set; }
        public string CreateById { get; set; }
        public System.DateTime CreateOn { get; set; }
    }

    public class ItemConversionPendingListDto
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string StoreName { get; set; }
        public Nullable<int> GRNID { get; set; }
        public string GRNCode { get; set; }
        public Nullable<int> ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> CurrentStock { get; set; }
        public Nullable<decimal> ConversionQuantity { get; set; }
        public string Remarks { get; set; }
        public string ConversionRemark { get; set; }
        public Nullable<int> NumberOfItem { get; set; }
        public string CreatedById { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Nullable<Boolean> IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
    }
}