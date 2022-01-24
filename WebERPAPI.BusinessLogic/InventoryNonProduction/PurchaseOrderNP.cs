using System;
using System.Collections.Generic;
using WebERPAPI.BusinessLogic.Map;
using WebERPAPI.BusinessLogic.Interfaces;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.InventoryNonProduction;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.ComparativeStudyNP;
using WebERPAPI.DTO.Inventory.PurchaseOrdersNP;
using WebERPAPI.Library;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.Data.Repository.Inventory;
using System.Linq;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.BusinessLogic.InventoryNonProduction
{
    public class PurchaseOrderNP
    {
        public Exception Error = new Exception();
        private PurchaseOrdersNPRepositories repo = new PurchaseOrdersNPRepositories();
        private RequisitionNPRepositories invRepo = new RequisitionNPRepositories();

        //purchase order advance paid
        public List<DTO.InventoryNonProduction.InventoryPurchaseOrderAdvancePaidDTO> getAdvancePaymentListByPoCode(string POData)
        {
            try
            {
                return repo.getAdvancePaymentListByPoCode(POData);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Purchase_Order_AdvancePaid saveUpdateAdvancePayment(Inventory_Purchase_Order_AdvancePaid POData)
        {
            try
            {
                return repo.saveUpdateAdvancePayment(POData);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Purchase_Order_AdvancePaid deleteAdvancePayment(Inventory_Purchase_Order_AdvancePaid PO, string Remarks)
        {
            try
            {
                var item = repo.getAdvancePaymentByIdAndPocode(PO.ID, PO.POID);
                if (item == null)
                {
                    Error = new Exception("Not Found.");
                    return null;
                }
                //item.IsCancel=try;
                item.IsCanceled = true;
                item.CancelRemarks = Remarks;
                item.UpdatedByID = PO.UpdatedByID;
                item.UpdatedOn = PO.UpdatedOn;
                return repo.saveUpdateAdvancePayment(item);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Purchase_Orders savePurchaseOrder(PurchaseOrderNPNew POData)
        {
            try
            {
                // PO Validation
                string reqValidation = checkPurchaseOrder(POData);
                if (!string.IsNullOrEmpty(reqValidation))
                {
                    Error = new Exception("Failed to save purchase order. " + reqValidation);
                    return null;
                }

                int numberOfSuccess = 0;
                int RequisitionID = 0;

                Inventory_Purchase_Orders PO = new PurchaseOrderNPMap().map(POData);
                List<PurchaseOrderDetailsNew> csItems = JSONSerialize.getJSON<PurchaseOrderDetailsNew>(POData.Data);

                // Checking PO details
                if (csItems == null || csItems.Count <= 0)
                {
                    Error = new Exception("Failed to save purchase order . No purchase order details found. Please try again." + JSONSerialize.ErrorMessage);
                    return null;
                }

                // PO Item Validation
                string detailValidation = checkPurchaseOrderDetails(csItems, PO, true);
                if (!string.IsNullOrEmpty(detailValidation))
                {
                    Error = new Exception("Failed to save purchase order." + detailValidation);
                    return null;
                }

                RequisitionID = csItems[0].RequisitionID;

                // SAVE
                Inventory_Purchase_Orders newPO = repo.savePurchaseOrder(PO, RequisitionID);

                // Checking the existing PO
                if (newPO == null)
                {
                    Error = new Exception("Failed to save purchase order. Please try again.");
                    return null;
                }

                // Cancel all Existing PO Details
                //repo.cancelAllExistingCSDetails(newPO.ID, POData.EmployeeCode);

                // Save PO Details

                foreach (PurchaseOrderDetailsNew item in csItems)
                {
                    Inventory_Purchase_Order_Detail newPD = new PurchaseOrderNPMap().map(item);

                    newPD.CreatedByID = POData.EmployeeCode;
                    newPD.POID = newPO.ID;
                    newPD.IsActive = true;
                    // Saving New PO Details
                    if (repo.savePurchaseOrderDetails(newPD)) numberOfSuccess++;
                }

                // Verification
                if (numberOfSuccess == 0)
                {
                    Error = new Exception("Failed to save purchase order details. Please try again.");
                    return null;
                }

                return newPO;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Purchase_Orders updatePurchaseOrder(PurchaseOrderNPNew POData)
        {
            try
            {
                // PO Validation
                string reqValidation = checkPurchaseOrder(POData);
                if (!string.IsNullOrEmpty(reqValidation))
                {
                    Error = new Exception("Failed to save purchase order. " + reqValidation);
                    return null;
                }

                int numberOfSuccess = 0;
                int RequisitionID = 0;

                Inventory_Purchase_Orders PO = new PurchaseOrderNPMap().map(POData);
                List<PurchaseOrderDetailsNew> csItems = JSONSerialize.getJSON<PurchaseOrderDetailsNew>(POData.Data);

                // Checking PO details
                if (csItems == null || csItems.Count <= 0)
                {
                    Error = new Exception("Failed to save purchase order. No purchase order details found. Please try again." + JSONSerialize.ErrorMessage);
                    return null;
                }

                // PO Item Validation
                string detailValidation = checkPurchaseOrderDetails(csItems, PO);
                if (!string.IsNullOrEmpty(detailValidation))
                {
                    Error = new Exception("Failed to save purchase order." + detailValidation);
                    return null;
                }

                RequisitionID = csItems[0].RequisitionID;

                // SAVE

                Inventory_Purchase_Orders existingPO = repo.getPurchaseOrder(POData.ID);
                // Checking the existing PO
                if (existingPO == null)
                {
                    Error = new Exception("Failed to save purchase order. Please try again.");
                    return null;
                }

                existingPO.TermsAndConditions = PO.TermsAndConditions;
                existingPO.UpdatedByID = PO.UpdatedByID;
                existingPO.UpdatedOn = DateTime.Now;
                existingPO.RequiredDate = PO.RequiredDate;
                existingPO.BillPaymentTypeID = PO.BillPaymentTypeID;
                if (!string.IsNullOrEmpty(PO.Remarks)) existingPO.Remarks += "; " + PO.Remarks;

                existingPO.TotalPrice = PO.TotalPrice;
                existingPO.VATAmount = PO.VATAmount;
                existingPO.Discount = PO.Discount;
                existingPO.TotalAmount = PO.TotalAmount;

                repo.updatePurchaseOrder(POData.ID, existingPO);

                // Cancel all Existing PO Details
                repo.cancelAllExistingPODetails(POData.ID, POData.EmployeeCode);

                // Save PO Details

                foreach (PurchaseOrderDetailsNew item in csItems)
                {
                    Inventory_Purchase_Order_Detail newPD = new PurchaseOrderNPMap().map(item);

                    newPD.CreatedByID = POData.EmployeeCode;
                    newPD.POID = POData.ID;
                    newPD.IsActive = true;

                    // Saving New PO Details
                    if (repo.savePurchaseOrderDetails(newPD)) numberOfSuccess++;
                }

                // Verification
                if (numberOfSuccess == 0)
                {
                    Error = new Exception("Failed to save purchase order details. Please try again.");
                    return null;
                }

                return existingPO;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        private string checkPurchaseOrder(PurchaseOrderNPNew POData)
        {
            try
            {
                DateTime lastReceiveDate = DateTime.Now.AddHours(-(DateTime.Now.Hour + 2));

                if (string.IsNullOrEmpty(POData.Data)) return "Purchase order details not found.";
                if (string.IsNullOrEmpty(POData.EmployeeCode)) return "Employee code not found";

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        private string checkPurchaseOrderDetails(List<PurchaseOrderDetailsNew> POItems, Inventory_Purchase_Orders PO, Boolean PreventDuplicate = false)
        {
            try
            {
                decimal TotalItemPrice = 0;
                decimal TotalVATAmount = 0;

                foreach (PurchaseOrderDetailsNew item in POItems)
                {
                    if (item.RequisitionID <= 0) return "Requisition id not found";
                    if (item.Rate <= 0) return "Invalid item rate. Rate must be larger than 0";
                    if (item.ItemID <= 0) return "Item id not found";

                    Inventory_Items invItem = invRepo.getInventoryItem(item.ItemID);
                    if (item.Quantity < invItem.MOQ) return "Comparative study item quantity must be higher or equal to Minimum Order Quantity(MOQ)";

                    if (PreventDuplicate)
                    {
                        Inventory_Purchase_Orders ExistingPO = getPurchaseOrderToday(item.RequisitionID, item.ItemID);
                        if (ExistingPO != null)
                        {
                            return "Purchase order is already exists. ( PO Code = " + ExistingPO.POCode + ", Created on: " + ExistingPO.CreatedOn.GetValueOrDefault().ToString("dd MMM yyyy") + ")";
                        }
                    }

                    TotalItemPrice += (item.Quantity*item.Rate);
                    TotalVATAmount += (item.Quantity* item.Rate) * item.VATPercent;
                    //item.
                }

                PO.TotalPrice = TotalItemPrice;
                PO.VATAmount = TotalVATAmount;
                PO.TotalAmount = (TotalItemPrice + TotalVATAmount) - PO.Discount.GetValueOrDefault();

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public List<PurcaseOrderBillReportDto> getPurchaseOrderBillReport(string SupplierId)
        {
            try
            {
                List<PurcaseOrderBillReportDto> Suppliers = new List<PurcaseOrderBillReportDto>();

                if (SupplierId == "ALL")
                {
                    Suppliers = repo.getPurchaseOrderSupplierListForBillReport();

                    foreach (var item in Suppliers)
                    {
                        item.POBillDetailsList.AddRange(repo.getPurchaseOrderBillDetailsBySuppliers(item.SupplierID));
                    }
                }
                else
                {
                    Suppliers = repo.getPurchaseOrderSupplierListForBillReport().Where(i => i.SupplierID == SupplierId).ToList();

                    foreach (var item in Suppliers)
                    {
                        item.POBillDetailsList.AddRange(repo.getPurchaseOrderBillDetailsBySuppliers(item.SupplierID));
                    }
                }

                // List<POBillDetailsforPOReportDto> Suppliers = repo.getPurchaseOrderBillDetailsBySuppliers(SupplierId);

                return Suppliers.Where(i => i.POBillDetailsList.Count > 0).ToList(); ;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<PurcaseOrderBillReportDto> getAllSupplierforPurchaseOrder()
        {
            try
            {
                List<PurcaseOrderBillReportDto> Suppliers = repo.getPurchaseOrderSupplierListForBillReport();

                return Suppliers;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<ComparativeStudySuppliersNP> getComparativeStudySuppliersNP(string EmployeeCode)
        {
            try
            {
                List<ComparativeStudySuppliersNP> Suppliers = repo.getComparativeStudySuppliersNP(EmployeeCode);

                var poList = repo.getComparativeStudyForPurchaseNP(0, "");

                foreach (var item in Suppliers)
                {
                    item.poList.AddRange(poList.Where(p => p.SupplierCode == item.SupplierCode));
                }

                return Suppliers.Where(x => x.poList.Count > 0).ToList();

                //return repo.getComparativeStudySuppliersNP(EmployeeCode);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public CheckCancelledList saveCancelledCheck(CheckCancelledList data)
        {
            try
            {
                data.AddedDate = DateTime.Now;
                data = repo.saveCancelledCheck(data);

                return data;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<ComparativeStudyForPurchaseNP> getComparativeStudyForPurchaseNP(int MainGroupID, string SupplierCode)
        {
            try
            {
                return repo.getComparativeStudyForPurchaseNP(MainGroupID, SupplierCode);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public Inventory_Purchase_Orders updatePurchaseOrderStatus(CommonDataEntryClass POData)
        {
            try
            {
                return repo.updatePurchaseOrderStatus(POData);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<ComparativeStudyItemsForPurchaseOrderNP> getComparativeStudyItemsForPurchaseOrder(int CSID, string SupplierCode)
        {
            try
            {
                return repo.getComparativeStudyItemsForPurchaseOrder(CSID, SupplierCode);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public Inventory_Purchase_Order_Detail getPurchaseOrderDetails(int RequisitionID, int ItemID)
        {
            try
            {
                return repo.getPurchaseOrderDetails(RequisitionID, ItemID);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public Inventory_Purchase_Orders getPurchaseOrder(int RequisitionID, int ItemID)
        {
            try
            {
                return repo.getPurchaseOrder(RequisitionID, ItemID);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public Inventory_Purchase_Orders getPurchaseOrderToday(int RequisitionID, int ItemID)
        {
            try
            {
                return repo.getPurchaseOrderToday(RequisitionID, ItemID);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<PurchaseOrdersNPToVerifyDTO> getPurchaseOrderToVerify()
        {
            try
            {
                return repo.getPurchaseOrderToVerify();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public object getPurchaseOrderReport(string POCode, int POID)
        {
            try
            {
                PurchaseOrderNPDto PO = repo.getPurchaseOrderNP(POCode, POID);
                if (PO == null) throw new Exception("Purchase order master data not found");

                List<PurchaseOrderDetailsNP> PODetails = repo.getPurchaseOrderDetailsNP(PO.ID.GetValueOrDefault());

                RequisitionNPRepositories rRepo = new RequisitionNPRepositories();

                foreach (PurchaseOrderDetailsNP item in PODetails)
                {
                    var reqItem = rRepo.getRequisitionItem(Convert.ToInt32(item.RequisitionID), Convert.ToInt32(item.ItemID), item.Quantity);
                    if (reqItem != null) item.RequisitionItemID = reqItem.ID;

                    item.Specifications = new List<ItemSpecification>();
                    List<ItemSpecification> specs = rRepo.getRequisitionItemSpecificationList(Convert.ToInt32(item.RequisitionItemID), Convert.ToInt32(item.RequisitionID), item.ItemID.GetValueOrDefault());
                    if (specs != null) item.Specifications.AddRange(specs);
                }

                PurchaseOrderSignaturesNPDTO Signatures = repo.getPurchaseOrderSignatureNP(POCode, POID);

                return new { PO, PODetails, Signatures };
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<PurchaseOrderNPDto> getPurchaseOrderStatusReport(string DateFrom, string DateTo, int InventoryTypeID, string SupplierCode, string SearchText)
        {
            try
            {
                return repo.getPurchaseOrderStatusReport(DateFrom, DateTo, InventoryTypeID, SupplierCode, SearchText);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<nonPSupplierListOfAllPODto> getPurchaseOrderSupplierList()
        {
            try
            {
                return repo.getPurchaseOrderSupplierList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public Boolean autoPurchaseOrderClose(CommonDataEntryClass Data)
        {
            try
            {
                return true; //repo.autoPurchaseOrderClose(MainGroupID, DateFrom, DateTo, SearchText);
            }
            catch (Exception ex) { Error = ex; return false; }
        }

        public Inventory_Purchase_Orders PurchaseOrderClose(int POID, string EmployeeCode)
        {
            try
            {
                Inventory_Purchase_Orders po = repo.getPurchaseOrderByPOID(POID);

                if (po == null)
                {
                    throw new Exception("Purchase Order Not Found");
                }

                po.IsClosed = true;
                po.ClosedOn = DateTime.Now;
                po.ClosedByID = EmployeeCode;
                return repo.updatePurchaseOrder(po.ID, po);
            }
            catch (Exception ex)
            { Error = ex; return null; }
        }

        public List<Inventory_Purchase_Order_Detail> getPurchaseOrderItemListByPoid(int POID)
        {
            try
            {
                return repo.getPurchaseOrderItemListByPoid(POID);
            }
            catch (Exception ex) { Error = ex; return null; }
        }
    }
}