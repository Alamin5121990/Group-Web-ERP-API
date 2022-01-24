using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.Accounts;
using WebERPAPI.DTO.Inventory;
using WebERPAPI.DTO.InventoryNonProduction;
using WebERPAPI.DTO.Supplier;

namespace WebERPAPI.Data.Repository.InventoryNonProduction
{
    public class BillSubmitNPRepositories
    {

        public List<BillDetails> getBillDetails(string BillId)
        {
            try
            {
                var billid = new SqlParameter("@BillID", BillId);

                using (InventoryEntities db = new InventoryEntities())
                {
                    return db.Database.SqlQuery<BillDetails>("getBillDetails @BillID", billid).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public BillInfo getBill(string BillCode)
        {
            try
            {
                var billCode = new SqlParameter("@BillCode", BillCode);

                using (InventoryEntities db = new InventoryEntities())
                {
                    return db.Database.SqlQuery<BillInfo>("getBill @BillCode", billCode).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<SupplierBasicDto> getSupplierListByInventoryType(int InventoryTypeID)
        {
            return new InventoryGenericRepository<SupplierBasicDto>().FindUsingSP("getSupplierListByInventoryTypeNP @InventoryTypeID", new SqlParameter("@InventoryTypeID", InventoryTypeID));
        }
        public List<DTO.Accounts.PurchaseOrdersForBillSubmit> getPOListNPBySupplierCodeInventoryTypeID(string SupplierCode, int InventoryTypeID)
        {
            return new InventoryGenericRepository<DTO.Accounts.PurchaseOrdersForBillSubmit>().FindUsingSP("getPurchaseOrdersForBillSubmitNP @SupplierCode, @InventoryTypeID", new SqlParameter("@SupplierCode", SupplierCode), new SqlParameter("@InventoryTypeID", InventoryTypeID));
        }

        public List<POBillSubmitNPDTO> getPOMaterialListNPByPoCode(string POCode)
        {
            return new InventoryGenericRepository<POBillSubmitNPDTO>().FindUsingSP("getPurchaseOrderMaterialsNP @POID", new SqlParameter("@POID", POCode));
        }

        public BillMaster saveBillMasterForNP(BillMaster billMaster)
        {
            return new InventoryGenericRepository<BillMaster>().Insert(billMaster);
        }

        public BillDetail saveBillDetailsForNP(BillDetail billDetail)
        {
            return new InventoryGenericRepository<BillDetail>().Insert(billDetail);
        }

        public BillMaster getBillMasterForNP(string billid)
        {
            return new InventoryGenericRepository<BillMaster>().Find(b => b.BillID == billid).FirstOrDefault();
        }

        public List<BillDetail> getBillDetailListForNP(string billid)
        {
            return new InventoryGenericRepository<BillDetail>().Find(b => b.BillID == billid).ToList();
        }

        public List<InventoryAccountReceivePendingListDto> accountReceiveBillPendingList(string EmployeeId)
        {
            return new InventoryGenericRepository<InventoryAccountReceivePendingListDto>().FindUsingSP("getInventoryAccountReceivePendingList @InventoryType, @SupplierCode", new SqlParameter("@InventoryType", "NON-PRODUCTION"), new SqlParameter("@SupplierCode", '0'));
        }

        public List<InventoryAdvancePaymentPendingListDto> getInventoryAdvancePaymentPendingList(string EmployeeId)
        {
            return new InventoryGenericRepository<InventoryAdvancePaymentPendingListDto>().FindUsingSP("getInventoryAdvancePaymentPendingList @EmployeeCode", new SqlParameter("@EmployeeCode", EmployeeId));
        }

        public List<BillForwardListDto> getBillForwardList()
        {
            var InventoryType = new SqlParameter("@InventoryType", "NON-PRODUCTION");
            return new InventoryGenericRepository<DTO.InventoryNonProduction.BillForwardListDto>().FindUsingSP("getBillsForwardPending @InventoryType", InventoryType);
        }

        public BillMaster saveBillForward(BillMaster billDetail)
        {
            return new InventoryGenericRepository<BillMaster>().Insert(billDetail);
        }
    }
}