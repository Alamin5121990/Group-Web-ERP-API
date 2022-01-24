using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebERPAPI.BusinessLogic.Map;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.Inventory;
using WebERPAPI.Data.Repository.InventoryNonProduction;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.DTO.InventoryNonProduction;
using WebERPAPI.Library;

namespace WebERPAPI.BusinessLogic.InventoryNonProduction
{
    public class SpotPurchaseNP
    {
        public Exception Error = new Exception();
        private SpotPurchaseRepositories repo = new SpotPurchaseRepositories();
        private InventorySettingsRepositories InventoryRepo = new InventorySettingsRepositories();
        private SupplierRepositories SupplierRepo = new SupplierRepositories();
        private RequisitionNPRepositories RequisitionRepo = new RequisitionNPRepositories();
        private PurchaseOrdersNPRepositories PORepo = new PurchaseOrdersNPRepositories();

        public List<InventoryRequisitionsForSpotPurchase> getRequisitionsForSpotPurchase(int EmployeeID)
        {
            try
            {
                return repo.getRequisitionsForSpotPurchase(EmployeeID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Spot_Purchase SpotPurchaseApprove(string pocode, int EmployeeID, string ApproveRemark)
        {
            try
            {
                var SPO = repo.getSpotPurchaseMasterForReport(pocode);
                List<Inventory_Spot_Purchase_Details> SPOItems = repo.getSpotPurchaseDetails(SPO.ID);

                if (SPO == null)
                {
                    throw new Exception("PO not foound.");
                }

                SPO.IsApproved = true;
                SPO.ApprovedByID = EmployeeID;
                SPO.ApprovedDate = DateTime.Now;

                if (ApproveRemark == "0")
                    SPO.ApprovalRemarks = string.Empty;
                else
                    SPO.ApprovalRemarks = ApproveRemark;

                SPO.UpdatedByID = EmployeeID;
                SPO.UpdatedOn = DateTime.Now;

                SPO = repo.updateSpotPurchase(SPO);

                if (SPO != null)
                {
                    Inventory_Purchase_Orders PO = new Inventory_Purchase_Orders();

                    PO.CreatedByID = new HRMSEntities().Employees.Where(e => e.ID == EmployeeID).FirstOrDefault().EmployeeID;
                    PO.CreatedOn = DateTime.Now;

                    var item = repo.getInventoryItem(SPOItems[0].ItemID);
                    var SubGroup = repo.getInventoryItemSubgroup(item.SubGroupId);
                    PO.MainGroupID = Convert.ToInt32(SubGroup.MainGroupID);

                    var Requisition = RequisitionRepo.getRequisition(SPOItems[0].RequisitionID);

                    PO.InventoryTypeID = Requisition.InventoryTypeID;
                    PO.SupplierCode = SPOItems[0].Supplier;
                    PO.ManufacturerCode = "";
                    PO.RequiredDate = SPO.PurchaseDate;
                    PO.DeliveryDate = SPO.PurchaseDate;
                    PO.BillPaymentTypeID = 1; //cash payment
                    PO.Remarks = "Auto generated from Spot Purchase Approval.";

                    PO.TotalPrice = 0;
                    PO.TotalAmount = 0;
                    PO.VATAmount = 0;

                    foreach (var Spotitem in SPOItems)
                    {
                        decimal ItemPrice = Spotitem.Rate * Spotitem.Quantity;

                        PO.TotalPrice = PO.TotalPrice + ItemPrice;
                        PO.TotalAmount = PO.TotalPrice; //PO.TotalAmount + (ItemPrice + ((ItemPrice * Convert.ToDecimal(Spotitem.VATPercent)) / 100));
                        PO.VATAmount = PO.VATAmount + ((ItemPrice * Convert.ToDecimal(Spotitem.VATPercent)) / 100);
                    }

                    PO.Discount = 0;
                    PO.CarryingCost = 0;
                    PO.LabourCost = 0;
                    PO.IsApproved = false;
                    PO.IsClosed = false;
                    PO.IsCanceled = false;

                    PO = PORepo.savePurchaseOrder(PO, SPOItems[0].RequisitionID);

                    if (PO.POCode != null) // PO saved successfully now save details
                    {
                        int numberOfSuccess = 0;
                        foreach (var inventory_Spot in SPOItems)
                        {
                            Inventory_Purchase_Order_Detail newPD = new Inventory_Purchase_Order_Detail();

                            newPD.POID = PO.ID;
                            newPD.RequisitionID = Requisition.ID;
                            newPD.ItemID = inventory_Spot.ItemID;
                            newPD.Quantity = inventory_Spot.Quantity;
                            newPD.Rate = inventory_Spot.Rate;
                            newPD.VATPercent = Convert.ToDecimal(inventory_Spot.VATPercent);
                            if (newPD.VATPercent != 0) newPD.VATPercent = newPD.VATPercent / 100;
                            newPD.OrderNo = numberOfSuccess;
                            newPD.POID = PO.ID;
                            newPD.IsActive = true;
                            newPD.CreatedByID = new HRMSEntities().Employees.Where(e => e.ID == EmployeeID).FirstOrDefault().EmployeeID;
                            newPD.CreatedOn = DateTime.Now;

                            // Saving New PO Details
                            if (PORepo.savePurchaseOrderDetails(newPD)) numberOfSuccess++;
                        }
                    }
                }
                //spot purchase approved now create PO for the spot purchase

                //if (generatePoFromSpotPurchase(PO) == false)
                //{
                //    throw new Exception("Purchase Order create error.");
                //}

                return SPO;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        //public bool generatePoFromSpotPurchase(Inventory_Spot_Purchase SPO)
        //{
        //    try
        //    {
        //        List<Inventory_Spot_Purchase_Details> SPODetails = repo.getSpotPurchaseDetails(SPO.ID);

        //        //getting unique supplier from spot purchase detail list for creating multipe PO
        //        List<string> UniqueSupplier = new List<string>();

        //        foreach (var item in SPODetails)
        //        {
        //            if (isSupplierInList(UniqueSupplier, item.Supplier) == false)
        //            {
        //                UniqueSupplier.Add(item.Supplier);
        //            }
        //        }
        //        //got uniqe supplier in UniqueSupplier

        //        //now generate PO master and PO details for each supplier

        //        foreach (var supplier in UniqueSupplier) // this number of master PO will create with details
        //        {
        //            Inventory_Purchase_Orders PO = new Inventory_Purchase_Orders(); // master PO
        //            List<Inventory_Purchase_Order_Detail> PODetails = new List<Inventory_Purchase_Order_Detail>(); // detail list for master
        //            Inventory_Purchase_Order_Detail PODetailItem = new Inventory_Purchase_Order_Detail(); // single detail for creating list

        //            //first create master then create list and save
        //            PO.POCode = PORepo.getNewPurchaseOrderCode();
        //            PO.MainGroupID =
        //        }

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        Error = e;
        //        return false;
        //    }
        //}

        private bool isSupplierInList(List<string> UniqueSupplier, string Supplier)
        {
            foreach (var item in UniqueSupplier)
            {
                if (item == Supplier)
                {
                    return true;
                }
            }

            return false;
        }

        public List<SpotPurchasesaveDto> getSpotPurchaseApprovalList()
        {
            try
            {
                return repo.getSpotPurchaseApprovalList();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<SpotPurchasesaveDto> getSpotPOlistBySupplier(string SupplierID)
        {
            try
            {
                return repo.getSpotPOlistBySupplier(SupplierID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<SpotPurchaseSupplierDto> SpotPurchasesupplierList()
        {
            try
            {
                return repo.SpotPurchasesupplierList();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public object getSpotPurchaseReport(string pocode)
        {
            try
            {
                SpotPurchasesaveDto SPO = new SpotPurchasesaveDto();
                Inventory_Spot_Purchase PO = repo.getSpotPurchaseMasterForReport(pocode);
                if (PO == null)
                {
                    throw new Exception("PO ID not found");
                }

                //making the dto master model
                SPO = new SpotPurchaseMap().map(PO);

                List<Inventory_Spot_Purchase_Details> Details = repo.getSpotPurchaseDetailsForReport(PO.ID);
                List<SpotPurchaseDetailDto> PODetails = new List<SpotPurchaseDetailDto>();

                //making details data
                foreach (var item in Details)
                {
                    SpotPurchaseDetailDto data = new SpotPurchaseDetailDto();
                    data = new SpotPurchaseMap().Detailsmap(item);

                    var productItem = InventoryRepo.getInventoryItem(item.ItemID);
                    data.ItemName = productItem.ItemName;
                    data.ItemNameWithSpec = repo.getItemSpecification(item.RequisitionID, item.ItemID);
                    data.MainGroupName = repo.GetMainGroupsByReqID(item.RequisitionID);

                    var Supplier = SupplierRepo.getSupplierDetails(item.Supplier);
                    data.SupplierName = Supplier.SupplierName;

                    var Requisition = RequisitionRepo.getInventoryRequisition(item.RequisitionID);
                    data.RequisitionCode = Requisition.RequisitionCode;
                    data.InventoryType = Requisition.InventoryType;

                    PODetails.Add(data);
                }

                return new { SPO, PODetails };
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Spot_Purchase saveSpotPurchase(SpotPurchasesaveDto spotPurchase)
        {
            try
            {
                Inventory_Spot_Purchase PO = new Inventory_Spot_Purchase();
                PO.ID = spotPurchase.ID;
                PO.CreatedByID = spotPurchase.CreatedByID;
                PO.CreatedOn = DateTime.Now;
                PO.Discount = spotPurchase.Discount;
                PO.IsApproved = spotPurchase.IsApproved;
                PO.IsCanceled = spotPurchase.IsCanceled;
                PO.PurchaseDate = spotPurchase.PurchaseDate;
                PO.Remarks = spotPurchase.Remarks;
                PO.TotalPrice = spotPurchase.TotalPrice;
                PO.TotalAmount = spotPurchase.TotalAmount;
                PO.VATAmount = spotPurchase.VATAmount;

                Inventory_Spot_Purchase lastPO = repo.getLastSpotPurchase();

                if (lastPO == null)
                {
                    PO.PurchaseCode = "SPON-00001";
                }
                else
                {
                    PO.PurchaseCode = getPoCodeSerial(lastPO.PurchaseCode);
                }

                PO = repo.saveSpotPurchase(PO);

                List<Inventory_Spot_Purchase_Details> PODetails = JSONSerialize.getJSON<Inventory_Spot_Purchase_Details>(spotPurchase.PODetails);

                foreach (var item in PODetails)
                {
                    item.PurchaseID = PO.ID;
                    item.IsActive = true;
                    item.CreatedOn = DateTime.Now;
                    item.CreatedByID = PO.CreatedByID;
                    repo.saveSpotPurchaseDetails(item);
                }

                return PO;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        private string getPoCodeSerial(string LastPoCode)
        {
            string NewPoCode = string.Empty;
            string[] tokens = LastPoCode.Split('-');
            int NewSerial = Convert.ToInt32(tokens[1]);
            NewSerial++;
            int DigitCount = NewSerial.ToString().Length;

            if (DigitCount == 1)
            {
                NewPoCode = "SPON-0000" + NewSerial.ToString();
            }
            else if (DigitCount == 2)
            {
                NewPoCode = "SPON-000" + NewSerial.ToString();
            }
            else if (DigitCount == 3)
            {
                NewPoCode = "SPON-00" + NewSerial.ToString();
            }
            else if (DigitCount == 4)
            {
                NewPoCode = "SPON-0" + NewSerial.ToString();
            }
            else
            {
                NewPoCode = "SPON-" + NewSerial.ToString();
            }
            return NewPoCode;
        }
    }
}