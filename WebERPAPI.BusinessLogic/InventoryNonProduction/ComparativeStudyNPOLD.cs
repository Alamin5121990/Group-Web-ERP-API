using System;
using System.Collections.Generic;
using System.Linq;
using WebERPAPI.BusinessLogic.Interfaces;
using WebERPAPI.BusinessLogic.Inventory;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.DTO.Inventory.Procurement.CS;
using WebERPAPI.DTO.Inventory.Procurement.Quotation;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.InventoryNonProduction;
using WebERPAPI.Library;

namespace WebERPAPI.BusinessLogic.InventoryNonProduction
{
    public class ComparativeStudyNPOLD : IComparativeStudyNP
    {
        public Exception Error = new Exception();
        private ComparativeStudyNPRepositories repo = new ComparativeStudyNPRepositories();
        private RequisitionNPRepositories invRepo = new RequisitionNPRepositories();

        private QuotationNPRepositories qRepo = new QuotationNPRepositories();
        private InventorySettings invService = new InventorySettings();
        private QuotationNP quotService = new QuotationNP();

        public Inventory_Comparative_Study saveComparativeStudy(CommonDataEntryClass CS)
        {
            try
            {
                // CS Validation
                string reqValidation = checkComparativeStudy(CS);
                if (!string.IsNullOrEmpty(reqValidation))
                {
                    Error = new Exception("Failed to save comparative study. " + reqValidation);
                    return null;
                }

                int numberOfSuccess = 0;
                int RequisitionID = 0;

                List<ComparativeStudyDetailsNew> csItems = JSONSerialize.getJSON<ComparativeStudyDetailsNew>(CS.Data);

                // Checking CS details
                if (csItems == null || csItems.Count <= 0)
                {
                    Error = new Exception("Failed to save comparative study . No comparative study details found. Please try again." + JSONSerialize.ErrorMessage);
                    return null;
                }

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

                //if (newCS == null) newCS = repo.saveComparativeStudy(CS);
                //else repo.updateComparativeStudy(CS.ID, CS);

                // Checking the existing CS
                if (newCS == null)
                {
                    Error = new Exception("Failed to save comparative study. Please try again.");
                    return null;
                }

                // Cancel all Existing CS Details
                repo.cancelAllExistingCSDetails(newCS.ID, CS.EmployeeCode);

                // Save CS Details

                foreach (ComparativeStudyDetailsNew supplier in csItems)
                {
                    // Saving only selected supplier
                    if (supplier.IsSelected)
                    {
                        // Saving New CS Details
                        if (repo.saveComparativeStudyDetails(newCS.ID, supplier, CS.EmployeeCode)) numberOfSuccess++;
                    }

                    // Updating Quotation
                    repo.updateQuotationReceiveDetails(supplier, CS.EmployeeCode);
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

                    rpt.DeliveryDate = item.DeliveryDate;
                    rpt.SubGroupId = item.SubGroupId;
                    rpt.SubGroupName = item.SubGroupName;
                    rpt.RequisitionID = item.RequisitionID;
                    rpt.RequisitionCode = item.RequisitionCode;

                    // SPECIFICATION

                    rpt.Specifications = new List<ItemSpecification>();

                    List<ItemSpecification> Specs = invRepo.getItemSpecifications(Convert.ToInt32(item.RequisitionID), item.ItemID.GetValueOrDefault());

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

                return new { Report, Signatures };
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

                //repo.updateComparativeStudy(updatedCS.ID, CSData);

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

                return updatedCS;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<ComparativeStudyListNP> getComparativeStudyStatusReport(int MainGroupID, int inventorytypeid)
        {
            try
            {
                return repo.getComparativeStudyStatusReport(MainGroupID, inventorytypeid);
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
    }
}