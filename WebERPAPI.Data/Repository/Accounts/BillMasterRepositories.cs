using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Accounts;
using WebERPAPI.DTO.Inventory;
using WebERPAPI.DTO.Inventory.Requisitions;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.Accounts;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.DTO.Inventory.Purchase_Orders;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.Data.Repository.Inventory
{
    public class BillMasterRepositories
    {
        // TEST
        public Exception error = new Exception();

        public BillMaster getBillMaster(string BillID)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    return db.BillMasters.Where(b => b.BillID == BillID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<MasterBill> getBills(string SupplierID, Boolean BillStatus = false, string DateFrom = "", string DateTo = "", string BillCode = "0")
        {
            try
            {
                var billCode = new SqlParameter("@BillCode", BillCode);
                var supplierID = new SqlParameter("@SupplierID", SupplierID);
                var billstatus = new SqlParameter("@BillStatus", BillStatus);
                var dateFrom = new SqlParameter("@DateFrom", DateFrom);
                var dateTo = new SqlParameter("@DateTo", DateTo);

                using (InventoryEntities db = new InventoryEntities())
                {
                    //db.Configuration.LazyLoadingEnabled = false;
                    return db.Database.SqlQuery<MasterBill>("getMasterBills @BillCode, @SupplierID, @BillStatus, @DateFrom, @DateTo", billCode, supplierID, billstatus, dateFrom, dateTo).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<VoucherChequeDto> getBillVoucherCheque(string BillID)
        {
            try
            {
                var BIllID = new SqlParameter("@BILLID", BillID);
                using (InventoryEntities db = new InventoryEntities())
                {
                    //db.Configuration.LazyLoadingEnabled = false;
                    return db.Database.SqlQuery<VoucherChequeDto>("getBillCheckList @BILLID", BIllID).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<MasterBill> getBillsNotSettled(string SupplierID, string DateFrom = "", string DateTo = "")
        {
            try
            {
                var supplierID = new SqlParameter("@SupplierID", SupplierID);
                var dateFrom = new SqlParameter("@DateFrom", DateFrom);
                var dateTo = new SqlParameter("@DateTo", DateTo);

                using (InventoryEntities db = new InventoryEntities())
                {
                    //db.Configuration.LazyLoadingEnabled = false;
                    return db.Database.SqlQuery<MasterBill>("getMasterBillsNotSettled @SupplierID, @DateFrom, @DateTo", supplierID, dateFrom, dateTo).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
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
                error = ex;
                return null;
            }
        }

        public BillReportStatusDto getBillReportStatus(string BillCode)
        {
            try
            {
                var billCode = new SqlParameter("@BillCode", BillCode);

                using (InventoryEntities db = new InventoryEntities())
                {
                    return db.Database.SqlQuery<BillReportStatusDto>("getBillReportStatus @BillCode", billCode).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<SupplierMasterBills> getSupplierBills(string SupplierCode, int BillStatusID, string DateFrom = "", string DateTo = "")
        {
            try
            {
                var supplierCode = new SqlParameter("@SupplierCode", SupplierCode);
                var billstatusid = new SqlParameter("@BillStatusID", BillStatusID);
                var dateFrom = new SqlParameter("@DateFrom", DateFrom);
                var dateTo = new SqlParameter("@DateTo", DateTo);

                using (InventoryEntities db = new InventoryEntities())
                {
                    //db.Configuration.LazyLoadingEnabled = false;
                    return db.Database.SqlQuery<SupplierMasterBills>("getSupplierMasterBills @SupplierCode, @BillStatusID, @DateFrom, @DateTo", supplierCode, billstatusid, dateFrom, dateTo).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<MasterBill> getSettledBills(string SupplierCode, string DateFrom, string DateTo)
        {
            try
            {
                var supplierCode = new SqlParameter("@SupplierCode", SupplierCode);
                var dateFrom = new SqlParameter("@DateFrom", DateFrom);
                var dateTo = new SqlParameter("@DateTo", DateTo);

                using (InventoryEntities db = new InventoryEntities())
                {
                    return db.Database.SqlQuery<MasterBill>("getMasterSettledBills @SupplierCode, @DateFrom, @DateTo", supplierCode, dateFrom, dateTo).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

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
                error = ex;
                return null;
            }
        }

        public List<Bill_PaymentType> getBillPaymentTypeList()
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    return db.Bill_PaymentType.Where(p => p.IsActive == true).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public Boolean receieveAccountBill(ReceiveBill rbill)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    var bill = db.BillMasters.Where(b => b.BillID == rbill.BillId).FirstOrDefault();

                    bill.AccountsReceived = true;
                    bill.AccountsReceiveDate = DateTime.Now;
                    bill.AccountsReceiveBy = rbill.AccountsReceiveBy;
                    bill.AccountsRemarks = rbill.AccountsRemarks;

                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public Boolean savePaymentDetails(BillPaymentDetails payment)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    Bill_Payment_Details pay = new Bill_Payment_Details();

                    pay.BillID = payment.BillID;
                    pay.PaymentDate = payment.PaymentDate;
                    pay.PaymentTypeId = payment.PaymentTypeId;
                    pay.PaymentStatusId = payment.PaymentStatusId;
                    pay.CheckNo = payment.CheckNo;
                    pay.BankID = payment.BankID;
                    pay.BankBranchName = payment.BankBranchName;
                    pay.PaymentBy = payment.PaymentBy;
                    pay.PaymentAmount = payment.PaymentAmount;
                    pay.Remarks = payment.Remarks;
                    pay.CreatedOn = DateTime.Now;

                    db.Bill_Payment_Details.Add(pay);

                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public List<BankInfo> getBankList()
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    return db.BankInfoes.Where(b => b.IsActive == true).OrderBy(b => b.BankName).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public Boolean setBillSettle(SettleBill bill)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    BillMaster bm = db.BillMasters.Where(b => b.BillID == bill.BillId).FirstOrDefault();
                    if (bm != null)
                    {
                        bm.BillSettleRemarks = bill.Remarks;
                        bm.BillSettledOn = DateTime.Now;
                        bm.BillSettledBy = bill.EmployeeID;
                        bm.IsBillSettled = true;

                        db.SaveChanges();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public Boolean setBillUnsettle(SettleBill bill)
        {
            using (InventoryEntities db = new InventoryEntities())
            {
                BillMaster bm = db.BillMasters.Where(b => b.BillID == bill.BillId).FirstOrDefault();
                if (bm != null)
                {
                    bm.BillSettleRemarks = "Bill unsettled by " + bill.EmployeeID;
                    bm.BillSettledOn = null;
                    bm.BillSettledBy = null;
                    bm.IsBillSettled = false;

                    db.SaveChanges();
                }
            }

            return true;
        }

        public List<MasterBillPaymentDetailsReport> getBillPaymentDetailsList(string BillId)
        {
            try
            {
                var billid = new SqlParameter("@BillID", BillId);

                using (InventoryEntities db = new InventoryEntities())
                {
                    return db.Database.SqlQuery<MasterBillPaymentDetailsReport>("getMasterBillPaymentDetails @BillID", billid).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<ServiceBillDetails> getServiceBillDetails(string BillId)
        {
            try
            {
                var billid = new SqlParameter("@BillID", BillId);

                using (InventoryEntities db = new InventoryEntities())
                {
                    return db.Database.SqlQuery<ServiceBillDetails>("getServiceBillDetails @BillID", billid).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<Bill_GroupType> getBillGroupList()
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    return db.Bill_GroupType.ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<PurchageOrderPending> getPurchageOrderPendingList(string BillGroupType)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    var billGroupType = new SqlParameter("@BillGroupType", BillGroupType);
                    return db.Database.SqlQuery<PurchageOrderPending>("getPurchageOrderForAdvanceRequisition @BillGroupType", billGroupType).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public Boolean saveBillPaymentAdvance(BillPaymentAdvance billpaymentadvance)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    Bill_Payment_Advance Advance = new Bill_Payment_Advance();

                    //Advance.AdvancePaymentCode = billpaymentadvance.AdvancePaymentCode;
                    Advance.POID = billpaymentadvance.POID;
                    Advance.BillGroupTypeID = billpaymentadvance.BillGroupTypeID;
                    Advance.SupplierID = billpaymentadvance.SupplierID;
                    Advance.POAmount = billpaymentadvance.POAmount;
                    Advance.AdvancePercent = billpaymentadvance.AdvancePercent;
                    Advance.AdvancePaymentAmount = billpaymentadvance.AdvancePaymentAmount;
                    Advance.IsReceivedFromAccounts = false;
                    Advance.IsUrgent = billpaymentadvance.IsUrgent;
                    Advance.Remarks = billpaymentadvance.Remarks;
                    Advance.CreatedOn = DateTime.Now;
                    Advance.CreatedByID = billpaymentadvance.EmployeeID;

                    db.Bill_Payment_Advance.Add(Advance);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public List<AdvanceRequisition> getAdvanceRequisition(string BillGroupName, int IsReceivedFromAccounts)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    var billGroupName = new SqlParameter("@BillGroupType", BillGroupName);
                    var isReceivedFromAccounts = new SqlParameter("@IsReceivedFromAccounts", IsReceivedFromAccounts);

                    return db.Database.SqlQuery<AdvanceRequisition>("getAdvanceRequisition @BillGroupType, @IsReceivedFromAccounts", billGroupName, isReceivedFromAccounts).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<SupplierAdvanceRequisitionHistory> getSupplierAdvancePaymentHistory(string BillGroupName, string SupplierID)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    var billGroupName = new SqlParameter("@BillGroupType", BillGroupName);
                    var supplierID = new SqlParameter("@SupplierID", SupplierID);
                    return db.Database.SqlQuery<SupplierAdvanceRequisitionHistory>("getSupplierAdvanceRequisitionHistory @BillGroupType, @SupplierID", billGroupName, supplierID).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<AdvanceRequisition> getAdvanceRequisitionApproval(string BillGroupName, int IsReceivedFromAccounts)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    var billGroupName = new SqlParameter("@BillGroupType", BillGroupName);
                    var isReceivedFromAccounts = new SqlParameter("@IsReceivedFromAccounts", IsReceivedFromAccounts);

                    return db.Database.SqlQuery<AdvanceRequisition>("getAdvanceRequisitionForApproval @BillGroupType, @IsReceivedFromAccounts", billGroupName, isReceivedFromAccounts).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public Boolean saveBillPaymentAdvanceApproval(AdvanceRequisitionApproval Approval)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    Bill_Payment_Advance adv = db.Bill_Payment_Advance.Where(b => b.POID == Approval.POID).FirstOrDefault();

                    if (adv != null)
                    {
                        adv.IsReceivedFromAccounts = true;
                        adv.ApprovalRemarks = Approval.ApprovalRemarks;
                        adv.ApprovedBy = Approval.ApprovedBy;
                        adv.ApprovedOn = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }

                    if (adv == null) // for checking non production advance
                    {
                        Inventory_Purchase_Order_AdvancePaid NonProdcutionAdv = new NonProductionGenericRepository<Inventory_Purchase_Order_AdvancePaid>().Find(b => b.POID == Approval.POID).FirstOrDefault();

                        if (NonProdcutionAdv != null)
                        {
                            NonProdcutionAdv.IsReceivedFromAccounts = true;
                            NonProdcutionAdv.ApprovedById = Approval.ApprovedBy;
                            NonProdcutionAdv.ApprovedOn = DateTime.Now;
                            NonProdcutionAdv.ApprovalRemarks = Approval.ApprovalRemarks;
                            new NonProductionGenericRepository<Inventory_Purchase_Order_AdvancePaid>().Update(NonProdcutionAdv, i => i.ID == NonProdcutionAdv.ID);
                            return true;
                        }
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public List<RequisitionPOGRNSummary> getRequisitionPOGRNSummaryList()
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    return db.Database.SqlQuery<RequisitionPOGRNSummary>("getRequisitionPOGRNSummary").ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<SupplierPendingMasterBillReport> getSupplierPendingMasterBillTotal(string DateFrom, string DateTo)
        {
            try
            {
                List<SupplierPendingMasterBillReport> report = new List<SupplierPendingMasterBillReport>();

                using (InventoryEntities db = new InventoryEntities())
                {
                    var dateFrom = new SqlParameter("@DateFrom", DateFrom);
                    var dateTo = new SqlParameter("@DateTo", DateTo);

                    var bills = db.Database.SqlQuery<SupplierPendingMasterBillTotal>("getSupplierPendingMasterBillTotal @DateFrom, @DateTo", dateFrom, dateTo).ToList();

                    foreach (SupplierPendingMasterBillTotal bill in bills)
                    {
                        SupplierPendingMasterBillReport rpt = new SupplierPendingMasterBillReport();

                        rpt.SupplierID = bill.SupplierID;
                        rpt.SupplierName = bill.SupplierName;
                        rpt.TotalBillAmount = bill.TotalBillAmount;
                        rpt.TotalPaid = bill.TotalPaid;
                        rpt.TotalDue = bill.TotalDue;

                        rpt.BillDetails = new List<SupplierMasterBills>();

                        var billDetails = getSupplierBills(bill.SupplierID, 0, DateFrom, DateTo);
                        rpt.BillDetails.AddRange(billDetails);

                        report.Add(rpt);
                    }

                    return report;
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

       

        public List<BillAmountDetails> getBillAmountDetails(string BillCode)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    var billCode = new SqlParameter("@BillCode", BillCode);
                    return db.Database.SqlQuery<BillAmountDetails>("getBillAmountDetails @BillCode", billCode).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public string getBillCode()
        {
            try
            {
                string newCode = string.Empty;
                string BillCode = "BM" + DateTime.Now.Month.ToString("D2") + DateTime.Now.Year.ToString().Substring(2);
                //DateTime monthFirstDate = DateTime.Now.AddDays(-(DateTime.Now.Day - 1));
                DateTime monthFirstDate = DateTime.Now.AddDays(-(DateTime.Now.Day - 1)).Date;

                using (InventoryEntities db = new InventoryEntities())
                {
                    var bill = db.BillMasters.Where(b => b.DateAdded >= monthFirstDate).OrderByDescending(b => b.DateAdded).FirstOrDefault();
                    string billCode = "0001";
                    if (bill != null) billCode = bill.BillID;

                    for (int i = 1; i <= 20; i++)
                    {
                        int IncrementNumber = Scripting.valueInt(billCode.Substring(billCode.Length - 4)) + i;
                        newCode = BillCode + (IncrementNumber).ToString("D4");
                        var IsExistBill = db.BillMasters.Where(b => b.BillID == newCode).FirstOrDefault();

                        if (IsExistBill == null) return newCode;
                    }
                    return newCode;
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return "";
            }
        }

        public List<BillSuppliers> getBillSuppliers(int IsPendingBill)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    var isPendingBill = new SqlParameter("@IsPendingBill", IsPendingBill);
                    return db.Database.SqlQuery<BillSuppliers>("getBillSuppliers @IsPendingBill", isPendingBill).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<Currency> getCurrencies()
        {
            try
            {
                using (SCMEntities db = new SCMEntities())
                {
                    return db.Currencies.Where(c => c.IsActive == true).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

       
        public List<BillsByUser> getBillsByUser(string EmployeeID, string SupplierID)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    var employeeID = new SqlParameter("@EmployeeID", EmployeeID);
                    var supplierID = new SqlParameter("@SupplierID", SupplierID);
                    return db.Database.SqlQuery<BillsByUser>("getBillsByUser @EmployeeID, @SupplierID", employeeID, supplierID).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<Bill_PaymentType> getBillPaymentTypes()
        {
            using (InventoryEntities db = new InventoryEntities())
            {
                return db.Bill_PaymentType.Where(q => q.IsActive == true).ToList();
            }
        }

        public string saveBillNew(BillNew newBill, List<BillNewDetails> billDetails)
        {
            try
            {
                string BillCode = getBillCode();

                if (string.IsNullOrEmpty(BillCode)) return "";

                // Save Bill Master
                using (InventoryEntities db = new InventoryEntities())
                {
                    BillMaster bill = new BillMaster();

                    bill.BillID = BillCode;
                    bill.BillDate = newBill.BillDate.GetValueOrDefault();

                    bill.BillGroup = newBill.BillGroup;
                    bill.BillDescription = newBill.BillDescription;
                    bill.SubmittedBy = newBill.SubmittedBy;
                    bill.SupplierID = newBill.SupplierID;
                    bill.SupplierBillNo = newBill.SupplierBillNo;
                    bill.SBillDate = newBill.SupplierBillDate;
                    bill.Remarks = newBill.Remarks;

                    bill.AccountsReceived = false;

                    bill.CarryingCharge = newBill.CarryingCharge.GetValueOrDefault();
                    bill.LoadingCharge = newBill.LoadingCharge.GetValueOrDefault();
                    bill.OtherCharge = newBill.OtherCharge.GetValueOrDefault();
                    bill.AdvancePaid = newBill.AdvancePaid.GetValueOrDefault();
                    bill.Discount = newBill.Discount.GetValueOrDefault();

                    bill.DateAdded = DateTime.Now;
                    bill.AddedBy = newBill.SubmittedBy;

                    bill.Transferred = false;
                    bill.HOTransferred = false;
                    bill.Location = "MIS Bill Submit";
                    bill.MachineNameIP = "MIS";
                    bill.IsForwarded = false;
                    db.BillMasters.Add(bill);

                    db.SaveChanges();

                    // Saving BIll Details

                    string vatChallanNo = "", challanNo = "";

                    foreach (BillNewDetails bd in billDetails)
                    {
                        BillDetail details = new BillDetail();

                        details.BillID = BillCode;
                        details.SLNo = bd.SLNo.GetValueOrDefault();
                        details.ChallanID = bd.ChallanID;

                        details.BillQty = bd.Quantity.GetValueOrDefault();
                        details.BillAmount = Math.Ceiling(bd.BillAmount.GetValueOrDefault());
                        details.Rate = bd.Rate.GetValueOrDefault();
                        details.POID = bd.POID;
                        details.ItemID = bd.MaterialCode;
                        details.GRNID = bd.GRNID;

                        // Unique challan vat entry
                        if (!string.IsNullOrEmpty(bd.ChallanID))
                        {
                            challanNo = bd.ChallanID;
                            if (vatChallanNo.IndexOf("<" + challanNo + ">") == -1)
                            {
                                vatChallanNo += "<" + challanNo + ">";
                                details.VatAmt = bd.VatAmt.GetValueOrDefault();
                            }
                        }

                        //details.VatAmt = bd.VatAmt.GetValueOrDefault();
                        details.AITAmt = 0;

                        details.DateAdded = DateTime.Now;
                        details.AddedBy = newBill.SubmittedBy;

                        db.BillDetails.Add(details);
                        db.SaveChanges();
                    }
                }

                return BillCode;
            }
            catch (Exception ex)
            {
                error = ex;
                return "";
            }
        }

        //production
        public List<DTO.InventoryNonProduction.BillForwardListDto> getBillForwardList()
        {
            var InventoryType = new SqlParameter("@InventoryType", "PRODUCTION");
            return new InventoryGenericRepository<DTO.InventoryNonProduction.BillForwardListDto>().FindUsingSP("getBillsForwardPending @InventoryType", InventoryType);
        }

        public List<SupplierListForBillForwardDto> supplierListforBillForward(string EmployeeId)
        {
            var EmployeeCode = new SqlParameter("@EmployeeCode", EmployeeId);
            var InventoryType = new SqlParameter("@InventoryType", "PRODUCTION");
            return new InventoryGenericRepository<SupplierListForBillForwardDto>().FindUsingSP("getSupplierListForBill EmployeeCode,@InventoryType", EmployeeCode, InventoryType);
        }

        public List<InventoryAccountReceivePendingListDto> getBillForwardedList(string SupplierCode)
        {
            return new InventoryGenericRepository<InventoryAccountReceivePendingListDto>().FindUsingSP("getInventoryAccountReceivePendingList @InventoryType, @SupplierCode, @IsAccountReceive", new SqlParameter("@InventoryType", "PRODUCTION"), new SqlParameter("@SupplierCode", SupplierCode), new SqlParameter("@IsAccountReceive", false));
        }

        public List<InventoryAccountReceivePendingListDto> getBillStatusList()
        {
            return new InventoryGenericRepository<InventoryAccountReceivePendingListDto>().FindUsingSP("getInventoryAccountReceivePendingList @InventoryType, @SupplierCode, @IsAccountReceive", new SqlParameter("@InventoryType", "PRODUCTION"), new SqlParameter("@SupplierCode", "0"), new SqlParameter("@IsAccountReceive", true));
        }

        public BillMaster saveBillForward(BillMaster billDetail)
        {
            return new InventoryGenericRepository<BillMaster>().Insert(billDetail);
        }

        public List<POBillPaymentStatusDto> getPurchaseOrderBillPaymentStatus(string SupplierCode,string CurrentTab, DateTime? recentlyPaidDate)
        {
            var Supplier = new SqlParameter("@SupplierCode", SupplierCode);
            var TabName = new SqlParameter("@BillType", CurrentTab);
            var recentlyPaid = new SqlParameter("@RecentyPaidFromDate", recentlyPaidDate);

            return new InventoryGenericRepository<POBillPaymentStatusDto>().FindUsingSP("getPurchaseOrderBillPaymentStatus @SupplierCode,@BillType,@RecentyPaidFromDate", Supplier, TabName, recentlyPaid);
        }

        public List<PurchaseOrderBillListDto> getPurchaseOrderBillList(string POID)
        {
            var PO = new SqlParameter("@POID", POID);
            return new InventoryGenericRepository<PurchaseOrderBillListDto>().FindUsingSP("getPurchaseOrderBillList @POID", PO);
        }

        public BillMaster updateBillMaster(BillMaster bill)
        {
            return new InventoryGenericRepository<BillMaster>().Update(bill, i => i.BillID == bill.BillID);
        }

        public List<Inventory_Purchase_Order_AdvancePaid> getNonProductionPoAdvs(string po)
        {
            return new NonProductionGenericRepository<Inventory_Purchase_Order_AdvancePaid>().Find(i => i.POID == po && i.IsCanceled != true).ToList();
        }

        public Inventory_Purchase_Order_AdvancePaid updateNonProductionPoAdvs(Inventory_Purchase_Order_AdvancePaid poadv)
        {
            return new NonProductionGenericRepository<Inventory_Purchase_Order_AdvancePaid>().Update(poadv, i => i.ID == poadv.ID);
        }
        public string saveBillsubmitService(BillMaster billMaster)
        {
           
            
            BillMaster newbill = new InventoryGenericRepository<BillMaster>().Insert(billMaster);

            //foreach(var item in billMaster.BillDists)
            //{
            //    item.BillMaster = null;
            //    BillDist newbilldetails = new InventoryGenericRepository<BillDist>().Insert(item);

            //}


            return newbill.BillID;
        }
    }
}