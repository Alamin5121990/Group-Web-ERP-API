using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.Inventory;
using WebERPAPI.Data.GenericRepository;
using System.Data.Entity.Migrations;

namespace WebERPAPI.Data.Repository.InventoryNonProduction
{
    public class RequisitionNPRepositories
    {
        private ProcurementGenericRepository<Inventory_Requisitions> _requisition = null;
        private ProcurementGenericRepository<Inventory_Requisition_Items> _requisitionDetails = null;

        public RequisitionNPRepositories()
        {
            _requisition = new ProcurementGenericRepository<Inventory_Requisitions>();
            _requisitionDetails = new ProcurementGenericRepository<Inventory_Requisition_Items>();
        }

        /// --------------------
        /// NEW REQUISITION
        /// --------------------

        public Inventory_Requisitions createInventoryRequisition(InventoryRequisitionNew Data, List<InventoryRequisitionItems> items)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                if (Data.ID == null) Data.ID = 0;

                Inventory_Requisitions ir = db.Inventory_Requisitions.Where(o => o.ID == Data.ID).FirstOrDefault();

                if (ir == null)
                {
                    //SAVE NEW InventoryRequisitions

                    string RequisitionCode = getRequisitionCode(items[0].MainGroupID.GetValueOrDefault());

                    if (string.IsNullOrEmpty(RequisitionCode))
                    {
                        throw new Exception("Failed to generate requisition code. Please try again.");
                    }

                    Inventory_Requisitions newir = new Inventory_Requisitions();

                    newir.RequisitionCode = RequisitionCode;
                    newir.InventoryTypeID = Data.InventoryTypeID;
                    newir.StoreID = Data.StoreID;
                    newir.RequisitionTypeID = Data.RequisitionTypeID;
                    newir.Remarks = Data.Remarks;
                    newir.TermAndCondition = Data.TermAndCondition;

                    newir.CreatedOn = DateTime.Now;
                    newir.CreatedByID = Data.EmployeeID;

                    db.Inventory_Requisitions.Add(newir);
                    db.SaveChanges();

                    return newir;
                }
                else
                {
                    // UPDATE InventoryRequisitions

                    ir.InventoryTypeID = Data.InventoryTypeID;
                    ir.StoreID = Data.StoreID;
                    ir.RequisitionTypeID = Data.RequisitionTypeID;
                    ir.Remarks = Data.Remarks;

                    ir.UpdatedOn = DateTime.Now;
                    ir.UpdatedByID = Data.EmployeeID;

                    db.SaveChanges();
                }

                return ir;
            }
        }

        public Inventory_Requisitions updateInventoryRequisition(InventoryRequisitionNew Data)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                Inventory_Requisitions ir = db.Inventory_Requisitions.Where(o => o.ID == Data.ID).FirstOrDefault();
                if (ir == null) return null;
                else
                {
                    // UPDATE InventoryRequisitions

                    ir.InventoryTypeID = Data.InventoryTypeID;
                    ir.StoreID = Data.StoreID;
                    ir.RequisitionTypeID = Data.RequisitionTypeID;
                    if (!string.IsNullOrEmpty(Data.Remarks)) ir.Remarks = Data.Remarks;

                    ir.UpdatedOn = DateTime.Now;
                    ir.UpdatedByID = Data.EmployeeID;

                    db.SaveChanges();
                }

                return ir;
            }
        }

        public Inventory_Requisitions updateInventoryRequisitionForCancel(Inventory_Requisitions req)
        {
            return new ProcurementGenericRepository<Inventory_Requisitions>().Update(req, i => i.ID == req.ID);
        }

        public Boolean saveRequisitionMonths(int RequisitionID, InventoryRequisitionNew NewReq)
        {
            try
            {
                if (string.IsNullOrEmpty(NewReq.Months)) return false;

                // Removing existing months if update
                using (ProcurementEntities db = new ProcurementEntities())
                {
                    List<Inventory_Requisition_For_Months> forMonths = db.Inventory_Requisition_For_Months.Where(m => m.RequisitionID == RequisitionID).ToList();
                    if (forMonths != null && forMonths.Count > 0)
                    {
                        db.Inventory_Requisition_For_Months.RemoveRange(forMonths);
                        db.SaveChanges();
                    }
                }
            }
            catch { }

            // Saving new

            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                string[] Months = NewReq.Months.Split(';');
                foreach (string month in Months)
                {
                    if (string.IsNullOrEmpty(month)) continue;

                    string[] st = month.Split(',');
                    int MonthNo = Scripting.getMonthNumberFromMonthYear(month, ',');
                    int YearNo = Scripting.valueInt(st[1]);

                    Inventory_Requisition_For_Months newMonth = new Inventory_Requisition_For_Months();

                    newMonth.RequisitionID = RequisitionID;
                    newMonth.ForDate = new DateTime(YearNo, MonthNo, 1);

                    db.Inventory_Requisition_For_Months.Add(newMonth);
                    db.SaveChanges();
                }

                return true;
            }
        }

        public Boolean saveRequisitionBrands(int RequisitionID, InventoryRequisitionNew NewReq)
        {
            try
            {
                if (string.IsNullOrEmpty(NewReq.BrandIds)) return false;

                // Removing existing brands if update
                using (ProcurementEntities db = new ProcurementEntities())
                {
                    List<Inventory_Requisition_For_Brands> forBrands = db.Inventory_Requisition_For_Brands.Where(m => m.RequisitionID == RequisitionID).ToList();
                    if (forBrands != null && forBrands.Count > 0)
                    {
                        db.Inventory_Requisition_For_Brands.RemoveRange(forBrands);
                        db.SaveChanges();
                    }
                }
            }
            catch { }

            // Saving new

            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                string[] BrandIds = NewReq.BrandIds.Split(';');
                foreach (string brandid in BrandIds)
                {
                    if (string.IsNullOrEmpty(brandid)) continue;

                    Inventory_Requisition_For_Brands newBrand = new Inventory_Requisition_For_Brands();

                    newBrand.RequisitionID = RequisitionID;
                    newBrand.BrandID = Scripting.valueInt(brandid);

                    db.Inventory_Requisition_For_Brands.Add(newBrand);
                    db.SaveChanges();
                }

                return true;
            }
        }

        public Boolean deleteExistingRequisitionDetails(int RequisitionID, string EmployeeID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<Inventory_Requisition_Items> Details = db.Inventory_Requisition_Items.Where(r => r.RequisitionID == RequisitionID && r.IsActive == true).ToList();

                foreach (Inventory_Requisition_Items detail in Details)
                {
                    deleteRequisitionItem(RequisitionID, detail.ItemID.GetValueOrDefault(), EmployeeID);
                }

                return true;
            }
        }

        public Inventory_Requisition_Items deleteRequisitionItem(int RequisitionID, int ItemID, string EmployeeID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                Inventory_Requisition_Items details = db.Inventory_Requisition_Items.FirstOrDefault(r => r.RequisitionID == RequisitionID && r.ItemID == ItemID && r.IsActive == true);

                if (details != null)
                {
                    details.IsActive = false;
                    details.UpdatedById = EmployeeID;
                    details.UpdatedOn = DateTime.Now;

                    db.SaveChanges();
                }
                else return details;

                return details;
            }
        }

        private string getRequisitionCode(int MainGroupId)
        {
            string RequisitionCode = "";
            int LastRequisitionNo = 0, ThisRequisitionNo = 0;

            Inventory_Item_MainGroup mainGroup = new ProcurementGenericRepository<Inventory_Item_MainGroup>().Find(m => m.ID == MainGroupId).FirstOrDefault();
            if (mainGroup == null) return "";
            Inventory_Types inventoryTypes = new ProcurementGenericRepository<Inventory_Types>().Find(m => m.ID == mainGroup.InventoryTypeID).FirstOrDefault();
            if (inventoryTypes == null) return "";

            if (inventoryTypes.CodePrefix == null) inventoryTypes.CodePrefix = "PR";
            //getting the latest reqisition
            Inventory_Requisitions LastRequisition = new ProcurementGenericRepository<Inventory_Requisitions>().FindUsingSP("getLatestRequisition @Prefix", new SqlParameter("@Prefix", inventoryTypes.CodePrefix)).FirstOrDefault();

            if (LastRequisition != null)
            {
                try
                {
                    LastRequisitionNo = Convert.ToInt32(LastRequisition.RequisitionCode.Substring(LastRequisition.RequisitionCode.Length - 4));
                    ThisRequisitionNo = ++LastRequisitionNo;
                }
                catch
                {
                    ThisRequisitionNo = 0;
                }
            }
            RequisitionCode = inventoryTypes.CodePrefix + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + ThisRequisitionNo.ToString("D4");

            return RequisitionCode;
        }

        public Boolean saveInventoryRequisitionDetails(Inventory_Requisitions Requisition, InventoryRequisitionItems Item)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                // Finding existing  InventoryRequisitionItems

                Inventory_Requisition_Items iri = db.Inventory_Requisition_Items.Where(i => i.RequisitionID == Requisition.ID
                    && i.ItemID == Item.ItemID && i.Quantity == Item.Quantity).FirstOrDefault();

                if (iri == null)
                {
                    //SAVE NEW InventoryRequisitionItems

                    Inventory_Requisition_Items newiri = new Inventory_Requisition_Items();

                    newiri.RequisitionID = Requisition.ID;
                    newiri.ItemID = Item.ItemID;
                    newiri.Purpose = Item.Purpose;
                    newiri.OrderNo = Item.OrderNo;
                    newiri.VersionID = Item.VersionID;
                    newiri.IsActive = true;
                    newiri.Quantity = Item.Quantity;
                    newiri.DeliveryDate = Item.DeliveryDate;
                    newiri.CreatedOn = DateTime.Now;
                    newiri.TotalPrice = Item.TotalPrice;
                    db.Inventory_Requisition_Items.Add(newiri);
                    db.SaveChanges();

                    //if (newiri.ID > 0)
                    //{
                    //    RequisitionItemSpecificationInsert(Requisition, Item, newiri.ID);
                    //    return true;
                    //}

                    return true;
                }
                else
                {
                    // UPDATE InventoryRequisitionItems

                    iri.RequisitionID = Requisition.ID;
                    iri.ItemID = Item.ItemID;
                    iri.Purpose = Item.Purpose;
                    iri.OrderNo = Item.OrderNo;
                    iri.VersionID = Item.VersionID;
                    iri.TotalPrice = Item.TotalPrice;
                    iri.IsActive = true;
                    iri.Quantity = Item.Quantity;
                    iri.DeliveryDate = Item.DeliveryDate;
                    iri.UpdatedById = Requisition.UpdatedByID;
                    iri.UpdatedOn = Requisition.UpdatedOn;
                    //db.Inventory_Requisition_Items.AddOrUpdate(iri);
                    db.SaveChanges();

                    //Update Spec
                    //RequisitionItemSpecificationInsert(Requisition, Item, Convert.ToInt32(iri.ID));

                    return true;
                }
            }
        }

        public bool RequisitionItemSpecificationInsert(Inventory_Requisitions Requisition, InventoryRequisitionItems Item, int RItemID)
        {
            //first delete if any existing specifications for requisition id and item id
            List<Inventory_Requisition_Item_Specifications> existingspecs = new NonProductionGenericRepository<Inventory_Requisition_Item_Specifications>().Find(r => r.IsActive == true && r.RequisitionID == Requisition.ID && r.ItemID == Item.ItemID && r.RequisitionItemID == RItemID).ToList();
            foreach (Inventory_Requisition_Item_Specifications spec in existingspecs)
            {
                spec.IsActive = false;
                spec.UpdatedByID = Requisition.UpdatedByID;
                spec.UpdatedOn = Requisition.UpdatedOn;
                new NonProductionGenericRepository<Inventory_Requisition_Item_Specifications>().Update(spec, s => s.ID == spec.ID);
            }

            var specs = Item.Specification.Where(s => s.IsSelected == true);
            foreach (var spec in specs)
            {
                Inventory_Requisition_Item_Specifications InvReqSpec = new Inventory_Requisition_Item_Specifications();
                InvReqSpec.RequisitionID = Requisition.ID;
                InvReqSpec.ItemID = Item.ItemID;
                InvReqSpec.SpecificationName = spec.SpecificationName;
                InvReqSpec.SpecificationValue = spec.SpecificationValue;
                InvReqSpec.UOM = spec.UOM;
                InvReqSpec.IsActive = true;
                InvReqSpec.CreatedByID = Requisition.CreatedByID;
                InvReqSpec.CreatedOn = Requisition.CreatedOn;
                InvReqSpec.RequisitionItemID = RItemID;
                var result = new NonProductionGenericRepository<Inventory_Requisition_Item_Specifications>().Insert(InvReqSpec);
            }

            return true;
        }

        public List<RequistionSearchItems> getRequisitionsBySearch(int employeeid, int InventoryTypeID, string DateFrom,
            string DateTo, string SearchText)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var EmployeeID = new SqlParameter("@EmployeeID", employeeid);
                var inventoryTypeID = new SqlParameter("@InventoryTypeID", InventoryTypeID);
                var dateFrom = new SqlParameter("@DateFrom", DateFrom);
                var dateTo = new SqlParameter("@DateTo", DateTo);
                var searchText = new SqlParameter("@SearchText", SearchText);

                return db.Database.SqlQuery<RequistionSearchItems>("getInventoryRequisitions @EmployeeID, @InventoryTypeID, @DateFrom, @DateTo, @SearchText", EmployeeID, inventoryTypeID, dateFrom, dateTo, searchText).ToList();
            }
        }

        public List<RequistionSearchItems> getPendingRequisitionList(int InventoryTypeID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var inventoryTypeID = new SqlParameter("@InventoryTypeID", InventoryTypeID);

                return db.Database.SqlQuery<RequistionSearchItems>("getRequisitionPendingNP @InventoryTypeID", inventoryTypeID).ToList();
            }
        }

        public List<RequistionSearchItems> getRequisitionsWithMaterialsForApproval(int EmployeeID, int ActionID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var employeeID = new SqlParameter("@EmployeeID", EmployeeID);
                var actionID = new SqlParameter("@ActionID", ActionID);
                return db.Database.SqlQuery<RequistionSearchItems>("getInventoryRequisitionsForApproval @EmployeeID, @ActionID", employeeID, actionID).ToList();
            }
        }

        // -- 2 = VERIFIED, 3 = APPROVED
        public List<InventoryRequisitionsForApproval> getRequisitionsForApproval(int EmployeeID, int ActionID)
        {
            List<InventoryRequisitionsForApproval> reqlist = new List<InventoryRequisitionsForApproval>();
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var employeeID = new SqlParameter("@EmployeeID", EmployeeID);
                var actionID = new SqlParameter("@ActionID", ActionID);
                reqlist = db.Database.SqlQuery<InventoryRequisitionsForApproval>("getInventoryRequisitionsForApproval @EmployeeID, @ActionID", employeeID, actionID).ToList();
            }

            foreach (var item in reqlist)
            {
                item.MainGroupName = GetMainGroupsByReqID(item.RequisitionID.GetValueOrDefault());
            }

            return reqlist;
        }

        private string GetMainGroupsByReqID(int ReqId)
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

        // VERIFY & APPROVAL

        public Inventory_Requisitions verifyInventoryRequisition(int ActionID, CommonDataEntryClass Data)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var req = db.Inventory_Requisitions.FirstOrDefault(r => r.ID == Data.ID);
                if (req != null)
                {
                    // Verify
                    if (ActionID == ActionGroup.VERIFIED)
                    {
                        req.IsVerified = true;
                        req.VerifiedOn = DateTime.Now;
                        req.VerifiedByID = Data.EmployeeCode;
                        req.VerifyRemarks = Data.Remarks;
                    }

                    // Approval
                    else if (ActionID == ActionGroup.APPROVED)
                    {
                        req.IsApproved = true;
                        req.ApprovedOn = DateTime.Now;
                        req.ApprovedById = Data.EmployeeCode;
                        req.ApprovalRemarks = Data.Remarks;
                    }
                    else throw new Exception("Unknown Action ID. Action ID = " + ActionID);
                    db.SaveChanges();

                    return req;
                }

                return null;
            }
        }

        public Inventory_Requisitions getRequisition(int RequisitionID)
        {
            return _requisition.FindOne(r => r.ID == RequisitionID);
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
                return null;
            }
        }
        public Inventory_Requisition_Items getRequisitionItems(int RequisitionID, int ItemID)
        {
            return _requisitionDetails.FindOne(r => r.RequisitionID == RequisitionID && r.ItemID == ItemID && r.IsActive == true);
            //new InventoryGenericRepository<Inventory_Requisition_Items>().Find(r => r.RequisitionID == RequisitionID && r.ItemID == ItemID && r.IsActive == true).FirstOrDefault();
        }

        public List<Inventory_Requisition_Items> getRequisitionItemList(int RequisitionID, int ItemID)
        {
            return _requisitionDetails.Find(r => r.RequisitionID == RequisitionID && r.ItemID == ItemID && r.IsActive == true).ToList();
            //new InventoryGenericRepository<Inventory_Requisition_Items>().Find(r => r.RequisitionID == RequisitionID && r.ItemID == ItemID && r.IsActive == true).FirstOrDefault();
        }

        public object getRequisitionDetails(int RequisitionID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var Requisition = db.Inventory_Requisitions.FirstOrDefault(r => r.ID == RequisitionID); //getInventoryRequisition(RequisitionID);
                var RequisitionItems = db.Inventory_Requisition_Items.Where(r => r.ID == RequisitionID).ToList();

                return new { Requisition, RequisitionItems };
            }
        }

        public InventoryRequisition getInventoryRequisition(int RequisitionID)
        {
            var requisitionID = new SqlParameter("@RequisitionID", RequisitionID);
            InventoryRequisition requisition = new ProcurementGenericRepository<InventoryRequisition>().FindUsingSP("getInventoryRequisition @RequisitionID", requisitionID).FirstOrDefault();

            //requisition.RequisitionForMonths = getInventoryRequisitionForMonths(RequisitionID);
            //requisition.RequisitionForBrands = getInventoryRequisitionForBrands(RequisitionID);
            return requisition;
        }

        public List<InventoryRequisition> getInventoryRequisitionWithItemStatus(int RequisitionID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var requisitionID = new SqlParameter("@RequisitionID", RequisitionID);
                List<InventoryRequisition> requisition = db.Database.SqlQuery<InventoryRequisition>("getInventoryRequisition @RequisitionID", requisitionID).ToList();

                //requisition[0].RequisitionForMonths = getInventoryRequisitionForMonths(RequisitionID);
                //requisition[0].RequisitionForBrands = getInventoryRequisitionForBrands(RequisitionID);
                return requisition;
            }
        }

        public InventoryRequisitionSignatures getInventoryRequisitionSignatures(int RequisitionID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var requisitionID = new SqlParameter("@RequisitionID", RequisitionID);
                return db.Database.SqlQuery<InventoryRequisitionSignatures>("getInventoryRequisitionSignatures @RequisitionID", requisitionID).FirstOrDefault();
            }
        }

        public object getRequisitionReport(string RequisitionCode, int RequisitionID)
        {
            if (RequisitionID == 0)
            {
                Inventory_Requisitions Req = new ProcurementGenericRepository<Inventory_Requisitions>().Find(r => r.RequisitionCode == RequisitionCode).FirstOrDefault();

                if (Req == null) return null;
                else RequisitionID = Req.ID;
            }

            var Requisition = getInventoryRequisition(RequisitionID);
            List<InventoryRequisition> RequisitionWithStatus = getInventoryRequisitionWithItemStatus(RequisitionID);
            var RequisitionSignatures = getInventoryRequisitionSignatures(RequisitionID);
            var RequisitionDetails = getInventoryRequisitionDetails(RequisitionID);
            RequisitionDetails = RequisitionDetails.OrderByDescending(a => a.ItemID).ToList();
            return new { Requisition, RequisitionDetails, RequisitionSignatures, RequisitionWithStatus };
        }

        public List<InventoryRequisitionDetails> getInventoryRequisitionDetails(int RequisitionID)
        {
            InventorySettingsRepositories repo = new InventorySettingsRepositories();

            using (ProcurementEntities db = new ProcurementEntities())
            {
                var requisitionID = new SqlParameter("@RequisitionID", RequisitionID);
                //var Items = db.Database.SqlQuery<InventoryRequisitionDetails>("getInventoryRequisitionDetails @RequisitionID", requisitionID).ToList();
                var Items = db.Database.SqlQuery<InventoryRequisitionDetails>("getInventoryRequisitionDetailsByReqID @RequisitionID", requisitionID).ToList();

                //foreach (InventoryRequisitionDetails item in Items)
                //{
                //    item.Specifications = new List<ItemSpecification>();
                //    //List<ItemSpecification> specs = getItemSpecifications(item.ItemID.GetValueOrDefault());
                //    List<Inventory_Requisition_Item_Specifications> specs = getRequisitionItemSpecifications(RequisitionID, item.ItemID.GetValueOrDefault(), item.ID);
                //    List<ItemSpecification> specsList = new List<ItemSpecification>();

                //    foreach (var sp in specs)
                //    {
                //        ItemSpecification spec = new ItemSpecification();
                //        spec.IsSelected = true;
                //        spec.ShowInName = true;
                //        spec.SpecificationID = sp.ID;
                //        spec.SpecificationName = sp.SpecificationName;
                //        spec.SpecificationValue = sp.SpecificationValue;
                //        spec.UOM = sp.UOM;
                //        specsList.Add(spec);
                //    }

                //    item.ItemNameWithSpec = repo.getItemnameWithSpec(item.ItemName, specsList);
                //    if (specs != null) item.Specifications.AddRange(specsList);
                //}

                return Items;
            }
        }

        public List<InventoryPrivilege> getInventoryPrivilege(int inventorytypeid, int EmployeeID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<InventoryPrivilege> Report = new List<InventoryPrivilege>();

                // Taking main group of a specific Inventory Type
                List<Inventory_Item_MainGroup> mainGroups = db.Inventory_Item_MainGroup.Where(g => g.InventoryTypeID == inventorytypeid && g.IsActive == true).ToList();

                // Getting user all Main Groups
                List<Inventory_MainGroup_Users> userGroups = db.Inventory_MainGroup_Users.Where(g => g.EmployeeID == EmployeeID && g.IsActive == true).ToList();

                foreach (Inventory_Item_MainGroup mainGroup in mainGroups)
                {
                    InventoryPrivilege rpt = new InventoryPrivilege();

                    rpt.MainGroupID = mainGroup.ID;
                    rpt.MainGroupName = mainGroup.GroupName;
                    rpt.HasPrivilege = false;

                    if (userGroups != null)
                    {
                        var userGroup = userGroups.FirstOrDefault(u => u.MainGroupID == mainGroup.ID);
                        if (userGroup != null) rpt.HasPrivilege = true;
                    }

                    Report.Add(rpt);
                }

                return Report;
            }
        }

        public Boolean saveInventoryPrivilege(InventoryPrivilegeNew Data)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                if (Data.HasPrivilege)
                {
                    Inventory_MainGroup_Users mu = new Inventory_MainGroup_Users();
                    mu.MainGroupID = Data.MainGroupID;
                    //mu.UserID = Data.UserID;
                    mu.CreatedByID = Data.CreatedByID;
                    mu.CreatedOn = DateTime.Now;
                    mu.EmployeeID = Data.EmployeeID;
                    mu.IsActive = true;
                    db.Inventory_MainGroup_Users.Add(mu);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    var mu = db.Inventory_MainGroup_Users.Where(m => m.MainGroupID == Data.MainGroupID && m.EmployeeID == Data.EmployeeID).FirstOrDefault();

                    if (mu != null)
                    {
                        mu.IsActive = false;
                        db.Inventory_MainGroup_Users.AddOrUpdate(mu);
                        db.SaveChanges();

                        return true;
                    }
                    return false;
                }
            }
        }

        public List<Inventory_Item_SubGroup_Specifications> getItemGroupSpecifications(int ItemID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                Inventory_Items item = db.Inventory_Items.FirstOrDefault(i => i.ID == ItemID);
                if (item == null) return null;
                return db.Inventory_Item_SubGroup_Specifications.Where(s => s.SubGroupID == item.SubGroupId && s.IsActive == true).ToList();
            }
        }

        public string getInventoryRequisitionForMonths(int RequisitionID)
        {
            List<Inventory_Requisition_For_Months> forMonths = new ProcurementGenericRepository<Inventory_Requisition_For_Months>().Find(m => m.RequisitionID == RequisitionID).ToList();

            if (forMonths != null && forMonths.Count > 0)
            {
                string months = "";
                foreach (Inventory_Requisition_For_Months month in forMonths)
                {
                    months += month.ForDate.GetValueOrDefault().ToString("MMM,yyyy") + "; ";
                }

                return months;
            }

            return "";
        }

        public string getInventoryRequisitionForBrands(int RequisitionID)
        {
            string brandNames = "";
            var requisitionID = new SqlParameter("@RequisitionID", RequisitionID);
            var Brands = new ProcurementGenericRepository<RequisitionBrands>().FindUsingSP("getInventoryRequisitionBrands @RequisitionID", requisitionID).ToList();

            foreach (RequisitionBrands brand in Brands)
            {
                brandNames += brand.BrandName + ",";
            }

            return Scripting.removeLastComma(brandNames);
        }

        public Inventory_Items deleteInventoryItem(int ItemID, string EmployeeID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                // Finding existing  Inventory_Items

                Inventory_Items it = db.Inventory_Items.Where(o => o.ID == ItemID).FirstOrDefault();

                if (it != null)
                {
                    // UPDATE Inventory_Items

                    it.IsActive = false;
                    it.UpdatedByID = EmployeeID;
                    it.UpdatedOn = DateTime.Now;

                    db.SaveChanges();
                    return it;
                }

                return null;
            }
        }

        public object getItemReport(int itemid, string itemcode)
        {
            InventorySettingsRepositories repo = new InventorySettingsRepositories();

            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                // ITEM
                Inventory_Items item = null;
                if (itemid == 0) item = db.Inventory_Items.FirstOrDefault(i => i.ItemCode == itemcode);
                else item = db.Inventory_Items.FirstOrDefault(i => i.ID == itemid);

                if (item == null) return null;

                List<ItemSpecification> Specs = getItemSpecifications(0, item.ID);

                InventoryItems Item = repo.getInventoryItem(item.ID);
                Item.ItemNameWithSpec = repo.getItemnameWithSpec(item.ItemName, Specs);

                // SUB GROUP
                Inventory_Item_SubGroup SubGroup = db.Inventory_Item_SubGroup.FirstOrDefault(s => s.ID == item.SubGroupId);
                if (SubGroup == null) return null;

                // MAIN GROUP
                Inventory_Item_MainGroup MainGroup = db.Inventory_Item_MainGroup.FirstOrDefault(m => m.ID == SubGroup.MainGroupID);

                // SPEC
                List<InventoryItemSpecifications> Specifications = repo.getInventoryItemSpecifications(item.ID, 0, false);

                return new { MainGroup, SubGroup, Item, Specifications };
            }
        }

        public List<string> getItemUOM()
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.UnitOfMeasurements.Where(s => s.IsActive == true).Select(s => s.UOM).Distinct().ToList<string>();
            }
        }

        public List<Inventory_Requisition_Type> getRequisitionTypes()
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Inventory_Requisition_Type.Where(t => t.IsActive == true).ToList();
            }
        }

        public Inventory_Items getInventoryItem(int ItemID)
        {
            return new ProcurementGenericRepository<Inventory_Items>().Find(i => i.ID == ItemID).FirstOrDefault();
        }

        public List<ItemSpecification> getItemSpecifications(int RequisitionId, int ItemID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var requisitionID = new SqlParameter("@RequisionID", RequisitionId);
                var itemID = new SqlParameter("@ItemID", ItemID);
                var subGroupID = new SqlParameter("@SubGroupID", "0");
                var showInNameOnly = new SqlParameter("@ShowInNameOnly", false);

                return db.Database.SqlQuery<ItemSpecification>("getInventoryItemSpecifications @RequisionID, @ItemID, @SubGroupID, @ShowInNameOnly", requisitionID, itemID, subGroupID, showInNameOnly).ToList();
            }
        }

        public List<Inventory_Requisition_Item_Specifications> getRequisitionItemSpecifications(int RequisitionID, int ItemID, int RequisitionItemID)
        {
            return new NonProductionCSEntities().Inventory_Requisition_Item_Specifications.Where(i => i.IsActive == true && i.RequisitionID == RequisitionID && i.ItemID == ItemID && i.RequisitionItemID == RequisitionItemID).ToList();
        }

        public List<ItemSpecification> getItemSpecificationInCommas(int Requisionid, int ItemID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var RequisionID = new SqlParameter("@RequisionID", Requisionid);
                var itemID = new SqlParameter("@ItemID", ItemID);
                var subGroupID = new SqlParameter("@SubGroupID", "0");
                var showInNameOnly = new SqlParameter("@ShowInNameOnly", false);

                return db.Database.SqlQuery<ItemSpecification>("getInventoryItemSpecifications @RequisionID, @ItemID, @SubGroupID, @ShowInNameOnly", RequisionID, itemID, subGroupID, showInNameOnly).ToList();
            }
        }

        public List<ItemSpecification> getRequisitionItemSpecificationList(int RequisitionItemID, int RequisitionID, int ItemID)
        {
            if (RequisitionItemID == 0)
            {
                return getItemSpecificationInCommas(RequisitionID, ItemID);
            }

            List<ItemSpecification> specList = new List<ItemSpecification>();
            ItemSpecification spec = new ItemSpecification();
            var Specs = new NonProductionGenericRepository<Inventory_Requisition_Item_Specifications>().Find(r => r.RequisitionItemID == RequisitionItemID && r.ItemID == ItemID && r.RequisitionID == RequisitionID && r.IsActive == true);
            int i = 1;
            foreach (var item in Specs)
            {
                spec.UOM = item.UOM;
                spec.SpecificationName = item.SpecificationName;
                spec.SpecificationValue = item.SpecificationValue;
                spec.SpecificationID = item.ID;
                spec.ShowInName = true;
                spec.OrderNo = i;
                i++;

                specList.Add(spec);
                spec = new ItemSpecification();
            }

            return specList;
        }

        public Inventory_Requisition_Items getRequisitionItem(int RequisitionID, int ItemID, Nullable<decimal> Quantity)
        {
            return new ProcurementGenericRepository<Inventory_Requisition_Items>().Find(i => i.RequisitionID == RequisitionID && i.ItemID == ItemID && i.IsActive == true).FirstOrDefault();
        }
    }
}