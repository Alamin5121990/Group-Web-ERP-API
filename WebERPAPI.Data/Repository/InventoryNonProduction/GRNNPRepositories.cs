using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.PurchaseOrdersNP;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.Data.Repository.InventoryNonProduction
{
    public class GRNNPRepositories
    {
        private ProcurementGenericRepository<Inventory_GRN> GRNMaster = null;
        private ProcurementGenericRepository<Inventory_GRN_Items> GRNDetails = null;

        // QRN
        private ProcurementGenericRepository<Inventory_QRN> QRNMaster = null;

        private ProcurementGenericRepository<Inventory_QRN_Items> QRNDetails = null;

        public GRNNPRepositories()
        {
            GRNMaster = new ProcurementGenericRepository<Inventory_GRN>();
            GRNDetails = new ProcurementGenericRepository<Inventory_GRN_Items>();

            // QRN
            QRNMaster = new ProcurementGenericRepository<Inventory_QRN>();
            QRNDetails = new ProcurementGenericRepository<Inventory_QRN_Items>();
        }

        public Inventory_GRN saveGRN(Inventory_GRN GRNData, List<GRNNewItemsDTO> grnItems)
        {
            //check GIFT or PPM item then approve GRN autometic
            int itemID = grnItems[0].ItemID;
            Inventory_Items item = new ProcurementGenericRepository<Inventory_Items>().Find(i => i.ID == itemID).FirstOrDefault();
            Inventory_Item_SubGroup subGroup = new ProcurementGenericRepository<Inventory_Item_SubGroup>().Find(s => s.ID == item.SubGroupId && s.IsActive == true).FirstOrDefault();
            Inventory_Item_MainGroup mainGroup = new ProcurementGenericRepository<Inventory_Item_MainGroup>().Find(m => m.ID == subGroup.MainGroupID && m.IsActive == true).FirstOrDefault();

            if (mainGroup.GroupName == "Gift" || mainGroup.GroupName == "Printing")
            {
                GRNData.IsApproved = true;
            }

            string GRNCode = getNewGRNCode();

            if (string.IsNullOrEmpty(GRNCode)) throw new Exception("Failed to generate GRN code. Please try again.");

            GRNData.GRNCode = GRNCode;
            GRNData.IsActive = true;
            GRNData.CreatedOn = DateTime.Now;
            return GRNMaster.Insert(GRNData);
        }

        public Inventory_GRN updatePurchaseOrder(int GRNID, Inventory_GRN GRNData)
        {
            return GRNMaster.Update(GRNData, p => p.ID == GRNID);
        }

        //grn approve
        public Inventory_GRN approveGRN(string EmpID, string GRNcode)
        {
            Inventory_GRN grn = new ProcurementGenericRepository<Inventory_GRN>().Find(g => g.GRNCode == GRNcode && g.IsActive == true).FirstOrDefault();

            if (grn != null)
            {
                grn.IsApproved = true;
                grn.ApprovedOn = DateTime.Now;
                grn.ApprovedByID = EmpID;
                return new ProcurementGenericRepository<Inventory_GRN>().Update(grn, g => g.ID == grn.ID);
            }
            else
            {
                return null;
            }
        }

        public Boolean saveGRNDetails(Inventory_GRN_Items Details)
        {
            GRNDetails.Insert(Details);
            return true;
        }

        private string getNewGRNCode()
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                int count = 0;
                string GRNCode = "";
                DateTime monthFirstDate = DateTime.Now.AddDays(-(DateTime.Now.Day));

                int csNo = db.Inventory_GRN.Where(q => q.CreatedOn >= monthFirstDate).Count();
                csNo++;

                while (count < 9999)
                {
                    if (csNo < 10) GRNCode = "GRN-" + DateTime.Now.ToString("yyMM") + "000" + csNo.ToString();
                    else if (csNo < 100) GRNCode = "GRN-" + DateTime.Now.ToString("yyMM") + "00" + csNo.ToString();
                    else if (csNo < 1000) GRNCode = "GRN-" + DateTime.Now.ToString("yyMM") + "0" + csNo.ToString();
                    else GRNCode = "GRN-" + DateTime.Now.ToString("yyMM") + csNo.ToString();

                    if (db.Inventory_GRN.Where(i => i.GRNCode == GRNCode).FirstOrDefault() == null) return GRNCode;

                    csNo++;
                    count++;
                }

                return GRNCode;
            }
        }

        public List<GRNPendingNP> getGRNPending()
        {
            return new NonProductionGenericRepository<GRNPendingNP>().FindUsingSP("getGRNPendingNP ");
        }

        public List<GRNPendingNP> getGRNPendingForApproveNP()
        {
            return new NonProductionGenericRepository<GRNPendingNP>().FindUsingSP("getGRNPendingForApproveNP ");
        }

        public List<GRNPendingNP> getGRNStatusReport()
        {
            return new NonProductionGenericRepository<GRNPendingNP>().FindUsingSP("getGRNPendingNP ");
        }

        public GRNNPDTO getGRNNP(string GRNCode, int GRNID)
        {
            var grnData = new NonProductionGenericRepository<GRNNPDTO>().FindOneUsingSP("getGRNNP @GRNCode, @GRNID", new SqlParameter("@GRNCode", GRNCode), new SqlParameter("@GRNID", GRNID));
            return grnData;
        }

        public List<GRNDetailsNPDTO> getGRNDetails(string GRNCode, int GRNID)
        {
            return new NonProductionGenericRepository<GRNDetailsNPDTO>().FindUsingSP("getGRNDetailsNP @GRNCode, @GRNID"
                , new SqlParameter("@GRNCode", GRNCode), new SqlParameter("@GRNID", GRNID));
        }

        // QRN

        //update inventory stock after QRN save
        public SingleValueInt updateInventoryStock(int StoreID, int ItemID, int StockUpdateTypeID, int QRNID, int ConsumptionRequisitionID, decimal Quantity, string EmployeeID, string Remarks)
        {
            return new ProcurementGenericRepository<SingleValueInt>().FindOneUsingSP("updateInventoryStock @StoreID, @ItemID, @StockUpdateTypeID, @QRNID, @ConsumptionRequisitionID, @Quantity, @EmployeeID, @Remarks",
                new SqlParameter("@StoreID", StoreID),
                new SqlParameter("@ItemID", ItemID),
                new SqlParameter("@StockUpdateTypeID", StockUpdateTypeID),
                new SqlParameter("@QRNID", QRNID),
                new SqlParameter("@ConsumptionRequisitionID", ConsumptionRequisitionID),
                new SqlParameter("@Quantity", Quantity),
                new SqlParameter("@EmployeeID", EmployeeID),
                new SqlParameter("@Remarks", Remarks));
        }

        public Inventory_QRN saveQRN(Inventory_QRN QRNData)
        {
            QRNData.IsActive = true;
            QRNData.CreatedOn = DateTime.Now;
            return QRNMaster.Insert(QRNData);
        }

        public Inventory_QRN updateQRN(int GRNID, Inventory_QRN GRNData)
        {
            return QRNMaster.Update(GRNData, p => p.ID == GRNID);
        }

        public Boolean saveQRNDetails(Inventory_QRN_Items Details)
        {
            QRNDetails.Insert(Details);
            return true;
        }

        // User Stores

        public Inventory_UserStores saveUserStore(Inventory_UserStores UserStore)
        {
            UserStore.CreatedOn = DateTime.Now;
            if (UserStore.IsIncharge == true) UserStore.IsActive = true;
            return new GRNStockGenericRepository<Inventory_UserStores>().Insert(UserStore);
        }

        public Inventory_UserStores updateUserStore(int ID, Inventory_UserStores UserStore)
        {
            UserStore.UpdatedOn = DateTime.Now;
            return new GRNStockGenericRepository<Inventory_UserStores>().Update(UserStore, (s => s.ID == ID));
        }

        public Inventory_UserStores getUserStore(string EmployeeCode, int StoreID)
        {
            return new GRNStockGenericRepository<Inventory_UserStores>().FindOne(s => s.EmployeeCode == EmployeeCode && s.StoreID == StoreID && s.IsActive == true);
        }

        public List<UserStoresDTO> getUserStores(string EmployeeCode, int ShowAll)
        {
            return new GRNStockGenericRepository<UserStoresDTO>().FindUsingSP("getInventoryUserStores @EmployeeID, @ShowAll",
                new SqlParameter("@EmployeeID", EmployeeCode), new SqlParameter("@ShowAll", ShowAll));
        }

        public List<GRNStatusReportNPDTO> getGRNStatusReportNP(string SupplierCode, string DateFrom, string DateTo)
        {
            return new GRNStockGenericRepository<GRNStatusReportNPDTO>().FindUsingSP("getGRNStatusReportNP @SupplierCode, @DateFrom, @DateTo",
               new SqlParameter("@SupplierCode", SupplierCode), new SqlParameter("@DateFrom", DateFrom), new SqlParameter("@DateTo", DateTo));
        }

        public List<PurchaseOrderGRNsNPDTO> getPurchaseOrderGRNList(string POCode, int POID)
        {
            return new GRNStockGenericRepository<PurchaseOrderGRNsNPDTO>().FindUsingSP("getPurchaseOrderGRNsNP @POCode, @POID",
                new SqlParameter("@POCode", POCode), new SqlParameter("@POID", POID));
        }

        public Inventory_GRN getGRNByCode(string GRNcode)
        {
            return new GRNStockGenericRepository<Inventory_GRN>().Find(g => g.GRNCode == GRNcode && g.IsActive == true).FirstOrDefault();
        }

        public Inventory_GRN updateGRN(Inventory_GRN grn)
        {
            return new GRNStockGenericRepository<Inventory_GRN>().Update(grn, i => i.ID == grn.ID);
        }

        public List<PurchaseOrderNPDto> getPurchaseOrderForGRN(string EmployeeID, string SearchText)
        {
            SearchText = Library.JSONSerialize.DecodeBase64(SearchText);
            return new NonProductionGenericRepository<PurchaseOrderNPDto>().FindUsingSP("getPurchaseOrderForGRNNP @EmployeeID, @SearchText",
                new SqlParameter("@EmployeeID", EmployeeID), new SqlParameter("@SearchText", SearchText));
        }
    }
}