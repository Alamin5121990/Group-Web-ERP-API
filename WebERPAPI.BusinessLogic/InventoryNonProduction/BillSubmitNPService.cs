using System;
using System.Collections.Generic;
using System.Linq;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.Inventory;
using WebERPAPI.Data.Repository.InventoryNonProduction;
using WebERPAPI.DTO;
using WebERPAPI.DTO.InventoryNonProduction;
using WebERPAPI.DTO.Supplier;
using WebERPAPI.Library;

namespace WebERPAPI.BusinessLogic.InventoryNonProduction
{
    public class BillSubmitNPService
    {
        public Exception Error = new Exception();

        public BillSubmitNPRepositories repo = new BillSubmitNPRepositories();

        public List<SupplierBasicDto> getSupplierListByInventoryTypeId(int InventoryTypeID)
        {
            try
            {
                return repo.getSupplierListByInventoryType(InventoryTypeID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<POBillSubmitNPDTO> getPOMaterialListNPByPoCode(string POCode)
        {
            try
            {
                return repo.getPOMaterialListNPByPoCode(POCode);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public object getBillReport(string BillCode)
        {
            try
            {
                var Bill = repo.getBill(BillCode);
                var Supplier = new SupplierRepositories().getSupplierDetails(Bill.SupplierID);

                var BillDetails = repo.getBillDetails(BillCode);

                return new { Bill, Supplier, BillDetails };
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }
        public BillMaster saveBillForNP(POBillSubmitMasterNPDTO billDTO)
        {
            try
            {
                //create master and insert
                BillMaster billMaster = new BillMaster();
                BillMasterRepositories billrepo = new BillMasterRepositories();

                billMaster.BillID = billrepo.getBillCode();
                billMaster.BillDate = Convert.ToDateTime(billDTO.BillDate);
                billMaster.SubmittedBy = billDTO.SubmittedBy;
                billMaster.BillGroup = "Non Production Items";
                billMaster.BillGroupID = 6;
                billMaster.SupplierID = billDTO.SupplierCode;
                billMaster.SupplierBillNo = billDTO.SupplierBillNo;
                billMaster.SBillDate = billDTO.SupplierBillDate;
                billMaster.BillDescription = "";
                billMaster.Remarks = "";
                billMaster.AccountsReceived = false;
                billMaster.CarryingCharge = billDTO.CarryingCharge;
                billMaster.LoadingCharge = billDTO.LoadingCharge;
                billMaster.OtherCharge = billDTO.OtherCharge;
                billMaster.AdvancePaid = billDTO.SupplierAdvance;
                billMaster.Discount = billDTO.Discount;
                billMaster.Location = "HO";
                billMaster.AddedBy = billDTO.AddedBy;
                billMaster.DateAdded = billDTO.DateAdded;
                billMaster.MachineNameIP = "";
                billMaster.Remarks = billDTO.Remarks;
                repo.saveBillMasterForNP(billMaster);

                // GET BILL
                BillMaster billMasterResult = repo.getBillMasterForNP(billMaster.BillID);
                if (billMasterResult == null)
                {
                    Error = new Exception("Master not insert.");
                    return null;
                }

                int slCounter = 1;
                foreach (var item in billDTO.MaterialList)
                {
                    BillDetail billDetail = new BillDetail();

                    billDetail.BillID = billMasterResult.BillID;
                    billDetail.ChallanID = item.ChallanNumber;
                    billDetail.SLNo = slCounter;
                    slCounter++;
                    billDetail.POID = item.POCode;
                    billDetail.GRNID = item.GRNCode;
                    billDetail.ItemID = item.ItemID.ToString();
                    billDetail.BillQty = item.ReceivedQty;
                    billDetail.Rate = item.Rate;
                    billDetail.VatAmt = item.ItemVATAmount;
                    billDetail.BillAmount = item.ItemAmount;
                    billDetail.AITAmt = 0;
                    billDetail.AddedBy = billMasterResult.AddedBy;
                    billDetail.DateAdded = billMasterResult.DateAdded;

                    // SAVE BILL DETAILS
                    repo.saveBillDetailsForNP(billDetail);
                }

                // GET BILL
                billMaster.BillDetails = repo.getBillDetailListForNP(billMaster.BillID);
                return billMaster;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<DTO.Accounts.PurchaseOrdersForBillSubmit> getPOListNPBySupplierCodeInventoryTypeID(string SupplierCode, int InventoryTypeID)
        {
            try
            {
                return repo.getPOListNPBySupplierCodeInventoryTypeID(SupplierCode, InventoryTypeID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<BillForwardListDto> getBillForwardList()
        {
            try
            {
                return repo.getBillForwardList();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
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
                        bill.ForwardOn = DateTime.Now;
                        bill.ForwardRemarks = BillDetails.Remarks;
                        db.SaveChanges();
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

        public Boolean multipleBillForward(CommonDataEntryClass BillList)
        {
            try
            {
                int count = 0;

                List<BillForwardListDto> bills = JSONSerialize.getJSON<BillForwardListDto>(BillList.Data);

                if (bills == null || bills.Count <= 0)
                {
                    Error = new Exception("Failed to save Item Receive. No Item Receive details found. Please try again." + JSONSerialize.ErrorMessage);
                    return false;
                }

                using (InventoryEntities db = new InventoryEntities())
                {
                    foreach (var item in bills)
                    {
                        var bill = db.BillMasters.FirstOrDefault(b => b.BillID == item.BillID);
                        if (bill != null)
                        {
                            bill.IsForwarded = true;
                            bill.ForwardByID = BillList.EmployeeCode;
                            bill.ForwardOn = DateTime.Now;
                            bill.ForwardRemarks = BillList.Remarks;
                            db.SaveChanges();

                            count++;
                        }
                    }
                }

                if (count == bills.Count) return true;

                return false;
            }
            catch (Exception ex)
            {
                Error = ex;
                return false;
            }
        }

        public List<InventoryAdvancePaymentPendingListDto> getInventoryAdvancePaymentPendingList(string employeeId)
        {
            try
            {
                return repo.getInventoryAdvancePaymentPendingList(employeeId);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<InventoryAccountReceivePendingListDto> accountReceiveBillPendingList(string employeeId)
        {
            try
            {
                return repo.accountReceiveBillPendingList(employeeId);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }
    }
}