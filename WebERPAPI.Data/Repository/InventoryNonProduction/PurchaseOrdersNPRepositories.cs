using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.ComparativeStudyNP;
using WebERPAPI.DTO.Inventory.PurchaseOrdersNP;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.Data.Repository.InventoryNonProduction
{
    public class PurchaseOrdersNPRepositories
    {
        private NonProductionGenericRepository<Inventory_Purchase_Orders> POMaster = null;
        private NonProductionGenericRepository<Inventory_Purchase_Order_Detail> PODetails = null;

        public PurchaseOrdersNPRepositories()
        {
            POMaster = new NonProductionGenericRepository<Inventory_Purchase_Orders>();
            PODetails = new NonProductionGenericRepository<Inventory_Purchase_Order_Detail>();
        }


        //START PURCHASE ORDER ADVANCE PAYMENT REPOSITOTY
        public List<DTO.InventoryNonProduction.InventoryPurchaseOrderAdvancePaidDTO> getAdvancePaymentListByPoCode(string PoCode)
        {
            List<DTO.InventoryNonProduction.InventoryPurchaseOrderAdvancePaidDTO> PaymentDTOlist = new List<DTO.InventoryNonProduction.InventoryPurchaseOrderAdvancePaidDTO>();
            var paymentlist = new NonProductionGenericRepository<Inventory_Purchase_Order_AdvancePaid>().Find(p => p.POID == PoCode && p.IsCanceled != true).ToList();
            if (paymentlist.Count == 0)
            {
                return new List<DTO.InventoryNonProduction.InventoryPurchaseOrderAdvancePaidDTO>();
            }

            foreach (var item in paymentlist)
            {
                DTO.InventoryNonProduction.InventoryPurchaseOrderAdvancePaidDTO listitem = new DTO.InventoryNonProduction.InventoryPurchaseOrderAdvancePaidDTO();
                listitem.ID = item.ID;
                listitem.IsUrgent = item.IsUrgent;
                listitem.POID = item.POID;
                listitem.Remarks = item.Remarks;
                listitem.SupplierCode = item.SupplierCode;
                listitem.CreatedByID = item.CreatedByID;
                listitem.CreatedOn = item.CreatedOn;
                listitem.UpdatedByID = item.UpdatedByID;
                listitem.UpdatedOn = item.UpdatedOn;
                listitem.AdvancePercent = item.AdvancePercent;
                listitem.AdvanceAmount = item.AdvanceAmount;

                //CREATED BY NAME LOADING TO DTO
                if (item.CreatedByID != null && item.CreatedByID != string.Empty && item.CreatedByID != "")
                    listitem.CreatedBy = new HRMSGenericRepository<Employee>().Find(e => e.EmployeeID == item.CreatedByID).FirstOrDefault().EmployeeName;

                //UPDATED BY NAMEM LOADING TO DTP
                if (item.UpdatedByID != null && item.UpdatedByID != string.Empty && item.UpdatedByID != "")
                    listitem.UpdatedBy = new HRMSGenericRepository<Employee>().Find(e => e.EmployeeID == item.UpdatedByID).FirstOrDefault().EmployeeName;

                PaymentDTOlist.Add(listitem);
            }

            return PaymentDTOlist;
        }

        public Inventory_Purchase_Order_AdvancePaid saveUpdateAdvancePayment(Inventory_Purchase_Order_AdvancePaid POData)
        {
            Inventory_Purchase_Order_AdvancePaid ir = new NonProductionGenericRepository<Inventory_Purchase_Order_AdvancePaid>().Find(p => p.ID == POData.ID).FirstOrDefault();

            if (ir != null)
            {
                return new NonProductionGenericRepository<Inventory_Purchase_Order_AdvancePaid>().Update(POData, p => p.ID == POData.ID);
            }

            return new NonProductionGenericRepository<Inventory_Purchase_Order_AdvancePaid>().Insert(POData);
        }

        public Inventory_Purchase_Order_AdvancePaid getAdvancePaymentByIdAndPocode(int id, string pocode)
        {
            return new NonProductionGenericRepository<Inventory_Purchase_Order_AdvancePaid>().Find(i => i.ID == id && i.POID == pocode).FirstOrDefault();
        }

        //END PURCHASE ORDER ADVANCE PAYMENT

        public Inventory_Purchase_Orders savePurchaseOrder(Inventory_Purchase_Orders POData, int RequisitionID)
        {
            string POCode = getNewPurchaseOrderCode();

            if (string.IsNullOrEmpty(POCode)) throw new Exception("Failed to generate Purchase order code. Please try again.");

            POData.POCode = POCode;
            POData.CreatedOn = DateTime.Now;
            //adding carrying cast with total
            if (POData.CarryingCost != null && POData.CarryingCost > 0)
            {
                POData.TotalAmount = POData.TotalAmount + POData.CarryingCost;
            }

            //adding labour cast with total
            if (POData.LabourCost != null && POData.LabourCost > 0)
            {
                POData.TotalAmount = POData.TotalAmount + POData.LabourCost;
            }
            //adding other cost with total
            if (POData.OtherCost != null && POData.LabourCost > 0)
            {
                POData.TotalAmount = POData.TotalAmount + POData.OtherCost;
            }
            Inventory_Requisitions req = new ProcurementGenericRepository<Inventory_Requisitions>().Find(r => r.ID == RequisitionID).FirstOrDefault();
            if (req == null)
            {
                throw new Exception("Requisition ID not found.");
            }
            POData.InventoryTypeID = req.InventoryTypeID;
            return POMaster.Insert(POData);
        }

        public Inventory_Purchase_Orders updatePurchaseOrder(int POID, Inventory_Purchase_Orders POData)
        {
            //adding carrying cast with total
            if (POData.CarryingCost != null && POData.CarryingCost > 0)
            {
                POData.TotalAmount = POData.TotalAmount + POData.CarryingCost;
            }

            //adding labour cast with total
            if (POData.LabourCost != null && POData.LabourCost > 0)
            {
                POData.TotalAmount = POData.TotalAmount + POData.LabourCost;
            }
            return POMaster.Update(POData, p => p.ID == POID);
        }

        public Boolean savePurchaseOrderDetails(Inventory_Purchase_Order_Detail Details)
        {
            PODetails.Insert(Details);
            return true;
        }

        public Inventory_Purchase_Orders getExistingPurchaseOrder(int RequisitionID)
        {
            Inventory_Purchase_Order_Detail POD = PODetails.FindOne(
                    p => p.RequisitionID == RequisitionID
                    && p.IsActive == true
                );

            if (POD == null) return null;
            return POMaster.FindOne(p => p.ID == POD.POID && p.IsCanceled == false);
        }

        public string getNewPurchaseOrderCode()
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                int count = 0;
                string POCode = "";
                DateTime monthFirstDate = DateTime.Now.AddDays(-(DateTime.Now.Day));

                int csNo = db.Inventory_Purchase_Orders.Where(q => q.CreatedOn >= monthFirstDate).Count();
                csNo++;

                while (count < 999)
                {
                    if (csNo < 10) POCode = "PON-" + DateTime.Now.ToString("yyMM") + "00" + csNo.ToString();
                    else if (csNo < 100) POCode = "PON-" + DateTime.Now.ToString("yyMM") + "0" + csNo.ToString();
                    //else if (csNo < 1000) POCode = "PON-" + DateTime.Now.ToString("yyMM") + "0" + csNo.ToString();
                    else POCode = "PON-" + DateTime.Now.ToString("yyMM") + csNo.ToString();

                    if (db.Inventory_Purchase_Orders.Where(i => i.POCode == POCode).FirstOrDefault() == null) return POCode;

                    csNo++;
                    count++;
                }

                return POCode;
            }
        }
        public List<PurcaseOrderBillReportDto> getPurchaseOrderSupplierListForBillReport()
        {
            return new NonProductionGenericRepository<PurcaseOrderBillReportDto>().FindUsingSP("getSupplierForPOReport ");

           
        }
        public List<POBillDetailsforPOReportDto> getPurchaseOrderBillDetailsBySuppliers(string SupplierId)
        {
            return new NonProductionGenericRepository<POBillDetailsforPOReportDto>()
                    .FindUsingSP("getPOBillDetailsforPOReport  @SupplierId",
                    new SqlParameter("@SupplierId", SupplierId));
        }
        public List<ComparativeStudySuppliersNP> getComparativeStudySuppliersNP(string EmployeeCode)
        {
            return new NonProductionGenericRepository<ComparativeStudySuppliersNP>()
                    .FindUsingSP("getComparativeStudySuppliersNP  @EmployeeCode",
                    new SqlParameter("@EmployeeCode", EmployeeCode));
        }

        public List<ComparativeStudyForPurchaseNP> getComparativeStudyForPurchaseNP(int MainGroupID, string SupplierCode)
        {
            return new NonProductionGenericRepository<ComparativeStudyForPurchaseNP>()
                    .FindUsingSP("getComparativeStudyForPurchaseNP @MainGroupID, @SupplierCode",
                    new SqlParameter("@MainGroupID", MainGroupID), new SqlParameter("@SupplierCode", SupplierCode));
        }
        public CheckCancelledList saveCancelledCheck(CheckCancelledList Entity)
        {
            return new NonProductionGenericRepository<CheckCancelledList>().Insert(Entity);
        }
        public Inventory_Purchase_Orders updatePurchaseOrderStatus(CommonDataEntryClass POData)
        {
            Inventory_Purchase_Orders po = POMaster.FindOne(p => p.ID == POData.ID);

            if (po != null)
            {
                if (POData.ActionGroupID == ActionGroup.CANCELED)
                {
                    po.IsCanceled = true;

                    po.CanceledReason = POData.Remarks;
                    po.CanceledByID = POData.EmployeeCode;
                    po.CanceledOn = DateTime.Now;
                }
                else if (POData.ActionGroupID == ActionGroup.VERIFIED)
                {
                    po.IsVerified = true;

                    po.VerifiedRemarks = POData.Remarks;
                    po.VerifiedByID = POData.EmployeeCode;
                    po.VerifiedOn = DateTime.Now;
                }
                else if (POData.ActionGroupID == ActionGroup.CLOSED)
                {
                    po.IsClosed = true;

                    po.ClosedRemarks = POData.Remarks;
                    po.ClosedByID = POData.EmployeeCode;
                    po.ClosedOn = DateTime.Now;
                }

                POMaster.Update(po, p => p.ID == POData.ID);
            }

            return po;
        }

        public Boolean cancelAllExistingPODetails(int POID, string EmployeeID)
        {
            using (NonProductionCSEntities db = new NonProductionCSEntities())
            {
                List<Inventory_Purchase_Order_Detail> PODetails = db.Inventory_Purchase_Order_Detail.Where(q => q.POID == POID && q.IsActive == true).ToList();

                foreach (Inventory_Purchase_Order_Detail pod in PODetails)
                {
                    if (pod != null)
                    {
                        pod.IsActive = false;
                        pod.UpdatedByID = EmployeeID;
                        pod.UpdatedOn = DateTime.Now;
                        db.SaveChanges();
                    }
                }
                return true;
            }
        }

        public List<ComparativeStudyItemsForPurchaseOrderNP> getComparativeStudyItemsForPurchaseOrder(int CSID, string SupplierCode)
        {
            return new NonProductionGenericRepository<ComparativeStudyItemsForPurchaseOrderNP>()
                    .FindUsingSP("getComparativeStudyItemsForPurchaseOrderNP @CSID, @SupplierCode",
                    new SqlParameter("@CSID", CSID), new SqlParameter("@SupplierCode", SupplierCode));
        }

        public Inventory_Purchase_Order_Detail getPurchaseOrderDetails(int RequisitionID, int ItemID)
        {
            return PODetails.FindOne(
                        p => p.RequisitionID == RequisitionID
                        && p.ItemID == ItemID
                        && p.IsActive == true
                    );
        }

        public Inventory_Purchase_Orders getPurchaseOrder(int RequisitionID, int ItemID)
        {
            Inventory_Purchase_Order_Detail POD = getPurchaseOrderDetails(RequisitionID, ItemID);
            if (POD == null) return null;
            return POMaster.FindOne(p => p.ID == POD.POID);
        }

        public Inventory_Purchase_Orders getPurchaseOrder(int POID)
        {
            return POMaster.FindOne(p => p.ID == POID);
        }

        public Inventory_Purchase_Orders getPurchaseOrderToday(int RequisitionID, int ItemID)
        {
            DateTime today = Scripting.getTodaysDateOnly();
            Inventory_Purchase_Order_Detail POD = PODetails.FindOne(
                    p => p.RequisitionID == RequisitionID
                    && p.ItemID == ItemID
                    && p.IsActive == true
                    && p.CreatedOn >= today
                );
            if (POD == null) return null;
            return POMaster.FindOne(p => p.ID == POD.POID);
        }

        public List<PurchaseOrdersNPToVerifyDTO> getPurchaseOrderToVerify()
        {
            return new NonProductionGenericRepository<PurchaseOrdersNPToVerifyDTO>().FindUsingSP("getPurchaseOrdersToVerify ");
        }

        public Inventory_Purchase_Orders getPurchaseOrderByPOID(int POID)
        {
            return new NonProductionGenericRepository<Inventory_Purchase_Orders>().Find(p => p.ID == POID).FirstOrDefault();
        }

        public PurchaseOrderNPDto getPurchaseOrderNP(string POCode, int POID)
        {
            return new NonProductionGenericRepository<PurchaseOrderNPDto>()
                .FindOneUsingSP("getPurchaseOrderNP @POCode, @POID"
                , new SqlParameter("@POCode", POCode), new SqlParameter("@POID", POID));
        }

        public List<PurchaseOrderDetailsNP> getPurchaseOrderDetailsNP(int POID)
        {
            return new NonProductionGenericRepository<PurchaseOrderDetailsNP>()
                .FindUsingSP("getPurchaseOrderDetailsNP  @POID", new SqlParameter("@POID", POID));
        }

        public PurchaseOrderSignaturesNPDTO getPurchaseOrderSignatureNP(string POCode, int POID)
        {
            return new NonProductionGenericRepository<PurchaseOrderSignaturesNPDTO>()
                .FindOneUsingSP("getPurchaseOrderSignaturesNP @POCode, @POID"
                , new SqlParameter("@POCode", POCode), new SqlParameter("@POID", POID));
        }

        public List<nonPSupplierListOfAllPODto> getPurchaseOrderSupplierList()
        {
            return new NonProductionGenericRepository<nonPSupplierListOfAllPODto>().FindUsingSP("getnonPSupplierListOfAllPO");
        }

        public List<PurchaseOrderNPDto> getPurchaseOrderStatusReport(string DateFrom, string DateTo, int InventoryTypreID, string SupplierCode, string SearchText)
        {
            SearchText = SearchText.Trim();
            return new NonProductionGenericRepository<PurchaseOrderNPDto>()
               .FindUsingSP("getPurchaseOrderStatusReportNP @DateFrom, @DateTo, @InventoryTypeID, @SupplierCode, @SearchText"
               , new SqlParameter("@DateFrom", DateFrom)
               , new SqlParameter("@DateTo", DateTo)
               , new SqlParameter("@InventoryTypeID", InventoryTypreID)
               , new SqlParameter("@SupplierCode", SupplierCode)
               , new SqlParameter("@SearchText", SearchText));
        }

        public List<Inventory_Purchase_Order_Detail> getPurchaseOrderItemListByPoid(int POID)
        {
            return new NonProductionGenericRepository<Inventory_Purchase_Order_Detail>().Find(i => i.POID == POID && i.IsActive == true).ToList();
        }
    }
}