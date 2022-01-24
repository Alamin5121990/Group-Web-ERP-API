using System;
using System.Collections.Generic;
using WebERPAPI.DTO.Accounts;
using WebERPAPI.Data;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.Inventory;
using WebERPAPI.DTO.Inventory;
using WebERPAPI.DTO;
using System.Linq;
using WebERPAPI.DTO.Inventory.Purchase_Orders;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.BusinessLogic.Inventory
{
    public class BillService
    {
        public Exception Error = new Exception();

        private BillMasterRepositories repo = new BillMasterRepositories();
        private SupplierRepositories sRepo = new SupplierRepositories();

        public object getBillReport(string BillCode)
        {
            try
            {
                var Bill = repo.getBill(BillCode);
                var Supplier = sRepo.getSupplierDetails(Bill.SupplierID);

                var BillDetails = repo.getBillDetails(BillCode);

                return new { Bill, Supplier, BillDetails };
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public BillReportStatusDto getBillReportStatus(string BillCode)
        {
            try
            {
                return repo.getBillReportStatus(BillCode);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<BillsByUser> getBillsByUser(string EmployeeID, string SupplierID)
        {
            return repo.getBillsByUser(EmployeeID, SupplierID);
        }

        public List<Bill_PaymentType> getBillPaymentTypes()
        {
            try
            {
                return repo.getBillPaymentTypes();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Boolean setBillUnsettle(SettleBill bill)
        {
            try
            {
                return repo.setBillUnsettle(bill);
            }
            catch (Exception ex)
            {
                Error = ex;
                return false;
            }
        }

        public List<BillForwardListMasterDto> getBillForwardList()
        {
            try
            {
                var BillList = repo.getBillForwardList();
                List<BillForwardListMasterDto> BillMasterList = new List<BillForwardListMasterDto>();

                foreach (var item in BillList)
                {
                    if (BillMasterList.Any(b => b.SupplierID == item.SupplierID))
                    {
                        var MasterItem = BillMasterList.Find(m => m.SupplierID == item.SupplierID);
                        MasterItem.bills.Add(item);
                    }
                    else
                    {
                        var newMaster = new BillForwardListMasterDto { SupplierID = item.SupplierID, SupplierName = item.SupplierName };
                        newMaster.bills.Add(item);

                        BillMasterList.Add(newMaster);
                    }
                }

                return BillMasterList;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<SupplierListForBillForwardDto> supplierListforBillForward(string employeeId)
        {
            try
            {
                return repo.supplierListforBillForward(employeeId);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<InventoryBillForwardedListMasterDto> getBillForwardedList(string SupplierCode)
        {
            try
            {
                //master dto
                List<InventoryBillForwardedListMasterDto> BillForwaredList = new List<InventoryBillForwardedListMasterDto>();
                //getting list of bills
                List<InventoryAccountReceivePendingListDto> BillList = repo.getBillForwardedList(SupplierCode);

                InventoryBillForwardedListMasterDto supplierBill = new InventoryBillForwardedListMasterDto();

                foreach (var item in BillList)
                {
                    if (!SupplierInForwaredList(BillForwaredList, item.SupplierID))
                    {
                        supplierBill.SupplierID = item.SupplierID;
                        supplierBill.SupplierName = item.SupplierName;
                        supplierBill.Bills.Add(item);
                        BillForwaredList.Add(supplierBill);
                        supplierBill = new InventoryBillForwardedListMasterDto();
                        continue;
                    }
                    else
                    {
                        foreach (var bill in BillForwaredList)
                        {
                            if (bill.SupplierID == item.SupplierID)
                            {
                                bill.Bills.Add(item);
                                break;
                            }
                        }
                    }
                }

                return BillForwaredList.OrderBy(s => s.SupplierName).ToList();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<InventoryAccountReceivePendingListDto> getBillStatusList()
        {
            try
            {
                return repo.getBillStatusList();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        private bool SupplierInForwaredList(List<InventoryBillForwardedListMasterDto> BillForwaredList, string supplierid)
        {
            foreach (var item in BillForwaredList) if (item.SupplierID == supplierid) return true;

            return false;
        }

        public Boolean forwardBillNP(CommonDataEntryClass BillDetails)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    var bill = db.BillMasters.FirstOrDefault(b => b.BillID == BillDetails.Code);
                    if (bill != null)
                    {
                        bill.IsForwarded = true;
                        bill.ForwardByID = BillDetails.EmployeeCode;
                        bill.ForwardOn = DateTime.Now; ;
                        bill.ForwardRemarks = BillDetails.Remarks;
                        repo.saveBillForward(bill);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Error = ex;
                return false;
            }
        }

        public List<POBillPaymentStatusDto> getPurchaseOrderBillPaymentStatus(string SupplierCode,string CurrentTab, DateTime? recentlyPaidDate)
        {
            try
            {
                return repo.getPurchaseOrderBillPaymentStatus(SupplierCode, CurrentTab, recentlyPaidDate);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<PurchaseOrderBillListDto> getPurchaseOrderBillList(string POID)
        {
            try
            {
                return repo.getPurchaseOrderBillList(POID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        //bill cancel

        public BillMaster cancelBill(string billid, string remark, int empid)
        {
            try
            {
                //logic to cancel dependents
                BillMaster bill = repo.getBillMaster(billid);
                if (bill == null)
                {
                    throw new Exception("Bill not found.");
                }

                bill.IsCanceled = true;
                bill.CanceledByID = empid;
                bill.CanceledOn = DateTime.Now;
                bill.ReasonToCancel = remark;
                return repo.updateBillMaster(bill);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public bool RollBackNonproductionPOAdvance(string POID, string EmpID, string Remarks)
        {
            try
            {
                int count = 0;
                var AdvanceList = repo.getNonProductionPoAdvs(POID);

                foreach (var item in AdvanceList)
                {
                    item.IsReceivedFromAccounts = null;
                    item.RollBackById = EmpID;
                    item.RollBackOn = DateTime.Now;
                    item.RollBackRemarks = Remarks;

                    repo.updateNonProductionPoAdvs(item);
                    count++;
                }

                if (AdvanceList.Count == 0) throw new Exception("Advance payment not found for " + POID);

                if (count == AdvanceList.Count)
                    return true;
                else throw new Exception("Unable to roll back all advance payment.");
            }
            catch (Exception ex)
            {
                Error = ex;
                return false;
            }
        }
        public string saveBillsubmitService(BillMaster billMaster)
        {
            string BillCode = repo.getBillCode();

            if (string.IsNullOrEmpty(BillCode)) return "";
            billMaster.BillID = BillCode;

            int count = 0;
            foreach (var item in billMaster.BillDists)
            {
                count++;
                item.BillID = BillCode;
                item.ServiceID = " ";
                item.SLNo = count;

            }
            BillCode = repo.saveBillsubmitService(billMaster);

          
            return BillCode;
        }
    }
}