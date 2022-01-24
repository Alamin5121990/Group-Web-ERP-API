using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.Data.Repository.InventoryNonProduction
{
    public class SpotPurchaseRepositories
    {
        public Inventory_Items getInventoryItem(int ItemId)
        {
            return new ProcurementGenericRepository<Inventory_Items>().Find(p => p.ID == ItemId).FirstOrDefault();
        }

        public Inventory_Item_SubGroup getInventoryItemSubgroup(int id)
        {
            return new ProcurementGenericRepository<Inventory_Item_SubGroup>().Find(p => p.ID == id).FirstOrDefault();
        }

        public Inventory_Spot_Purchase getLastSpotPurchase()
        {
            return new NonProductionGenericRepository<Inventory_Spot_Purchase>().Find(p => p.IsCanceled == false || p.IsCanceled == true).OrderByDescending(p => p.CreatedOn).FirstOrDefault();
        }

        public Inventory_Spot_Purchase getSpotPurchaseMasterForReport(string pocode)
        {
            return new NonProductionGenericRepository<Inventory_Spot_Purchase>().Find(p => p.PurchaseCode == pocode).FirstOrDefault();
        }

        public List<Inventory_Spot_Purchase_Details> getSpotPurchaseDetailsForReport(int POID)
        {
            return new NonProductionGenericRepository<Inventory_Spot_Purchase_Details>().Find(p => p.PurchaseID == POID && p.IsActive == true).ToList();
        }

        public List<SpotPurchasesaveDto> getSpotPOlistBySupplier(string SupplierID)
        {
            var Supplier = new SqlParameter("@SupplierID", SupplierID);

            return new NonProductionGenericRepository<SpotPurchasesaveDto>().FindUsingSP("getSpotPurchaseLisrBySupplier @SupplierID", Supplier).ToList();
        }

        public List<SpotPurchaseSupplierDto> SpotPurchasesupplierList()
        {
            return new NonProductionGenericRepository<SpotPurchaseSupplierDto>().FindUsingSP("getSupplierlistofSpotPurchase").ToList();
        }

        public List<SpotPurchasesaveDto> getSpotPurchaseApprovalList()
        {
            return new NonProductionGenericRepository<SpotPurchasesaveDto>().FindUsingSP("getSpotPurchaseForApproval").ToList();
        }

        public Inventory_Spot_Purchase saveSpotPurchase(Inventory_Spot_Purchase PO)
        {
            return new NonProductionGenericRepository<Inventory_Spot_Purchase>().Insert(PO);
        }

        public Inventory_Spot_Purchase updateSpotPurchase(Inventory_Spot_Purchase PO)
        {
            return new NonProductionGenericRepository<Inventory_Spot_Purchase>().Update(PO, p => p.ID == PO.ID);
        }

        public Inventory_Spot_Purchase_Details saveSpotPurchaseDetails(Inventory_Spot_Purchase_Details item)
        {
            return new NonProductionGenericRepository<Inventory_Spot_Purchase_Details>().Insert(item);
        }

        public Inventory_Spot_Purchase_Details updateSpotPurchaseDetails(Inventory_Spot_Purchase_Details item)
        {
            return new NonProductionGenericRepository<Inventory_Spot_Purchase_Details>().Update(item, i => i.ID == item.ID);
        }

        public List<Inventory_Spot_Purchase_Details> getSpotPurchaseDetails(int SPOID)
        {
            return new NonProductionGenericRepository<Inventory_Spot_Purchase_Details>().Find(i => i.PurchaseID == SPOID && i.IsActive == true);
        }

        public List<InventoryRequisitionsForSpotPurchase> getRequisitionsForSpotPurchase(int EmployeeID)
        {
            List<InventoryRequisitionsForSpotPurchase> reqlist = new List<InventoryRequisitionsForSpotPurchase>();

            using (ProcurementEntities db = new ProcurementEntities())
            {
                var employeeID = new SqlParameter("@EmployeeID", EmployeeID);
                reqlist = db.Database.SqlQuery<InventoryRequisitionsForSpotPurchase>("getInventoryRequisitionsForSpotPurchase @EmployeeID", employeeID).ToList();
            }

            foreach (var item in reqlist)
            {
                item.MainGroupName = GetMainGroupsByReqID(item.RequisitionID.GetValueOrDefault());
                item.InventoryType = getInventoryTypeByReqID(item.RequisitionID.GetValueOrDefault());
            }

            return reqlist;
        }

        public string getItemSpecification(int RequisitionID, int ItemID)
        {
            string specString = string.Empty;

            List<Inventory_Requisition_Item_Specifications> specs = new NonProductionGenericRepository<Inventory_Requisition_Item_Specifications>().Find(i => i.IsActive == true && i.RequisitionID == RequisitionID && i.ItemID == ItemID).ToList();
            foreach (var item in specs)
            {
                specString = specString + item.SpecificationName + " : " + item.SpecificationValue + ", ";
            }

            return specString;
        }

        private string getInventoryTypeByReqID(int ReqId)
        {
            string InventoryType = "";
            List<Inventory_Requisition_Items> reqitems = new ProcurementGenericRepository<Inventory_Requisition_Items>().Find(r => r.RequisitionID == ReqId).ToList();
            int itemid = Convert.ToInt32(reqitems[0].ItemID);
            Inventory_Items individialitem = new ProcurementGenericRepository<Inventory_Items>().Find(r => r.ID == itemid).FirstOrDefault();
            Inventory_Item_SubGroup subGroup = new ProcurementGenericRepository<Inventory_Item_SubGroup>().Find(r => r.ID == individialitem.SubGroupId).FirstOrDefault();
            Inventory_Item_MainGroup mainGroup = new ProcurementGenericRepository<Inventory_Item_MainGroup>().Find(r => r.ID == subGroup.MainGroupID).FirstOrDefault();
            Inventory_Types Inventory = new ProcurementGenericRepository<Inventory_Types>().Find(r => r.ID == mainGroup.InventoryTypeID).FirstOrDefault();

            if (Inventory != null)
            {
                return Inventory.TypeName;
            }
            return InventoryType;
        }

        public string GetMainGroupsByReqID(int ReqId)
        {
            string MainGroupNameString = "";

            List<Inventory_Item_MainGroup> mainGroups = new List<Inventory_Item_MainGroup>();

            List<Inventory_Requisition_Items> reqitems = new ProcurementGenericRepository<Inventory_Requisition_Items>().Find(r => r.RequisitionID == ReqId).ToList();
            foreach (var item in reqitems)
            {
                Inventory_Items individialitem = new ProcurementGenericRepository<Inventory_Items>().Find(r => r.ID == item.ItemID).FirstOrDefault();
                Inventory_Item_SubGroup subGroup = new ProcurementGenericRepository<Inventory_Item_SubGroup>().Find(r => r.ID == individialitem.SubGroupId).FirstOrDefault();
                Inventory_Item_MainGroup mainGroup = new ProcurementGenericRepository<Inventory_Item_MainGroup>().Find(r => r.ID == subGroup.MainGroupID).FirstOrDefault();
                mainGroups.Add(mainGroup);
            }

            foreach (var item in mainGroups)
            {
                if (MainGroupNameString == "")
                {
                    MainGroupNameString = item.GroupName;
                }
                else
                {
                    if (!MainGroupNameString.Contains(item.GroupName))
                        MainGroupNameString = MainGroupNameString + ", " + item.GroupName;
                }
            }
            return MainGroupNameString.TrimEnd(',');
        }
    }
}