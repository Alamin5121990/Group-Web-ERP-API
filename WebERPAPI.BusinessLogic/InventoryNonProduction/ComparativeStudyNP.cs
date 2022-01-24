using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebERPAPI.BusinessLogic.Interfaces;
using WebERPAPI.BusinessLogic.Inventory;
using WebERPAPI.BusinessLogic.Map;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.InventoryNonProduction;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.DTO.Inventory.Procurement.CS;
using WebERPAPI.DTO.Inventory.Procurement.Quotation;
using WebERPAPI.DTO.InventoryNonProduction;
using WebERPAPI.Library;

namespace WebERPAPI.BusinessLogic.InventoryNonProduction
{
    public class ComparativeStudyNP : IComparativeStudyNP
    {
        public Exception Error = new Exception();
        private ComparativeStudyNPRepositories repo = new ComparativeStudyNPRepositories();
        private RequisitionNPRepositories invRepo = new RequisitionNPRepositories();

        private QuotationNPRepositories qRepo = new QuotationNPRepositories();
        private InventorySettings invService = new InventorySettings();
        private QuotationNP quotService = new QuotationNP();

        public bool ManagementApproval(string ItemType, string employeeid, string referenceCode)
        {
            try
            {
                if (ItemType == "CSLOCAL")
                {
                    Comparative_Study item = new InventoryGenericRepository<Comparative_Study>().Find(c => c.CSCode == referenceCode).FirstOrDefault();

                    if (item != null)
                    {
                        //item.IsManagementApproved = true;
                        //item.ManagementApprovedOn = DateTime.Now;
                       // item.ManagementApprovedById = employeeid;

                        var result = new InventoryGenericRepository<Comparative_Study>().Update(item, c => c.ID == item.ID);
                        List<Comparative_Study_Details> detailList = new InventoryGenericRepository<Comparative_Study_Details>().Find(c => c.CSID == item.ID).ToList();

                        foreach (var csDetail in detailList)
                        {
                            csDetail.IsManagementApproved = true;
                            csDetail.ManagementApprovedOn = DateTime.Now;
                            csDetail.ManagementApprovedById = employeeid;

                            new InventoryGenericRepository<Comparative_Study_Details>().Update(csDetail, c => c.ID == csDetail.ID);
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (ItemType == "CSIMPORT")
                {
                    Comparative_Study_Import item = new InventoryGenericRepository<Comparative_Study_Import>().Find(c => c.CSCode == referenceCode).FirstOrDefault();

                    if (item != null)
                    {
                        //item.IsManagementApproved = true;
                        //item.ManagementApprovedOn = DateTime.Now;
                        //item.ManagementApprovedById = employeeid;

                        new InventoryGenericRepository<Comparative_Study_Import>().Update(item, c => c.ID == item.ID);

                        List<Comparative_Study_Import_Details> detailList = new InventoryGenericRepository<Comparative_Study_Import_Details>().Find(c => c.CSID == item.ID).ToList();

                        foreach (var csDetail in detailList)
                        {
                            csDetail.IsManagementApproved = true;
                            csDetail.ManagementApprovedOn = DateTime.Now;
                            csDetail.ManagementApprovedById = employeeid;

                            new InventoryGenericRepository<Comparative_Study_Import_Details>().Update(csDetail, c => c.ID == csDetail.ID);
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (ItemType == "CSNONPRODUCTION")
                {
                    Inventory_Comparative_Study item = new NonProductionGenericRepository<Inventory_Comparative_Study>().Find(c => c.CSCode == referenceCode).FirstOrDefault();

                    if (item != null)
                    {
                        item.IsManagementApproved = true;
                        item.ManagementApprovedOn = DateTime.Now;
                        item.ManagementApprovedById = employeeid;

                        new NonProductionGenericRepository<Inventory_Comparative_Study>().Update(item, c => c.ID == item.ID);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex) { Error = ex; return false; }
        }

        public Inventory_Comparative_Study saveComparativeStudy(CommonDataEntryClass Data)
        {
            try
            {
                // CS Validation
                string reqValidation = checkComparativeStudy(Data);
                if (!string.IsNullOrEmpty(reqValidation))
                {
                    Error = new Exception("Failed to save comparative study. " + reqValidation);
                    return null;
                }

                int numberOfSuccess = 0;
                int RequisitionID = 0;

                Inventory_Comparative_Study CSData = new ComparativeStudyNPMap().map(Data);
                List<ComparativeStudyDetailsNew> csItems = JSONSerialize.getJSON<ComparativeStudyDetailsNew>(Data.Data);

                try
                {
                    List<QuotationSuppliersNP> supplierOtherCost = JSONSerialize.getJSON<QuotationSuppliersNP>(Data.Code);

                    foreach (var item in supplierOtherCost)
                    {
                        Inventory_Quotation_Received_OtherCost existOtherCost = new QuotationNPRepositories().getOtherCost(Convert.ToInt32(item.QuotationID), item.SupplierCode);

                        if (existOtherCost == null)
                        {
                            existOtherCost = new Inventory_Quotation_Received_OtherCost();
                            existOtherCost.IsActive = true;
                            existOtherCost.QuotationID = Convert.ToInt32(item.QuotationID);
                            existOtherCost.SupplierCode = item.SupplierCode;
                            existOtherCost.OtherCost = item.OtherCost;
                            existOtherCost.OtherCostName = item.OtherCostName;
                            existOtherCost.Discount = item.Discount;
                        }

                        existOtherCost.LabourCost = item.LabourCost;
                        existOtherCost.CarryingCost = item.CarryingCost;
                        existOtherCost.CreatedOn = DateTime.Now;
                        existOtherCost.OtherCostName = item.OtherCostName;
                        existOtherCost.OtherCost = item.OtherCost;
                        existOtherCost.Discount = item.Discount;

                        new QuotationNPRepositories().updateOtherCost(existOtherCost);
                    }
                }
                catch (Exception e)
                {
                }

                // Checking CS details
                if (csItems == null || csItems.Count <= 0)
                {
                    Error = new Exception("Failed to save comparative study . No comparative study details found. Please try again." + JSONSerialize.ErrorMessage);
                    return null;
                }

                List<Inventory_Comparative_Study_Details> CSItems = new ComparativeStudyNPMap().map(csItems);

                // CS Item Validation
                string detailValidation = checkComparativeStudyDetails(csItems, true);
                if (!string.IsNullOrEmpty(detailValidation))
                {
                    Error = new Exception("Failed to save comparative study . " + detailValidation);
                    return null;
                }

                RequisitionID = csItems[0].RequisitionID;

                // SAVE

                Inventory_Comparative_Study newCS = repo.getExistingComparativeStudy(RequisitionID);

                if (newCS == null) newCS = repo.saveComparativeStudy(CSData);
                else repo.updateComparativeStudy(CSData.ID, CSData);

                // Checking the existing CS
                if (newCS == null)
                {
                    Error = new Exception("Failed to save comparative study. Please try again.");
                    return null;
                }

                // Cancel all Existing CS Details
                repo.cancelAllExistingCSDetails(newCS.ID, CSData.CreatedByID);

                // Save CS Details

                foreach (ComparativeStudyDetailsNew supplier in csItems)
                {
                    // Saving only selected supplier
                    if (supplier.IsSelected)
                    {
                        // Saving New CS Details
                        if (repo.saveComparativeStudyDetails(newCS.ID, supplier, CSData.CreatedByID)) numberOfSuccess++;
                    }

                    // Updating Quotation
                    repo.updateQuotationReceiveDetails(supplier, CSData.CreatedByID);
                }

                // Verification
                if (numberOfSuccess == 0)
                {
                    Error = new Exception("Failed to save comparative study details. Please try again.");
                    return null;
                }

                return newCS;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        private string checkComparativeStudy(CommonDataEntryClass Quotation)
        {
            try
            {
                DateTime lastReceiveDate = DateTime.Now.AddHours(-(DateTime.Now.Hour + 2));

                if (string.IsNullOrEmpty(Quotation.Data)) return "Comparative study details not found.";
                if (string.IsNullOrEmpty(Quotation.EmployeeCode)) return "Employee code not found";

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        private string checkComparativeStudyDetails(List<ComparativeStudyDetailsNew> Suppliers, Boolean PreventDuplicate = false)
        {
            try
            {
                foreach (ComparativeStudyDetailsNew supplier in Suppliers)
                {
                    if (supplier.IsSelected)
                    {
                        if (supplier.RequisitionID <= 0) return "Requisition id not found";
                        if (supplier.Rate <= 0) return "Invalid item rate. Rate must be larger than 0";
                        if (supplier.ItemID <= 0) return "Item id not found";
                        if (string.IsNullOrEmpty(supplier.SupplierCode)) return "Supplier Code not found";

                        Inventory_Items invItem = invRepo.getInventoryItem(supplier.ItemID);
                        if (supplier.Quantity < invItem.MOQ) return "Comparative study item quantity must be higher or equal to Minimum Order Quantity(MOQ)";

                        if (PreventDuplicate)
                        {
                            Inventory_Comparative_Study ExistingCS = getComparativeStudy(supplier.RequisitionID, supplier.ItemID);
                            if (ExistingCS != null)
                            {
                                return "Comparative Study is already exists. ( CS Code = " + ExistingCS.CSCode + ", Created on: " + ExistingCS.CreatedOn.GetValueOrDefault().ToString("dd MMM yyyy") + ")";
                            }
                        }
                    }
                }

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        // REPORT

        public List<ComparativeStudyListNP> getComparativeStudy(int empid, string CSCode, int ActionGroupID)
        {
            try
            {
                return repo.getComparativeStudy(empid, CSCode, ActionGroupID);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public object getComparativeStudyReport(string CSCode, int CSID)
        {
            try
            {
                Inventory_Comparative_Study CS = repo.getComparativeStudy(CSID, CSCode);
                Inventory_Quotation_Invitations Quotation = repo.getQuotationFromCS(CSID, CSCode);
                int QuotationID = Quotation.ID;

                List<QuotationDetailsNP> Report = new List<QuotationDetailsNP>();

                List<QuotationItemsNP> Items = qRepo.getQuotationItemsNP(QuotationID, "0");
                List<QuotationSuppliersNP> Suppliers = qRepo.getQuotationSuppliersNP(QuotationID, "0");

                List<Inventory_Quotation_Received_Details> QuotationReceiveDetails = qRepo.getQuotationReceiveDetails(QuotationID);
                foreach (var item in QuotationReceiveDetails)
                {
                    if(item.CurrencyId != null && item.CurrencyId != 0)
                    {
                        item.Currency = qRepo.getcurrencyByCurrencyId(item.CurrencyId).CurrencyName;

                    }
                }
                List<Inventory_Comparative_Study_Details> CSDetails = repo.getComparativeStudyDetails(CS.ID);

                List<ComparativeStudySignaturesNP> Signatures = repo.getComparativeStudySignaturesNP(CS.ID);

                // Adding Item
                foreach (QuotationItemsNP item in Items)
                {
                    QuotationDetailsNP rpt = new QuotationDetailsNP();

                    rpt.ItemID = item.ItemID;

                    rpt.ItemCode = item.ItemCode;
                    rpt.ItemName = item.ItemName;
                    rpt.ItemNameWithSpec = item.ItemName;
                    rpt.Quantity = item.Quantity;
                    rpt.MOQ = item.MOQ;
                    rpt.UOM = item.UOM;
                    rpt.MainGroupName = item.MainGroupName;
                    rpt.DeliveryDate = item.DeliveryDate;
                    rpt.SubGroupId = item.SubGroupId;
                    rpt.SubGroupName = item.SubGroupName;
                    rpt.RequisitionID = item.RequisitionID;
                    rpt.RequisitionCode = item.RequisitionCode;

                    // SPECIFICATION

                    rpt.Specifications = new List<ItemSpecification>();

                    List<ItemSpecification> Specs = invRepo.getRequisitionItemSpecificationList(Convert.ToInt32(item.RequisitionItemID), Convert.ToInt32(item.RequisitionID), item.ItemID.GetValueOrDefault());

                    if (Specs != null)
                    {
                        rpt.Specifications.AddRange(Specs);
                        rpt.ItemNameWithSpec = invService.getItemNameWithSpec(item.ItemName, Specs);
                    }

                    // Adding item suppliers
                    quotService.AddSuppliersToReport(rpt, item, Suppliers, QuotationReceiveDetails, CSDetails);

                    rpt.Suppliers = rpt.Suppliers.OrderByDescending(s => s.IsSelected).ToList();

                    Report.Add(rpt);
                };

                return new { CS, Report, Signatures };
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public Inventory_Comparative_Study cancelComparativeStudy(CommonDataEntryClass Data)
        {
            try
            {
                if (string.IsNullOrEmpty(Data.Remarks)) throw new Exception("Reason to cancel is required");
                return repo.cancelComparativeStudy(Data);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Comparative_Study updateComparativeStudy(CommonDataEntryClass CSData)
        {
            try
            {
                // CS Validation
                string reqValidation = checkComparativeStudy(CSData);
                if (!string.IsNullOrEmpty(reqValidation))
                {
                    Error = new Exception("Failed to save comparative study. " + reqValidation);
                    return null;
                }

                int numberOfSuccess = 0;
                int RequisitionID = 0;

                List<ComparativeStudyDetailsNew> csItems = JSONSerialize.getJSON<ComparativeStudyDetailsNew>(CSData.Data);

                // Checking CS details
                if (csItems == null || csItems.Count <= 0)
                {
                    Error = new Exception("Failed to update comparative study . No comparative study details found. Please try again." + JSONSerialize.ErrorMessage);
                    return null;
                }

                // CS Item Validation
                string detailValidation = checkComparativeStudyDetails(csItems);
                if (!string.IsNullOrEmpty(detailValidation))
                {
                    Error = new Exception("Failed to update comparative study . " + detailValidation);
                    return null;
                }

                RequisitionID = csItems[0].RequisitionID;

                // UPDATE CS
                Inventory_Comparative_Study updatedCS = repo.getExistingComparativeStudy(RequisitionID);
                // Checking the existing CS
                if (updatedCS == null)
                {
                    Error = new Exception("Failed to update comparative study. CS not found to update");
                    return null;
                }

                updatedCS.UpdatedByID = CSData.EmployeeCode;
                //checking
                if (CSData.ActionGroupID == ActionGroup.CHECKED)
                {
                    updatedCS.IsChecked = true;
                    updatedCS.CheckedRemarks = CSData.Remarks;
                    updatedCS.CheckedOn = DateTime.Now;
                    updatedCS.CheckedByID = CSData.EmployeeCode;
                }
                //audit
                if (CSData.ActionGroupID == ActionGroup.AUDIT)
                {
                    updatedCS.IsAuditDone = true;
                    updatedCS.AuditRemarks = CSData.Remarks;
                    updatedCS.AuditOn = DateTime.Now;
                    updatedCS.AuditById = CSData.EmployeeCode;
                }

                //recommend
                if (CSData.ActionGroupID == ActionGroup.RECOMMENDED)
                {
                    updatedCS.IsRecommended = true;
                    updatedCS.RecommendationRemarks = CSData.Remarks;
                    updatedCS.RecommendedOn = DateTime.Now;
                    updatedCS.RecommendedByID = CSData.EmployeeCode;
                }

                updatedCS.UpdatedOn = DateTime.Now;
                if (CSData.ActionGroupID != ActionGroup.REVIEWED && CSData.ActionGroupID != ActionGroup.CHECKED && !string.IsNullOrEmpty(CSData.Remarks)) updatedCS.Remarks += "; " + CSData.Remarks;

                repo.updateComparativeStudy(updatedCS.ID, updatedCS);

                // REVIEW, VERIFY, APPROVAL

                repo.reviewAndVerifyComparativeStudy(updatedCS.ID, CSData);

                // Cancel all Existing CS Details
                repo.cancelAllExistingCSDetails(updatedCS.ID, CSData.EmployeeCode);

                // Save CS Details
                foreach (ComparativeStudyDetailsNew supplier in csItems)
                {
                    // Saving only selected supplier
                    if (supplier.IsSelected)
                    {
                        // Saving New CS Details
                        if (repo.saveComparativeStudyDetails(updatedCS.ID, supplier, CSData.EmployeeCode)) numberOfSuccess++;
                    }

                    // Updating Quotation
                    repo.updateQuotationReceiveDetails(supplier, CSData.EmployeeCode);
                }

                // Verification
                if (numberOfSuccess == 0)
                {
                    Error = new Exception("Failed to save comparative study details. Please try again.");
                    return null;
                }

                //update other cost
                try
                {
                    List<QuotationSuppliersNP> supplierOtherCost = JSONSerialize.getJSON<QuotationSuppliersNP>(CSData.Code);

                    foreach (var item in supplierOtherCost)
                    {
                        Inventory_Quotation_Received_OtherCost existOtherCost = new QuotationNPRepositories().getOtherCost(Convert.ToInt32(item.QuotationID), item.SupplierCode);
                        if (existOtherCost == null)
                        {
                            existOtherCost = new Inventory_Quotation_Received_OtherCost();
                            existOtherCost.IsActive = true;
                            existOtherCost.QuotationID = Convert.ToInt32(item.QuotationID);
                            existOtherCost.SupplierCode = item.SupplierCode;
                            existOtherCost.OtherCost = item.OtherCost;
                            existOtherCost.OtherCostName = item.OtherCostName;
                            existOtherCost.Discount = item.Discount;
                        }
                        existOtherCost.LabourCost = item.LabourCost;
                        existOtherCost.CarryingCost = item.CarryingCost;
                        existOtherCost.CreatedOn = DateTime.Now;
                        existOtherCost.OtherCost = item.OtherCost;
                        existOtherCost.OtherCostName = item.OtherCostName;
                        existOtherCost.Discount = item.Discount;

                        new QuotationNPRepositories().updateOtherCost(existOtherCost);
                    }
                }
                catch (Exception e)
                {
                }

                return updatedCS;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        //public void SendCSEmail(string EmployeeID, Inventory_Comparative_Study  CSDetails, string EmailSubject, string ReceipientEmails)
        //{
        //    try
        //    {
        //        var fullPath = HttpContext.Current.Server.MapPath("~/StaticContent/emailformat");
        //        var filePath = Path.Combine(fullPath, "ComparativeStudyInternalEmail.html");

        //        var emailContent = repo.sendComparativeStudyEmail(EmployeeID, CSDetails, filePath, EmailSubject);

        //        // SEND EMAIL
        //        var sentSuccess = uRepo.sendEmail("", ReceipientEmails, "", EmailSubject, emailContent);
        //        //var sentSuccess = uRepo.sendEmail(CSDetails.EmployeeID, ReceipientEmails, "", EmailSubject, emailContent);
        //    }
        //    catch { }
        //}

        public List<ComparativeStudyListNP> getComparativeStudyStatusReport(int empid, int inventoryid)
        {
            try
            {
                var data = repo.getComparativeStudyStatusReport(empid, inventoryid);
                return data;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public Inventory_Comparative_Study getComparativeStudy(int RequisitionID, int ItemID)
        {
            try
            {
                return repo.getComparativeStudy(RequisitionID, ItemID);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public bool recommendCSList(List<ComparativeStudyListNP> cslist, string employeeid)
        {
            try
            {
                foreach (var item in cslist)
                {
                    var cs = repo.getComparativeStudyById(Convert.ToInt32(item.ID));

                    if (cs != null)
                    {
                        cs.IsRecommended = true;
                        cs.RecommendedByID = employeeid;
                        cs.RecommendedOn = DateTime.Now;
                        repo.updateComparativeStudy(cs);
                    }
                }

                return true;
            }
            catch (Exception ex) { Error = ex; return false; }
        }

        public bool approveCSList(List<ComparativeStudyListNP> cslist, string employeeid)
        {
            try
            {
                foreach (var item in cslist)
                {
                    var cs = repo.getComparativeStudyById(Convert.ToInt32(item.ID));

                    if (cs != null)
                    {
                        cs.IsManagementApproved = true;
                        cs.ManagementApprovedById = employeeid;
                        cs.ManagementApprovedOn = DateTime.Now;
                        repo.updateComparativeStudy(cs);
                    }
                }

                return true;
            }
            catch (Exception ex) { Error = ex; return false; }
        }

        public List<NonproductionItemPurchaseHistoryDto> geRequisitionItemPurchaseHistory(int RequisitionID)
        {
            try
            {
                var ItemList = new RequisitionNP().getInventoryRequisitionDetails(RequisitionID);

                List<NonproductionItemPurchaseHistoryDto> HistoryList = new List<NonproductionItemPurchaseHistoryDto>();

                foreach (var item in ItemList)
                {
                    var history = new InventorySettings().nonProductionItemHistory(Convert.ToInt32(item.ItemID));

                    if (history != null) HistoryList.AddRange(history);
                }

                return HistoryList;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<NonproductionItemPurchaseHistoryDto> getCSItemPurchaseHistory(string csid)
        {
            try
            {
                Inventory_Comparative_Study cs = repo.getComparativeStudyByCSCode(csid);

                if (cs == null) throw new Exception("CS not found.");

                var CSItemList = repo.getComparativeStudyDetails(cs.ID);

                List<NonproductionItemPurchaseHistoryDto> HistoryList = new List<NonproductionItemPurchaseHistoryDto>();

                foreach (var item in CSItemList)
                {
                    var history = new InventorySettings().nonProductionItemHistory(Convert.ToInt32(item.ItemID));
                    HistoryList.AddRange(history);
                }

                return HistoryList;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<NonproductionItemPurchaseHistoryDto> getItemPurchaseHistory(int RequisitionID)
        {
            try
            {
                var ItemList = new RequisitionNP().getInventoryRequisitionDetails(RequisitionID);
                List<NonproductionItemPurchaseHistoryDto> HistoryList = new List<NonproductionItemPurchaseHistoryDto>();

                foreach (var item in ItemList)
                {
                    var history = new InventorySettings().nonProductionItemHistory(Convert.ToInt32(item.ItemID));
                    HistoryList.AddRange(history);
                }

                return HistoryList;
            }
            catch (Exception ex) { Error = ex; return null; }
        }
    }
}