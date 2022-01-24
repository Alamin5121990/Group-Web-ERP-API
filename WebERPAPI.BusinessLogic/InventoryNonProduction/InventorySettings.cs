using System;
using System.Collections.Generic;
using System.Linq;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.DTO.Inventory.Requisitions;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.Inventory;
using WebERPAPI.Library;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.BusinessLogic.Inventory
{
    public class InventorySettings
    {
        public Exception Error = new Exception();
        private InventorySettingsRepositories repo = new InventorySettingsRepositories();

        public List<InventoryTypes> getInventoryTypes()
        {
            try
            {
                return repo.getInventoryTypes();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Item_SubGroup getInvenotrySubgroup(int id)
        {
            try
            {
                return repo.getInvenotrySubgroup(id);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<InventoryStores> getInventoryStores(int InventoryTypeId)
        {
            try
            {
                var storeList = repo.getInventoryStores(InventoryTypeId);
                storeList = storeList.GroupBy(p => p.StoreID).Select(g => g.First()).ToList();
                return storeList;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Types saveInventoryTypes(CommonDataEntryClass data)
        {
            try
            {
                Inventory_Types newit = new Inventory_Types();
                newit.ID = data.ID;
                newit.TypeName = data.ItemName;
                newit.Description = data.Remarks;
                newit.IsActive = true;
                newit.CreatedOn = DateTime.Now;
                newit.CreatedByID = data.EmployeeCode;
                return repo.saveInventoryTypes(newit);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Types deleteInventoryType(int Typeid, string EmployeeID)
        {
            try
            {
                return repo.deleteInventoryType(Typeid, EmployeeID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<Inventory_SubGroup_Suppliers> getInventoryMainGroupSupplierListByMaingroupId(int id)
        {
            try
            {
                return repo.getInventoryMainGroupSupplierListByMaingroupId(id);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        //STORE

        public Inventory_Stores saveInventoryStore(CommonDataEntryClass Data)
        {
            try
            {
                Inventory_Stores it = new ProcurementGenericRepository<Inventory_Stores>().Find(i => i.ID == Data.ID).FirstOrDefault();
                if (it == null)
                {
                    //SAVE NEW InventoryTypes
                    Inventory_Stores newis = new Inventory_Stores();

                    newis.StoreName = Data.ItemName;
                    newis.Description = Data.Remarks;
                    newis.IsActive = true;
                    newis.CreatedOn = DateTime.Now;
                    newis.CreatedByID = Data.EmployeeCode;
                    newis = repo.saveInventoryStore(newis);
                    new InventorySettingsRepositories().addStoreToInventoryType(Data.TypeID, newis.ID, Data.EmployeeCode);
                    return newis;
                }
                else
                {
                    it.StoreName = Data.ItemName;
                    it.Description = Data.Remarks;
                    it.IsActive = true;
                    return repo.updateInventoryStore(it);
                }
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public object getInventoryTypesAndStores(string EmployeeID = "")
        {
            try
            {
                return repo.getInventoryTypesAndStores(EmployeeID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Boolean saveInventoryTypeAndStore(CommonDataEntryClass Data)
        {
            try
            {
                return repo.saveInventoryTypeAndStore(Data);
            }
            catch (Exception ex)
            {
                Error = ex;
                return false;
            }
        }

        public Inventory_Item_MainGroup saveItemMainGroup(ItemGroupNew Data)
        {
            try
            {
                Inventory_Item_MainGroup iim = new ProcurementGenericRepository<Inventory_Item_MainGroup>().Find(i => i.ID == Data.ID).FirstOrDefault();
                if (iim == null)
                {
                    //SAVE NEW InventoryItemMainGroup
                    Inventory_Item_MainGroup newItem = new Inventory_Item_MainGroup();

                    newItem.InventoryTypeID = Data.InventoryTypeID;
                    newItem.GroupName = Data.GroupName;
                    newItem.Description = Data.Description;
                    newItem.ItemCodePrefix = Data.ItemCodePrefix.ToUpper();
                    newItem.IsActive = true;
                    newItem.CreatedOn = DateTime.Now;
                    newItem.CreatedByID = Data.EmployeeCode;
                    return repo.saveItemMainGroup(newItem);
                }
                else
                {
                    iim.InventoryTypeID = Data.InventoryTypeID;
                    iim.GroupName = Data.GroupName;
                    iim.Description = Data.Description;
                    iim.ItemCodePrefix = Data.ItemCodePrefix.ToUpper();

                    iim.IsActive = true;
                    iim.UpdatedByID = Data.EmployeeCode;
                    iim.UpdatedOn = DateTime.Now;
                    return repo.updateItemMainGroup(iim);
                }
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Item_MainGroup deleteItemMainGroup(int groupid, string employeeid)
        {
            try
            {
                return repo.deleteItemMainGroup(groupid, employeeid);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Item_SubGroup saveItemSubGroup(ItemGroupNew Data)
        {
            try
            {
                Inventory_Item_SubGroup iim = new ProcurementGenericRepository<Inventory_Item_SubGroup>().Find(o => o.ID == Data.ID).FirstOrDefault();
                if (iim == null)
                {
                    //SAVE NEW InventoryItemMainGroup
                    Inventory_Item_SubGroup newItem = new Inventory_Item_SubGroup();

                    newItem.MainGroupID = Data.MainGroupID;
                    newItem.GroupName = Data.GroupName;
                    newItem.Description = Data.Description;
                    newItem.ItemCodePrefix = Data.ItemCodePrefix.ToUpper();
                    newItem.IsActive = true;
                    newItem.CreatedOn = DateTime.Now;
                    newItem.CreatedByID = Data.EmployeeCode;

                    repo.saveItemSubGroup(newItem);
                    return newItem;
                }
                else
                {
                    // UPDATE InventoryItemMainGroup
                    iim.MainGroupID = Data.MainGroupID;
                    iim.GroupName = Data.GroupName;
                    iim.Description = Data.Description;
                    iim.ItemCodePrefix = Data.ItemCodePrefix.ToUpper();
                    iim.IsActive = true;
                    iim.UpdatedByID = Data.EmployeeCode;
                    iim.UpdatedOn = DateTime.Now;

                    return repo.updateItemSubGroup(iim);
                }
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Item_SubGroup deleteItemSubGroup(int groupid, string employeeid)
        {
            try
            {
                return repo.deleteItemSubGroup(groupid, employeeid);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<Inventory_Item_MainGroup> getItemGroupList(int inventorytypeid)
        {
            try
            {
                return repo.getItemGroupList(inventorytypeid);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<Inventory_Item_SubGroup> getItemSubGroupList(int maingroupid)
        {
            try
            {
                return repo.getItemSubGroupList(maingroupid);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<SupplierNonProduction> getSubGroupSuppliers(int MainGroupID)
        {
            try
            {
                return repo.getSubGroupSuppliers(MainGroupID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        // VERSION & SPECIFICATION

        public List<ItemSpecification> getItemSpecifications(int SubGroupID, int itemid)
        {
            try
            {
                List<ItemSpecification> Report = new List<ItemSpecification>();
                List<Inventory_Item_Specification> Specs = repo.getItemSpecifications();
                List<InventoryItemSpecifications> ItemSpecs = repo.getInventoryItemSpecifications(itemid, 0, false);
                List<Inventory_Item_SubGroup_Specifications> SubGroupSpecs = new List<Inventory_Item_SubGroup_Specifications>();

                if (ItemSpecs == null || ItemSpecs.Count == 0 || SubGroupID > 0) SubGroupSpecs = repo.getItemSubGroupSpecificationOnly(SubGroupID);

                foreach (Inventory_Item_Specification spec in Specs)
                {
                    ItemSpecification rpt = new ItemSpecification();

                    rpt.SpecificationID = spec.ID;
                    rpt.SpecificationName = spec.SpecificationName;

                    if (ItemSpecs != null && SubGroupID != 0)
                    {
                        InventoryItemSpecifications itemSpec = ItemSpecs.FirstOrDefault(s => s.SpecificationID == spec.ID);
                        if (itemSpec != null)
                        {
                            rpt.SpecificationValue = itemSpec.SpecificationValue;
                            rpt.UOM = itemSpec.UOM;
                            rpt.OrderNo = itemSpec.OrderNo;
                            rpt.ShowInName = itemSpec.ShowInName;
                            rpt.IsSelected = true;
                        }
                        else
                        {
                            if (SubGroupSpecs != null && SubGroupID > 0)
                            {
                                if (SubGroupSpecs.FirstOrDefault(s => s.SpecificationID == spec.ID) != null) rpt.IsSelected = true;
                            }
                        }
                        Report.Add(rpt);
                    }
                    else
                    {
                        InventoryItemSpecifications itemSpec = ItemSpecs.FirstOrDefault(s => s.SpecificationID == spec.ID);
                        if (itemSpec != null)
                        {
                            rpt.SpecificationValue = itemSpec.SpecificationValue;
                            rpt.UOM = itemSpec.UOM;
                            rpt.OrderNo = itemSpec.OrderNo;
                            rpt.ShowInName = itemSpec.ShowInName;
                            rpt.IsSelected = true;
                            Report.Add(rpt);
                        }
                    }
                }

                return Report.OrderByDescending(s => s.IsSelected).ToList();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<ItemSpecification> getInventoryItemSpecifications(int SubGroupID, int itemid, int InventoryTypeID)
        {
            try
            {
                List<ItemSpecification> Report = new List<ItemSpecification>();
                List<Inventory_Item_Specification> Specs = repo.getItemSpecifications(InventoryTypeID);

                List<InventoryItemSpecifications> ItemSpecs = repo.getInventoryItemSpecifications(itemid, 0, false);
                List<Inventory_Item_SubGroup_Specifications> SubGroupSpecs = new List<Inventory_Item_SubGroup_Specifications>();

                if (ItemSpecs == null || ItemSpecs.Count == 0 || SubGroupID > 0)

                    SubGroupSpecs = repo.getItemSubGroupSpecificationOnly(SubGroupID);

                foreach (Inventory_Item_Specification spec in Specs)
                {
                    ItemSpecification rpt = new ItemSpecification();

                    rpt.SpecificationID = spec.ID;
                    rpt.SpecificationName = spec.SpecificationName;

                    if (ItemSpecs != null)
                    {
                        InventoryItemSpecifications itemSpec = ItemSpecs.FirstOrDefault(s => s.SpecificationID == spec.ID);
                        if (itemSpec != null)
                        {
                            rpt.SpecificationValue = itemSpec.SpecificationValue;
                            rpt.UOM = itemSpec.UOM;
                            rpt.OrderNo = itemSpec.OrderNo;
                            rpt.ShowInName = itemSpec.ShowInName;
                            rpt.IsSelected = true;
                        }
                        else
                        {
                            if (SubGroupSpecs != null && ItemSpecs.Count == 0)
                            {
                                if (SubGroupSpecs.FirstOrDefault(s => s.SpecificationID == spec.ID) != null) rpt.IsSelected = true;
                            }
                            else
                            {
                                if (SubGroupSpecs.FirstOrDefault(s => s.SpecificationID == spec.ID) != null) rpt.IsSelected = false;
                            }
                        }
                    }

                    Report.Add(rpt);
                }

                var data = Report.OrderBy(s => s.SpecificationName).ToList();

                return data.OrderByDescending(s => s.IsSelected).ToList();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<Inventory_Item_Specification> getItemSpecificationList(int InventorytypeId)
        {
            try
            {
                return repo.getItemSpecifications(InventorytypeId);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Item_Specification saveItemSpecification(CommonDataEntryClass Data)
        {
            try
            {
                Inventory_Item_Specification iis = new ProcurementGenericRepository<Inventory_Item_Specification>().Find(o => o.ID == Data.ID).FirstOrDefault();
                if (iis == null)
                {
                    //SAVE NEW InventoryItemSpecification
                    Inventory_Item_Specification newiis = new Inventory_Item_Specification();

                    newiis.SpecificationName = Data.ItemName;
                    newiis.UOM = Data.Remarks;
                    newiis.IsActive = true;
                    newiis.CreatedOn = DateTime.Now;
                    newiis.CreatedByID = Data.EmployeeCode;
                    newiis.InventoryTypeID = Data.TypeID;
                    return repo.saveItemSpecification(newiis);
                }
                else
                {
                    iis.SpecificationName = Data.ItemName;
                    iis.UOM = Data.Remarks;
                    iis.UpdatedOn = DateTime.Now;
                    iis.UpdatedByID = Data.EmployeeCode;
                    iis.InventoryTypeID = Data.TypeID;

                    return repo.updateItemSpecification(iis);
                }
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Item_Specification deleteItemSpecification(int ID, string EmployeeID)
        {
            try
            {
                return repo.deleteItemSpecification(ID, EmployeeID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<SubGroupSpecification> getItemSubGroupSpecification(int subgroupid)
        {
            try
            {
                return repo.getItemSubGroupSpecification(subgroupid);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<SubGroupSpecification> getInventorySubGroupSpecification(int subgroupid, int inventorytypeid)
        {
            try
            {
                return repo.getInventorySubGroupSpecification(subgroupid, inventorytypeid);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<SubGroupSpecification> getInventorySpecification(int inventoryTypeID)
        {
            try
            {
                return repo.getInventorySpecification(inventoryTypeID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<Inventory_Item_UsageTypes> getItemUsageType()
        {
            try
            {
                return repo.getItemUsageType();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Boolean saveItemSubGroupSpecification(CommonDataEntryClass Data)
        {
            try
            {
                if (string.IsNullOrEmpty(Data.Data))
                {
                    Error = new Exception("Data field is not found");
                    return false;
                }

                string[] specs = Data.Data.Split(';');

                deleteExistingSubGroupSpecification(Data.ID);

                foreach (string specID in specs)
                {
                    if (string.IsNullOrEmpty(specID)) continue;
                    repo.saveItemSubGroupSpecification(Data.ID, int.Parse(specID), Data.EmployeeCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                Error = ex;
                return false;
            }
        }

        public Boolean deleteSubGroupSupplier(int SubGroupID, string suppliercode, string EmployeeID)
        {
            try
            {
                return repo.deleteSubGroupSupplier(SubGroupID, suppliercode, EmployeeID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return false;
            }
        }

        public Boolean saveSubGroupSupplier(CommonDataEntryClass Data)
        {
            try
            {
                if (string.IsNullOrEmpty(Data.Data))
                {
                    Error = new Exception("Data field is not found");
                    return false;
                }

                string[] supplierCodes = Data.Data.Split(';');

                foreach (string supplierCode in supplierCodes)
                {
                    if (string.IsNullOrEmpty(supplierCode)) continue;
                    repo.saveSubGroupSupplier(Data.ID, supplierCode, Data.EmployeeCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                Error = ex;
                return false;
            }
        }

        private Boolean deleteExistingSubGroupSpecification(int SubGroupID)
        {
            try
            {
                return repo.deleteExistingSubGroupSpecification(SubGroupID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return false;
            }
        }

        // REQUISITION ITEM
        public List<Inventory_Item_Version_State> getVersionStates()
        {
            try
            {
                return repo.getVersionStates();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Items saveInventoryItem(InventoryItemNew Data)
        {
            try
            {
                // Item Data Validation
                string itemValidation = checkNewItem(Data);
                if (!string.IsNullOrEmpty(itemValidation))
                {
                    Error = new Exception("Failed to save new item. " + itemValidation);
                    return null;
                }

                return repo.saveInventoryItem(Data);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }


        private string checkNewItem(InventoryItemNew NewItem)
        {
            try
            {
                if (string.IsNullOrEmpty(NewItem.ItemName)) return "Invalid item name";
                if (NewItem.SubGroupId <= 0) return "Invalid sub group id.";
                //if (NewItem.MOQ <= 0) return "Item quantity must be higher or equal to Minimum Order Quantity(MOQ)";
                if (string.IsNullOrEmpty(NewItem.EmployeeID)) return "Invalid EmployeeID.";

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public Boolean saveInventoryItemVersion(InventoryItemVersionNew Data)
        {
            try
            {
                // VALIDATION
                if (string.IsNullOrEmpty(Data.Data))
                {
                    Error = new Exception("Data field is not found");
                    return false;
                }

                List<InventoryItemVersionSpecificationNew> specs = JSONSerialize.getJSON<InventoryItemVersionSpecificationNew>(Data.Data);

                if (specs == null || specs.Count() == 0)
                {
                    Error = new Exception("Specification list is not found. Please try again.");
                    return false;
                }

                Inventory_Item_Versions version = repo.getInventoryItemVersion(Data.ItemID);

                // Create New Version
                if (version == null) version = repo.saveInventoryItemVersion(Data.ItemID, Data.VersionStateID, Data.EmployeeID);

                //First InActive Previous Specs
                List<Inventory_Item_Version_Details> ExistItems = repo.getInventoryItemVersionDetails(version.ID);
                foreach (var item in ExistItems)
                {
                    repo.removeInventoryItemVersionDetails(item);
                }

                // Save Version Specifications
                foreach (InventoryItemVersionSpecificationNew spec in specs)
                {
                    repo.saveInventoryItemVersionDetails(version.ID, spec);
                }

                return true;
            }
            catch (Exception ex)
            {
                Error = ex;
                return false;
            }
        }

        public List<InventoryItems> getInventoryItems(int SubGroupID)
        {
            try
            {
                return repo.getInventoryItems(SubGroupID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public string getItemNameWithSpec(string ItemName, List<ItemSpecification> Specs)
        {
            try
            {
                return repo.getItemnameWithSpec(ItemName, Specs);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public InventoryItems getInventoryItem(int ItemID)
        {
            try
            {
                return repo.getInventoryItem(ItemID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        //Unit of measurment CRUD Start

        public List<UOMDto> getUOMList()
        {
            try
            {
                return repo.getUOMList();
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public UnitOfMeasurement AddUOM(UOMDto uom)
        {
            try
            {
                UnitOfMeasurement UOMItem = new UnitOfMeasurement();
                UOMItem.CreatedByID = uom.CreatedByID;
                UOMItem.CreatedOn = DateTime.Now;
                UOMItem.IsActive = true;
                UOMItem.UOM = uom.UOM;
                return repo.addUOM(UOMItem);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public UnitOfMeasurement updateUOM(UOMDto uom)
        {
            try
            {
                UnitOfMeasurement UOMItem = repo.getUOMById(uom.ID);
                UOMItem.CreatedByID = uom.CreatedByID;
                UOMItem.CreatedOn = DateTime.Now;
                UOMItem.IsActive = true;
                UOMItem.UOM = uom.UOM;
                return repo.updateUOM(UOMItem);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public UnitOfMeasurement deleteUOM(UOMDto uom)
        {
            try
            {
                UnitOfMeasurement UOMItem = repo.getUOMById(uom.ID);
                if (UOMItem == null)
                {
                    return null;
                }
                else
                {
                    UOMItem.IsActive = false;
                    UOMItem.CreatedByID = uom.CreatedByID;
                    UOMItem.CreatedOn = DateTime.Now;
                    return repo.updateUOM(UOMItem);
                }
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        //Unit of measurment CRUD End

        public List<NonproductionItemPurchaseHistoryDto> nonProductionItemHistory(int itemID)
        {
            try
            {
                return repo.nonProductionItemHistory(itemID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<InventoryAllItemListAndSearchDto> getInventoryAllItemListAndSearch(InventoryItemListSearchPostDto data)
        {
            try
            {
                return repo.getInventoryAllItemListAndSearch(data);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Inventory_Stores getInventoryStoreById(int storeID)
        {
            try
            {
                return repo.getInventoryStoreById(storeID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }
    }
}