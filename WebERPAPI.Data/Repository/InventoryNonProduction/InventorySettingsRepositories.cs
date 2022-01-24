using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.DTO.Inventory.Requisitions;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.GenericRepository;
using System.Data.Entity.Migrations;
using WebERPAPI.DTO.InventoryNonProduction;
using WebERPAPI.Library;

namespace WebERPAPI.Data.Repository.Inventory
{
    public class InventorySettingsRepositories
    {
        public InventorySettingsRepositories()
        {
        }

        public List<InventoryTypes> getInventoryTypes()
        {
            return new NonProductionGenericRepository<InventoryTypes>().FindUsingSP("getInventoryTypes").ToList();
        }

        public List<InventoryStores> getInventoryStores(int InventoryTypeId)
        {
            return new NonProductionGenericRepository<InventoryStores>().FindUsingSP("getInventoryStores @InventoryTypeId, @EmployeeID",
                new SqlParameter("@InventoryTypeId", InventoryTypeId), new SqlParameter("@EmployeeID", ""));
        }

        public Boolean saveInventoryTypeAndStore(CommonDataEntryClass Data)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var typeStores = db.Inventory_TypesAndStore.Where(t => t.InventoryStoreID == Data.ID && t.InventoryTypeID == Data.TypeID && t.IsActive == true).FirstOrDefault();

                if (typeStores == null)
                {
                    Inventory_TypesAndStore its = new Inventory_TypesAndStore();

                    its.InventoryStoreID = Data.ID;
                    its.InventoryTypeID = Data.TypeID;
                    its.IsActive = true;
                    its.CreatedByID = Data.EmployeeCode;
                    its.CreatedOn = DateTime.Now;

                    db.Inventory_TypesAndStore.Add(its);
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    typeStores.InventoryStoreID = Data.ID;
                    typeStores.InventoryTypeID = Data.TypeID;
                    typeStores.IsActive = false;
                    typeStores.CreatedByID = Data.EmployeeCode;
                    typeStores.CreatedOn = DateTime.Now;

                    db.SaveChanges();
                }

                return true;
            }
        }

        public object getInventoryTypesAndStores(string EmployeeID = "")
        {
            List<InventoryTypesAndStores> Report = new List<InventoryTypesAndStores>();

            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<InventoryTypes> Types = getInventoryTypes();
                var inventoryTypeId = new SqlParameter("@InventoryTypeId", "0");
                var EmployeeId = new SqlParameter("@EmployeeID", EmployeeID);
                List<InventoryStores> typesAndstores = db.Database.SqlQuery<InventoryStores>("getInventoryStores @InventoryTypeId, @EmployeeID", inventoryTypeId, EmployeeId).ToList();

                List<Inventory_Stores> Stores = new List<Inventory_Stores>();

                foreach (var item in typesAndstores)
                {
                    Stores.Add(db.Inventory_Stores.Where(s => s.IsActive == true && s.ID == item.StoreID).FirstOrDefault());
                }

                foreach (Inventory_Stores store in Stores)
                {
                    InventoryTypesAndStores rpt = new InventoryTypesAndStores();

                    rpt.StoreID = store.ID;
                    rpt.StoreName = store.StoreName;
                    rpt.StoreDescription = store.Description;

                    var typeStore = typesAndstores.Where(ts => ts.StoreID == store.ID).ToList();

                    if (typeStore != null)
                    {
                        rpt.TypesList = new List<InventoryStores>();
                        rpt.TypesList.AddRange(typeStore);
                    }

                    Report.Add(rpt);
                }

                return new { Types, Report };
            }
        }

        public Boolean deleteSubGroupSupplier(int SubGroupID, string suppliercode, string EmployeeID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var Supplier = db.Inventory_SubGroup_Suppliers.FirstOrDefault(s => s.SubGroupID == SubGroupID && s.SupplierCode == suppliercode && s.IsActive == true);

                if (Supplier != null)
                {
                    Supplier.IsActive = false;
                    Supplier.UpdatedByID = EmployeeID;
                    Supplier.UpdatedOn = DateTime.Now;
                    //db.Inventory_MainGroup_Suppliers.Remove(Supplier);
                    db.SaveChanges();
                }

                return true;
            }
        }

        public Boolean saveSubGroupSupplier(int SubGroupID, string SupplierCode, string EmployeeCode)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var Supplier = db.Inventory_SubGroup_Suppliers.FirstOrDefault(s => s.SubGroupID == SubGroupID && s.SupplierCode == SupplierCode && s.IsActive == true);

                if (Supplier == null)
                {
                    Inventory_SubGroup_Suppliers ns = new Inventory_SubGroup_Suppliers();

                    ns.SubGroupID = SubGroupID;
                    ns.SupplierCode = SupplierCode;
                    ns.CreatedOn = DateTime.Now;
                    ns.CreatedByID = EmployeeCode;
                    ns.IsActive = true;

                    db.Inventory_SubGroup_Suppliers.Add(ns);
                    db.SaveChanges();
                }

                return true;
            }
        }

        public Boolean deleteExistingSubGroupSpecification(int SubGroupID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<Inventory_Item_SubGroup_Specifications> specs = db.Inventory_Item_SubGroup_Specifications.Where(o => o.SubGroupID == SubGroupID).ToList();

                foreach (Inventory_Item_SubGroup_Specifications spec in specs)
                {
                    spec.IsActive = false;
                    db.SaveChanges();
                }

                return true;
            }
        }

        public Inventory_Types deleteInventoryType(int TypeID, string EmployeeID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                // Finding existing  InventoryTypes

                Inventory_Types it = db.Inventory_Types.Where(o => o.ID == TypeID).FirstOrDefault();

                if (it != null)
                {
                    // UPDATE InventoryTypes

                    it.IsActive = false;
                    it.UpdatedByID = EmployeeID;
                    it.UpdatedOn = DateTime.Now;

                    db.SaveChanges();
                    return it;
                }

                return null;
            }
        }

        public Inventory_Types saveInventoryTypes(Inventory_Types Data)
        {
            Inventory_Types it = new ProcurementGenericRepository<Inventory_Types>().Find(o => o.ID == Data.ID).FirstOrDefault();

            if (it == null)
            {
                //SAVE NEW InventoryTypes
                new ProcurementGenericRepository<Inventory_Types>().Insert(Data);
                return Data;
            }
            else
            {
                new ProcurementGenericRepository<Inventory_Types>().Update(Data, i => i.ID == Data.ID);
                return Data;
            }
        }

        //STORES

        public Inventory_Stores saveInventoryStore(Inventory_Stores Data)
        {
            return new ProcurementGenericRepository<Inventory_Stores>().Insert(Data);
        }

        public Inventory_Stores updateInventoryStore(Inventory_Stores Data)
        {
            return new ProcurementGenericRepository<Inventory_Stores>().Update(Data, i => i.ID == Data.ID);
        }

        public List<Inventory_Item_UsageTypes> getItemUsageType()
        {
            return new ProcurementGenericRepository<Inventory_Item_UsageTypes>().Find(i => i.IsActive == true).ToList();
        }

        public Boolean addStoreToInventoryType(int InventoryTypeID, int StoreID, string EmployeeCode)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                // Finding existing  InventoryTypes

                Inventory_TypesAndStore its = db.Inventory_TypesAndStore.Where(o => o.InventoryTypeID == InventoryTypeID && o.InventoryStoreID == StoreID).FirstOrDefault();

                if (its == null)
                {
                    //SAVE NEW InventoryTypes

                    Inventory_TypesAndStore newis = new Inventory_TypesAndStore();

                    newis.InventoryStoreID = StoreID;
                    newis.InventoryTypeID = InventoryTypeID;
                    newis.IsActive = true;
                    newis.CreatedOn = DateTime.Now;
                    newis.CreatedByID = EmployeeCode;

                    db.Inventory_TypesAndStore.Add(newis);

                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return true;
                }
            }
        }

        //ITEM GROUP

        public Inventory_Item_MainGroup saveItemMainGroup(Inventory_Item_MainGroup Data)
        {
            return new ProcurementGenericRepository<Inventory_Item_MainGroup>().Insert(Data);
        }

        public Inventory_Item_MainGroup updateItemMainGroup(Inventory_Item_MainGroup Data)
        {
            return new ProcurementGenericRepository<Inventory_Item_MainGroup>().Update(Data, i => i.ID == Data.ID);
        }

        public Inventory_Item_MainGroup deleteItemMainGroup(int GroupID, string EmployeeID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                // Finding existing  InventoryTypes

                Inventory_Item_MainGroup it = db.Inventory_Item_MainGroup.Where(o => o.ID == GroupID).FirstOrDefault();

                if (it != null)
                {
                    // UPDATE InventoryTypes

                    it.IsActive = false;
                    it.UpdatedByID = EmployeeID;
                    it.UpdatedOn = DateTime.Now;

                    db.SaveChanges();
                    return it;
                }

                return null;
            }
        }

        public Inventory_Item_SubGroup saveItemSubGroup(Inventory_Item_SubGroup Data)
        {
            return new ProcurementGenericRepository<Inventory_Item_SubGroup>().Insert(Data);
        }

        public Inventory_Item_SubGroup updateItemSubGroup(Inventory_Item_SubGroup Data)
        {
            return new ProcurementGenericRepository<Inventory_Item_SubGroup>().Update(Data, i => i.ID == Data.ID);
        }

        public Inventory_Item_SubGroup deleteItemSubGroup(int GroupID, string EmployeeID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                // Finding existing  InventoryTypes

                Inventory_Item_SubGroup it = db.Inventory_Item_SubGroup.Where(o => o.ID == GroupID).FirstOrDefault();

                if (it != null)
                {
                    // UPDATE InventoryTypes

                    it.IsActive = false;
                    it.UpdatedByID = EmployeeID;
                    it.UpdatedOn = DateTime.Now;

                    db.SaveChanges();
                    return it;
                }

                return null;
            }
        }

        public List<Inventory_Item_MainGroup> getItemGroupList(int inventorytypeid)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Inventory_Item_MainGroup.Where(g => g.InventoryTypeID == inventorytypeid && g.IsActive == true).OrderBy(g => g.GroupName).ToList();
            }
        }

        public List<SupplierNonProduction> getSubGroupSuppliers(int SubGroupID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var subGroupID = new SqlParameter("@SubGroupID", SubGroupID);
                return db.Database.SqlQuery<SupplierNonProduction>("getInventorySubGroupSupplier @SubGroupID", subGroupID).ToList();
            }
        }

        public List<Inventory_Item_SubGroup> getItemSubGroupList(int MainGroupID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Inventory_Item_SubGroup.Where(g => g.MainGroupID == MainGroupID && g.IsActive == true).OrderBy(g => g.GroupName).ToList();
            }
        }

        public List<SubGroupSpecification> getItemSubGroupSpecification(int subgroupid)
        {
            List<SubGroupSpecification> Report = new List<SubGroupSpecification>();

            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<Inventory_Item_Specification> specs = db.Inventory_Item_Specification.Where(s => s.IsActive == true).ToList();
                List<Inventory_Item_SubGroup_Specifications> groupSpecs = db.Inventory_Item_SubGroup_Specifications.Where(s => s.SubGroupID == subgroupid && s.IsActive == true).ToList();

                foreach (Inventory_Item_Specification spec in specs)
                {
                    SubGroupSpecification rpt = new SubGroupSpecification();

                    rpt.SpecificationID = spec.ID;
                    rpt.SpecificationName = spec.SpecificationName;

                    rpt.UOM = spec.UOM;
                    rpt.IsSelected = false;
                    rpt.ShowInName = false;

                    if (groupSpecs != null)
                    {
                        var gSpec = groupSpecs.Where(g => g.SpecificationID == spec.ID).FirstOrDefault();
                        if (gSpec != null) rpt.IsSelected = true;
                    }

                    Report.Add(rpt);
                }

                return Report.OrderByDescending(s => s.IsSelected).ToList();
            }
        }

        public List<SubGroupSpecification> getInventorySubGroupSpecification(int subgroupid, int inventorytypeid)
        {
            List<SubGroupSpecification> Report = new List<SubGroupSpecification>();

            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<Inventory_Item_Specification> specs = db.Inventory_Item_Specification.Where(s => s.IsActive == true && s.InventoryTypeID == inventorytypeid).ToList();
                List<Inventory_Item_SubGroup_Specifications> groupSpecs = db.Inventory_Item_SubGroup_Specifications.Where(s => s.SubGroupID == subgroupid && s.IsActive == true).ToList();

                foreach (Inventory_Item_Specification spec in specs)
                {
                    SubGroupSpecification rpt = new SubGroupSpecification();

                    rpt.SpecificationID = spec.ID;
                    rpt.SpecificationName = spec.SpecificationName;

                    rpt.UOM = spec.UOM;
                    rpt.IsSelected = false;
                    rpt.ShowInName = false;

                    if (groupSpecs != null)
                    {
                        var gSpec = groupSpecs.Where(g => g.SpecificationID == spec.ID).FirstOrDefault();
                        if (gSpec != null) rpt.IsSelected = true;
                    }

                    Report.Add(rpt);
                }

                return Report.OrderByDescending(s => s.IsSelected).ToList();
            }
        }

        public List<SubGroupSpecification> getInventorySpecification(int inventoryTypeID)
        {
            List<SubGroupSpecification> Report = new List<SubGroupSpecification>();

            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<Inventory_Item_Specification> specs = db.Inventory_Item_Specification.Where(s => s.IsActive == true && s.InventoryTypeID == inventoryTypeID).ToList();

                foreach (Inventory_Item_Specification spec in specs)
                {
                    SubGroupSpecification rpt = new SubGroupSpecification();

                    rpt.SpecificationID = spec.ID;
                    rpt.SpecificationName = spec.SpecificationName;

                    rpt.UOM = spec.UOM;
                    rpt.IsSelected = false;
                    rpt.ShowInName = false;
                    Report.Add(rpt);
                }

                return Report.OrderByDescending(s => s.IsSelected).ToList();
            }
        }

        public List<Inventory_Item_SubGroup_Specifications> getItemSubGroupSpecificationOnly(int subgroupid)
        {
            List<SubGroupSpecification> Report = new List<SubGroupSpecification>();

            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Inventory_Item_SubGroup_Specifications.Where(s => s.SubGroupID == subgroupid && s.IsActive == true).ToList();
            }
        }

        public Boolean saveItemSubGroupSpecification(int SubGroupID, int SpecificationID, string EmployeeCode)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                Inventory_Item_SubGroup_Specifications spec = db.Inventory_Item_SubGroup_Specifications.FirstOrDefault(
                        s => s.SubGroupID == SubGroupID &&
                        s.SpecificationID == SpecificationID &&
                        s.IsActive == true);

                if (spec == null)
                {
                    Inventory_Item_SubGroup_Specifications newSpec = new Inventory_Item_SubGroup_Specifications();
                    newSpec.SubGroupID = SubGroupID;
                    newSpec.SpecificationID = SpecificationID;
                    newSpec.CreatedByID = EmployeeCode;
                    newSpec.CreatedOn = DateTime.Now;
                    newSpec.IsActive = true;

                    db.Inventory_Item_SubGroup_Specifications.Add(newSpec);
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    spec.CreatedByID = EmployeeCode;
                    spec.CreatedOn = DateTime.Now;
                    spec.IsActive = false;

                    db.SaveChanges();
                    return true;
                }
            }
        }

        // VERSION & SPECIFICATION

        public List<Inventory_Item_Specification> getItemSpecifications(int InventorytypeId = 0)
        {
            if (InventorytypeId == 0)
                return new ProcurementGenericRepository<Inventory_Item_Specification>().Find(i => i.IsActive == true).ToList();
            else
                return new ProcurementGenericRepository<Inventory_Item_Specification>().Find(i => i.IsActive == true && i.InventoryTypeID == InventorytypeId).ToList();
        }

        public Inventory_Item_Specification saveItemSpecification(Inventory_Item_Specification Data)
        {
            return new ProcurementGenericRepository<Inventory_Item_Specification>().Insert(Data);
        }

        public Inventory_Item_Specification updateItemSpecification(Inventory_Item_Specification Data)
        {
            return new ProcurementGenericRepository<Inventory_Item_Specification>().Update(Data, i => i.ID == Data.ID);
        }

        public Inventory_Item_Specification deleteItemSpecification(int ID, string EmployeeID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var spec = db.Inventory_Item_Specification.FirstOrDefault(s => s.ID == ID);

                if (spec != null)
                {
                    spec.IsActive = false;
                    spec.UpdatedByID = EmployeeID;
                    spec.UpdatedOn = DateTime.Now;

                    db.SaveChanges();

                    return spec;
                }

                return null;
            }
        }

        // REQUISITION ITEM
        public List<Inventory_Item_Version_State> getVersionStates()
        {
            return new ProcurementGenericRepository<Inventory_Item_Version_State>().Find(i => i.IsActive == true).ToList();
        }



        public Inventory_Items saveInventoryItem(InventoryItemNew Data)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                // Finding existing  InventoryItems

                db.Configuration.LazyLoadingEnabled = false;

                Inventory_Items ii = db.Inventory_Items.Where(o => o.ID == Data.ID).FirstOrDefault();

                if (ii == null)
                {
                    string ItemCode = getItemCode(Data.SubGroupId);

                    // Validating Item Code
                    if (string.IsNullOrEmpty(ItemCode))
                    {
                        throw new Exception("Item code not found");
                    }

                    //SAVE NEW InventoryItems

                    Inventory_Items newii = new Inventory_Items();

                    newii.SubGroupId = Data.SubGroupId;
                    newii.ItemCode = ItemCode;
                    newii.ItemName = Data.ItemName;
                    newii.ItemNameWithSpec = Data.ItemName;
                    newii.Price = Data.Price;
                    newii.GenericName = Data.GenericName;


                    newii.Description = Data.Description;
                    newii.UOM = Data.UOM;
                    newii.ItemUsageTypeID = 0;

                    newii.MOQ = 0;
                    newii.Price = Data.Price;
                    newii.IsActive = true;
                    newii.CreatedByID = Data.EmployeeID;
                    newii.CreatedOn = DateTime.Now;

                    db.Inventory_Items.Add(newii);

                    db.SaveChanges();


                    return newii;
                }
                else
                {
                    // UPDATE InventoryItems

                    ii.SubGroupId = Data.SubGroupId;
                    ii.ItemName = Data.ItemName;
                    if (string.IsNullOrEmpty(ii.ItemNameWithSpec)) ii.ItemNameWithSpec = ii.ItemName;
                    ii.Description = Data.Description;
                    ii.UOM = Data.UOM;
                    ii.ItemUsageTypeID = 0;
                    ii.Price = Data.Price;
                    ii.GenericName = Data.GenericName;


                    ii.MOQ = 0;
                    ii.IsActive = true;
                    ii.UpdatedByID = Data.EmployeeID;
                    ii.UpdatedOn = DateTime.Now;
                    db.Inventory_Items.AddOrUpdate(ii);
                    db.SaveChanges();

                    //if promotional type


                    return ii;
                }
            }
        }

        private string getItemCode(int SubGroupId)
        {
            string ItemCode = "";
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var subGroup = db.Inventory_Item_SubGroup.FirstOrDefault(g => g.ID == SubGroupId);

                if (subGroup != null)
                {
                    var mainGroup = db.Inventory_Item_MainGroup.FirstOrDefault(g => g.ID == subGroup.MainGroupID);
                    if (mainGroup != null)
                    {
                        int itemNo = db.Inventory_Items.Where(i => i.SubGroupId == SubGroupId && i.IsActive == true).Count();
                        itemNo = 0;

                        Boolean isFree = false;
                        int x = 0;

                        while (!isFree)
                        {
                            itemNo++;
                            x++;
                            if (x > 1000) return "";

                            if (itemNo < 10) ItemCode = mainGroup.ItemCodePrefix + subGroup.ItemCodePrefix + "000" + itemNo.ToString();
                            else if (itemNo < 100) ItemCode = mainGroup.ItemCodePrefix + subGroup.ItemCodePrefix + "00" + itemNo.ToString();
                            else if (itemNo < 1000) ItemCode = mainGroup.ItemCodePrefix + subGroup.ItemCodePrefix + "0" + itemNo.ToString();
                            else ItemCode = mainGroup.ItemCodePrefix + subGroup.ItemCodePrefix + itemNo.ToString();

                            if (db.Inventory_Items.Where(i => i.ItemCode == ItemCode).FirstOrDefault() == null) return ItemCode;
                        }
                    }
                }
            }

            return ItemCode;
        }

        public Inventory_Item_Versions saveInventoryItemVersion(int ItemID, int VersionStateID, string EmployeeID)
        {
            int VersionNo = getInventoryNewVersion(ItemID);
            Inventory_Item_Versions iiv = new Inventory_Item_Versions();
            iiv.ItemID = ItemID;
            iiv.VersionNo = VersionNo;
            iiv.VersionStateID = VersionStateID;
            iiv.IsActive = true;
            iiv.CreatedByID = EmployeeID;
            iiv.CreatedOn = DateTime.Now;
            return new ProcurementGenericRepository<Inventory_Item_Versions>().Insert(iiv);
        }

        public Inventory_Item_Versions getInventoryItemVersion(int ItemID)
        {
            return new ProcurementGenericRepository<Inventory_Item_Versions>().Find(v => v.ItemID == ItemID && v.IsActive == true).OrderByDescending(v => v.VersionNo).FirstOrDefault();
        }

        private int getInventoryNewVersion(int ItemID)
        {
            int totalExistingVersion = new ProcurementGenericRepository<Inventory_Item_Versions>().Find(v => v.ItemID == ItemID && v.IsActive == true).Count();
            if (totalExistingVersion <= 0)
                totalExistingVersion = 0;
            return ++totalExistingVersion;
        }

        public List<Inventory_Item_Version_Details> getInventoryItemVersionDetails(int VersionID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                // Finding existing  InventoryItemVersionDetails

                return db.Inventory_Item_Version_Details.Where(v => v.VersionID == VersionID && v.IsActive == true).ToList();
            }
        }

        public bool removeInventoryItemVersionDetails(Inventory_Item_Version_Details item)
        {
            item.IsActive = false;
            using (ProcurementEntities db = new ProcurementEntities())
            {
                // Finding existing  InventoryItemVersionDetails

                db.Inventory_Item_Version_Details.AddOrUpdate(item);
                db.SaveChanges();
            }

            return true;
        }

        public Boolean saveInventoryItemVersionDetails(int VersionID, InventoryItemVersionSpecificationNew Spec)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                // Finding existing  InventoryItemVersionDetails

                Inventory_Item_Version_Details iiv = db.Inventory_Item_Version_Details.Where(
                        v => v.VersionID == VersionID && v.SpecificationID == Spec.SpecificationID && v.IsActive == true).FirstOrDefault();

                if (iiv == null)
                {
                    //SAVE NEW InventoryItemVersionDetails

                    Inventory_Item_Version_Details newiiv = new Inventory_Item_Version_Details();

                    newiiv.VersionID = VersionID;
                    newiiv.SpecificationID = Spec.SpecificationID;
                    newiiv.SpecificationValue = Spec.SpecificationValue;
                    newiiv.UOM = Spec.UOM;

                    newiiv.OrderNo = Spec.OrderNo;
                    newiiv.ShowInName = Spec.ShowInName;

                    newiiv.IsActive = true;
                    newiiv.CreatedOn = DateTime.Now;

                    db.Inventory_Item_Version_Details.Add(newiiv);
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    // UPDATE InventoryItemVersionDetails

                    iiv.SpecificationValue = Spec.SpecificationValue;
                    iiv.UOM = Spec.UOM;

                    iiv.OrderNo = Spec.OrderNo;
                    iiv.ShowInName = Spec.ShowInName;

                    iiv.IsActive = true;

                    db.SaveChanges();
                    return true;
                }
            }
        }

        public List<InventoryItems> getInventoryItems(int SubGroupID)
        {
            using (ProcurementEntities db = new ProcurementEntities())
            {
                var subGroupID = new SqlParameter("@SubGroupID", SubGroupID);
                //List<InventoryItems> Items = db.Database.SqlQuery<InventoryItems>("getInventoryItems @SubGroupID", subGroupID).ToList();
                List<InventoryItems> Items = db.Database.SqlQuery<InventoryItems>("getInventoryItemsBySubGroupId @SubGroupID", subGroupID).ToList();

                List<InventoryItemSpecifications> itemSpecs = getInventoryItemSpecifications(0, SubGroupID, true);

                foreach (InventoryItems item in Items)
                {
                    List<InventoryItemSpecifications> specs = itemSpecs.Where(i => i.ID == item.ID).ToList();
                    if (specs != null) item.ItemNameWithSpec = getItemnameWithSpec(item.ItemName, specs);
                }

                return Items;
            }
        }

        public InventoryItems getInventoryItem(int ItemID)
        {
            return new ProcurementGenericRepository<InventoryItems>().FindUsingSP("getInventoryItems 0, @ItemID", new SqlParameter("@ItemID", ItemID)).FirstOrDefault();
        }

        private string getItemnameWithSpec(string ItemName, List<InventoryItemSpecifications> Specs)
        {
            foreach (InventoryItemSpecifications spec in Specs)
            {
                if (!string.IsNullOrEmpty(spec.SpecificationValue))
                {
                    if (spec.UOM == "value") spec.UOM = "";
                    ItemName = ItemName + ", " + spec.SpecificationName + ": " + spec.SpecificationValue + " " + spec.UOM;
                }
            }

            return ItemName;
        }

        public string getItemnameWithSpec(string ItemName, List<ItemSpecification> Specs)
        {
            string ReturnName = ItemName + ", ";
            foreach (ItemSpecification spec in Specs)
            {
                if (spec.UOM == "value" || spec.UOM == "Text") spec.UOM = "";

                if (Specs[Specs.Count - 1] == spec)
                    ReturnName = ReturnName + spec.SpecificationName + ": " + spec.SpecificationValue + " " + spec.UOM;
                else
                    ReturnName = ReturnName + spec.SpecificationName + ": " + spec.SpecificationValue + " " + spec.UOM + ", ";
            }

            return ReturnName;
        }

        public List<InventoryItemSpecifications> getInventoryItemSpecifications(int ItemID, int SubGroupID, Boolean ShowInNameOnly)
        {
            var data = new ProcurementGenericRepository<InventoryItemSpecifications>().FindUsingSP("getInventoryItemSpecifications 0, " + ItemID + ", " + SubGroupID + ", " + ShowInNameOnly + "");

            foreach (var item in data)
            {
                if (item.UOM == "value" || item.UOM == "Text")
                    item.UOM = "";
            }

            return data;
            //using (ProcurementEntities db = new ProcurementEntities())
            //{
            //    var itemID = new SqlParameter("@ItemID", ItemID);
            //    var subGroupID = new SqlParameter("@SubGroupID", SubGroupID);
            //    var showInNameOnly = new SqlParameter("@ShowInNameOnly", ShowInNameOnly);

            //    return db.Database.SqlQuery<InventoryItemSpecifications>("getInventoryItemSpecifications @ItemID, @SubGroupID, @ShowInNameOnly", itemID, subGroupID, showInNameOnly).ToList();
            //}
        }

        public Inventory_Item_SubGroup getInvenotrySubgroup(int id)
        {
            var Data = new ProcurementGenericRepository<Inventory_Item_SubGroup>().Find(s => s.ID == id).FirstOrDefault();
            return Data;
        }

        public List<Inventory_SubGroup_Suppliers> getInventoryMainGroupSupplierListByMaingroupId(int id)
        {
            return new ProcurementGenericRepository<Inventory_SubGroup_Suppliers>().Find(i => i.SubGroupID == id && i.IsActive == true).ToList();
        }

        //Unit of measurment CRUD Start

        public List<UOMDto> getUOMList()
        {
            return new ProcurementGenericRepository<UOMDto>().FindUsingSP("getUOMList");
        }

        public UnitOfMeasurement getUOMById(int uomid)
        {
            return new ProcurementGenericRepository<UnitOfMeasurement>().Find(i => i.ID == uomid).FirstOrDefault();
        }

        public UnitOfMeasurement addUOM(UnitOfMeasurement uom)
        {
            return new ProcurementGenericRepository<UnitOfMeasurement>().Insert(uom);
        }

        public UnitOfMeasurement updateUOM(UnitOfMeasurement uom)
        {
            return new ProcurementGenericRepository<UnitOfMeasurement>().Update(uom, i => i.ID == uom.ID);
        }

        //Unit of measurment CRUD End

        public List<NonproductionItemPurchaseHistoryDto> nonProductionItemHistory(int itemID)
        {
            return new ProcurementGenericRepository<NonproductionItemPurchaseHistoryDto>().FindUsingSP("getNonproductionItemPurchaseHistory @ItemID, @RowNumber",
                new SqlParameter("@ItemID", itemID), new SqlParameter("@RowNumber", 20));
        }

        //item list

        public List<InventoryAllItemListAndSearchDto> getInventoryAllItemListAndSearch(InventoryItemListSearchPostDto data)
        {
            return new NonProductionGenericRepository<InventoryAllItemListAndSearchDto>().FindUsingSP(
                "getInventoryAllItemListAndSearch @InventoryTypeID,@MainGroupID,@SubgroupID,@SearchText",
                new SqlParameter("@InventoryTypeID", data.InventoryTypeID),
                new SqlParameter("@MainGroupID", data.MainGroupID),
                new SqlParameter("@SubgroupID", data.SubGroupID),
                new SqlParameter("@SearchText", data.SearchText)).ToList();
        }

        public Inventory_Stores getInventoryStoreById(int storeID)
        {
            return new ProcurementGenericRepository<Inventory_Stores>().Find(i => i.ID == storeID).FirstOrDefault();
        }
    }
}