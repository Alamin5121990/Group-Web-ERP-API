using System;
using System.Collections.Generic;
using WebERPAPI.BusinessLogic.Interfaces;
using WebERPAPI.BusinessLogic.Inventory;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.InventoryNonProduction;
using WebERPAPI.Library;

namespace WebERPAPI.BusinessLogic.InventoryNonProduction
{
    public class RequisitionNP : IRequisitionNP
    {
        public Exception Error = new Exception();
        private RequisitionNPRepositories repo = new RequisitionNPRepositories();
        private InventorySettings invRepo = new InventorySettings();

        public Inventory_Requisitions createInventoryRequisition(InventoryRequisitionNew NewReq)
        {
            try
            {
                // Requisition Validation
                string reqValidation = checkRequisition(NewReq);
                if (!string.IsNullOrEmpty(reqValidation))
                {
                    Error = new Exception("Failed to save requisition. " + reqValidation);
                    return null;
                }

                int numberOfSuccess = 0;
                List<InventoryRequisitionItems> reqItems = JSONSerialize.getJSON<InventoryRequisitionItems>(NewReq.Data);

                // Checking requisition details
                if (reqItems == null || reqItems.Count <= 0)
                {
                    Error = new Exception("Failed to update requisition. No requisition details found. Please try again." + JSONSerialize.ErrorMessage);
                    return null;
                }

                // Requisition Item Validation
                string detailVelidation = checkRequisitionItemDetails(reqItems);
                if (!string.IsNullOrEmpty(detailVelidation))
                {
                    Error = new Exception("Failed to update requisition. " + detailVelidation);
                    return null;
                }

                // Create New Requisition
                Inventory_Requisitions requisition = repo.createInventoryRequisition(NewReq, reqItems);

                // Checking new requisition has been created
                if (requisition == null)
                {
                    Error = new Exception("Failed to create new requisition. Please try again. " + Error.Message);
                    return null;
                }

                // Save Requisition Months & Brand
                if (NewReq.InventoryTypeID == 2)
                {
                    repo.saveRequisitionMonths(requisition.ID, NewReq);
                    // Save Requisition Brands
                    repo.saveRequisitionBrands(requisition.ID, NewReq);
                }

                // Save Requisition Details
                foreach (InventoryRequisitionItems item in reqItems)
                {
                    if (repo.saveInventoryRequisitionDetails(requisition, item)) numberOfSuccess++;
                }

                // Verification
                if (numberOfSuccess == 0)
                {
                    Error = new Exception("Failed to save requisition details. Please try again.");
                    return null;
                }

                return requisition;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Requisitions updateInventoryRequisition(InventoryRequisitionNew NewReq)
        {
            try
            {
                // Requisition Validation
                string reqValidation = checkRequisition(NewReq);
                if (!string.IsNullOrEmpty(reqValidation))
                {
                    Error = new Exception("Failed to update requisition. " + reqValidation);
                    return null;
                }

                int numberOfSuccess = 0;

                List<InventoryRequisitionItems> reqItems = JSONSerialize.getJSON<InventoryRequisitionItems>(NewReq.Data);

                // Checking requisition details
                if (reqItems == null)
                {
                    Error = new Exception("Failed to update requisition. No requisition details found. Please try again.");
                    return null;
                }

                // Requisition Item Validation
                string detailVelidation = checkRequisitionItemDetails(reqItems);
                if (!string.IsNullOrEmpty(detailVelidation))
                {
                    Error = new Exception("Failed to update requisition. " + detailVelidation);
                    return null;
                }

                // Updating the Requisition
                Inventory_Requisitions requisition = repo.updateInventoryRequisition(NewReq);

                // Checking the existing requisition
                if (requisition == null)
                {
                    Error = new Exception("Failed to update requisition. No requisition found. Please try again.");
                    return null;
                }

                // Save Requisition Months & Brand
                if (NewReq.InventoryTypeID == 2)
                {
                    repo.saveRequisitionMonths(requisition.ID, NewReq);
                    // Save Requisition Brands
                    repo.saveRequisitionBrands(requisition.ID, NewReq);
                }

                // Removing existing requisition details
                repo.deleteExistingRequisitionDetails(NewReq.ID.GetValueOrDefault(), NewReq.EmployeeID);

                // Save Requisition Details
                foreach (InventoryRequisitionItems item in reqItems)
                {
                    if (repo.saveInventoryRequisitionDetails(requisition, item)) numberOfSuccess++;
                }

                // Verification
                if (numberOfSuccess == 0)
                {
                    Error = new Exception("Failed to save requisition details. Please try again.");
                    return null;
                }

                return requisition;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Items deleteInventoryItem(int itemid, string employeeid)
        {
            try
            {
                return repo.deleteInventoryItem(itemid, employeeid);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public object getItemReport(int itemid, string itemcode)
        {
            try
            {
                return repo.getItemReport(itemid, itemcode);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<RequistionSearchItems> getRequisitionsBySearch(int employeeid, int InventoryTypeID,
            string DateFrom, string DateTo, string SearchText)
        {
            try
            {
                return repo.getRequisitionsBySearch(employeeid, InventoryTypeID, DateFrom, DateTo, SearchText);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<RequistionSearchItems> getPendingRequisitionList(int InventoryTypeID)
        {
            try
            {
                return repo.getPendingRequisitionList(InventoryTypeID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<InventoryRequisitionsForApproval> getRequisitionsForApproval(int EmployeeID, int ActionID)
        {
            try
            {
                return repo.getRequisitionsForApproval(EmployeeID, ActionID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Requisitions verifyInventoryRequisition(int ActionID, CommonDataEntryClass Data)
        {
            try
            {
                return repo.verifyInventoryRequisition(ActionID, Data);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Requisitions getRequisition(int RequisitionID)
        {
            try
            {
                return repo.getRequisition(RequisitionID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<Inventory_Requisition_Items> getRequisitionItemList(int RequisitionID, int ItemID)
        {
            try
            {
                return repo.getRequisitionItemList(RequisitionID, ItemID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Requisition_Items getRequisitionItems(int RequisitionID, int ItemID)
        {
            try
            {
                return repo.getRequisitionItems(RequisitionID, ItemID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<Currency> getCurrencies()
        {
            try
            {
                return repo.getCurrencies();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }
        public object getRequisitionDetails(int RequisitionID)
        {
            try
            {
                return repo.getRequisitionDetails(RequisitionID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public object getRequisitionReport(string RequisitionCode, int requisitionid)
        {
            try
            {
                return repo.getRequisitionReport(RequisitionCode, requisitionid);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Requisition_Items deleteRequisitionItem(int requisitionid, int itemid, string employeeid)
        {
            try
            {
                return repo.deleteRequisitionItem(requisitionid, itemid, employeeid);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<InventoryPrivilege> getInventoryPrivilege(int inventorytypeid, int userid)
        {
            try
            {
                return repo.getInventoryPrivilege(inventorytypeid, userid);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Boolean saveInventoryPrivilege(InventoryPrivilegeNew Data)
        {
            try
            {
                return repo.saveInventoryPrivilege(Data);
            }
            catch (Exception ex)
            {
                Error = ex;
                return false;
            }
        }

        private string checkRequisitionItemDetails(List<InventoryRequisitionItems> RequisitionItems)
        {
            try
            {
                foreach (InventoryRequisitionItems item in RequisitionItems)
                {
                    if (item.ItemID == null) return "Item ID not found";
                    //if (item.VersionID == null) return "Version ID not found";
                    if (item.Quantity == null || item.Quantity <= 0) return "Quantity not found or invalid";
                    if (item.DeliveryDate < DateTime.Now.AddHours(-DateTime.Now.Hour)) return "Invalid delivery date.";

                    Inventory_Items invItem = repo.getInventoryItem(item.ItemID.GetValueOrDefault());
                    if (item.Quantity < invItem.MOQ) return "Requisition item quantity must be higher or equal to Minimum Order Quantity(MOQ)";
                }

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        private string checkRequisition(InventoryRequisitionNew Requisition)
        {
            try
            {
                if (string.IsNullOrEmpty(Requisition.Data)) return "Requisition item list not found.";

                if (Requisition.StoreID == null) return "Invalid store. Store ID not found";
                if (Requisition.InventoryTypeID == null || Requisition.InventoryTypeID <= 0) return "Invalid inventory type. InventoryTypeID not found";
                //if (Requisition.MainGroupID == null) return "Invalid requisition group. MainGroupID not found";
                if (Requisition.RequisitionTypeID == null) return "Invalid requisition type. RequisitionTypeID not found";

                if (Requisition.InventoryTypeID > 0 && Requisition.InventoryTypeID == 2)
                {
                    if (string.IsNullOrEmpty(Requisition.Months)) return "Invalid requisition month. Inventory Type: Promotional.";
                    //if (string.IsNullOrEmpty(Requisition.Months)) return "Invalid requisition month. Inventory Type: Promotional.";
                }

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public List<string> getItemUOM()
        {
            try
            {
                return repo.getItemUOM();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<Inventory_Requisition_Type> getRequisitionTypes()
        {
            try
            {
                return repo.getRequisitionTypes();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public string getInventoryRequisitionForBrands(int RequisitionID)
        {
            try
            {
                return repo.getInventoryRequisitionForBrands(RequisitionID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public string getInventoryRequisitionForMonths(int RequisitionID)
        {
            try
            {
                return repo.getInventoryRequisitionForMonths(RequisitionID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<InventoryRequisitionDetails> getInventoryRequisitionDetails(int RequisitionID)
        {
            try
            {
                return repo.getInventoryRequisitionDetails(RequisitionID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<ItemSpecification> getItemSpecificationInCommas(int RequisitionID, int ItemID)
        {
            try
            {
                return repo.getItemSpecificationInCommas(RequisitionID, ItemID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Requisitions cancelInventoryRequisition(int ID, string Remark, string CancelBy)
        {
            try
            {
                if (ID == 0 || Remark == "" || Remark == string.Empty || CancelBy == "" || CancelBy == string.Empty)
                {
                    throw new Exception("Field Missing.");
                }

                //Logic for cancelling all dependents

                Inventory_Requisitions req = repo.getRequisition(ID);
                req.IsCanceled = true;
                req.ReasonToCancel = Remark;
                req.CanceledOn = DateTime.Now;
                req.CanceledByID = CancelBy;

                return repo.updateInventoryRequisitionForCancel(req);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }
    }
}