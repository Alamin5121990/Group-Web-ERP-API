using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.DTO.Supplier;
using WebERPAPI.Data.Repository.InventoryNonProduction;

namespace WebERPAPI.Data.Repository.Inventory
{
    public class SupplierRepositories
    {
        public Exception error = new Exception();

        public List<SupplierNonProduction> getSupplierList()
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    return db.Database.SqlQuery<SupplierNonProduction>("getSupplierListNP").ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }
        public List<SupplierPurchaseHistory> getSupplierPurchaseHistory(string SupplierID, string MaterialCode = "0")
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    var supplierID = new SqlParameter("@SupplierID", SupplierID);
                    var materialCode = new SqlParameter("@MaterialCode", MaterialCode);

                    return db.Database.SqlQuery<SupplierPurchaseHistory>("getSupplierPurchaseHistory @SupplierID, @MaterialCode", supplierID, materialCode).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public Supplier getSupplierDetails(string SupplierID)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    return db.Suppliers.Where(s => s.SupplierID == SupplierID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

    
        public decimal getSupplierFinancialYearBillTotal(string SupplierCode, int FinancialYearID = 1)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    var financialYearID = new SqlParameter("@FinancialYearID", FinancialYearID);
                    var supplierCode = new SqlParameter("@SupplierCode", SupplierCode);

                    var val = db.Database.SqlQuery<SingleValueDecimal>("getSupplierFinancialYearBillTotal @FinancialYearID, @SupplierCode", financialYearID, supplierCode).FirstOrDefault();
                    if (val != null && val.ReturnValue != null) return val.ReturnValue.GetValueOrDefault();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return 0;
            }
        }

        public List<SupplierList> getSupplierAndIndentorList()
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    return db.Database.SqlQuery<SupplierList>("getSupplierList").ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public Boolean updateSupplier(Supplier supplier)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    var sup = db.Suppliers.Where(s => s.SupplierID == supplier.SupplierID).FirstOrDefault();

                    if (sup != null)
                    {
                        sup.ContactPerson = supplier.ContactPerson;
                        sup.Fax = supplier.Fax;
                        sup.Phone = supplier.Phone;
                        sup.Address = supplier.Address;
                        sup.Email = supplier.Email;

                        sup.DateUpdated = DateTime.Now;
                    }
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public object getSupplierSupplyChainProfile(SearchTag sTag)
        {
            try
            {
                DateTime dateFrom = DateTime.Now.AddMonths(-6);

                using (SCMEntities db = new SCMEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;

                    var Supplier = (from s in db.Suppliers
                                    where s.SupplierID == sTag.Code
                                    select new { SupplierName = s.SupplierName, Address = s.Address }).FirstOrDefault();

                    var CS = (from cs in db.Comparative_Study
                              join cd in db.Comparative_Study_Details on cs.ID equals cd.CSID
                              join m in db.Materials on cd.MaterialCode equals m.MaterialCode
                              where cd.SupplierCode == sTag.Code && cs.CreatedOn >= dateFrom
                              orderby cs.CreatedOn descending
                              select new { cs.CSCode, m.MaterialName, cs.CreatedOn }).Take(10).ToList();

                    var PurchaseOrders = (from po in db.POMasters
                                          join pd in db.PODetails on po.POID equals pd.POID
                                          join m in db.Materials on pd.MaterialCode equals m.MaterialCode
                                          where po.SupplierID == sTag.Code && po.DateAdded >= dateFrom
                                          orderby po.DateAdded descending
                                          select new { po.POID, m.MaterialName, po.DateAdded }).Take(10).ToList();

                    return new { sTag, Supplier, CS, PurchaseOrders };
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<SupplierList> getSupplierBySearch(string SearchText)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    return (from s in db.Suppliers
                            where s.SupplierName.Contains(SearchText)
                            select new SupplierList
                            {
                                SupplierID = s.SupplierID,
                                SupplierName = s.SupplierName,
                                Address = s.Address,
                                ContactPerson = s.ContactPerson,
                                Email = s.Email,
                                Phone = s.Phone,
                                SupplierType = s.SupplierType
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public object getSupplierShortProfileBySearch(SearchTag sTag, string SearchText)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;

                    var Supplier = (from m in db.Suppliers
                                    where m.SupplierName.Contains(SearchText)
                                    select m).Take(10).ToList();

                    var ProfileData = getSupplierShortProfile(Supplier[0].SupplierID);
                    return new { sTag, Supplier, ProfileData };
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public object getSupplierShortProfile(string SupplierCode)
        {
            try
            {
                DateTime dateFrom = DateTime.Now.AddMonths(-6);

                using (SCMEntities db = new SCMEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;

                    var CS = (from cs in db.Comparative_Study
                              join cd in db.Comparative_Study_Details on cs.ID equals cd.CSID
                              join m in db.Materials on cd.MaterialCode equals m.MaterialCode
                              join prd in db.POReqDetails on new { req = cd.RequisitionCode, mat = cd.MaterialCode } equals new { req = prd.RequisitionID, mat = prd.MaterialCode }
                              where cd.SupplierCode == SupplierCode && cs.CreatedOn >= dateFrom
                              orderby cs.CreatedOn descending
                              select new { cs.CSCode, m.MaterialName, cd.Quantity, Rate = cd.Price, Date = cs.CreatedOn, RequisitionCode = prd.RequisitionID }).Take(10).ToList();

                    return new { CS };
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public MaterialSourceApproval getMaterialSourceApproval(string SupplierCode, string MaterialCode)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    return db.MaterialSourceApprovals.FirstOrDefault(m => m.MaterialCode == MaterialCode && m.SupplierID == SupplierCode);
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public MaterialSourceApproval getMaterialActiveSourceApproval(string SupplierCode, string MaterialCode)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    var data = db.MaterialSourceApprovals.FirstOrDefault(m => m.MaterialCode == MaterialCode && m.SupplierID == SupplierCode && m.IsInActive == false);
                    return data;
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<SupplierMaterialList> getSupplierMaterialList(string SupplierID)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    var supplierID = new SqlParameter("@SupplierID", SupplierID);
                    return db.Database.SqlQuery<SupplierMaterialList>("getSupplierMaterialList @SupplierID", supplierID).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<PurchaseOrderSupplier> getPurchaseOrderSupplier(string SupplierType)
        {
            try
            {
                using (InventoryEntities db = new InventoryEntities())
                {
                    var supplierType = new SqlParameter("@SupplierType", SupplierType);
                    return db.Database.SqlQuery<PurchaseOrderSupplier>("getPurchaseOrderSupplier @SupplierType", supplierType).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<SupplierNonProduction> getMainGroupSuppliers(int MainGroupID)
        {
            try
            {
                var SubgroupSupplier = new ProcurementGenericRepository<Inventory_SubGroup_Suppliers>().Find(i => i.SubGroupID == MainGroupID && i.IsActive == true).ToList();

                List<SupplierNonProduction> supplierdtoList = new List<SupplierNonProduction>();

                foreach (var item in SubgroupSupplier)
                {
                    SupplierNonProduction supplierdto = new SupplierNonProduction();
                    var supplier = new ProcurementGenericRepository<Supplier>().Find(s => s.SupplierID == item.SupplierCode).FirstOrDefault();
                    supplierdto.SupplierCode = item.SupplierCode;
                    supplierdto.SupplierName = supplier.SupplierID;
                    supplierdto.ContactPerson = supplier.ContactPerson;
                    supplierdto.Phone = supplier.Phone;
                    supplierdto.Email = supplier.Email;
                    supplierdtoList.Add(supplierdto);
                }

                return supplierdtoList;
                //using (InventoryEntities db = new InventoryEntities())
                //{
                //    db.Configuration.LazyLoadingEnabled = false;

                //    return
                //        (from gs in db.Inventory_MainGroup_Suppliers
                //         join s in db.Suppliers on gs.SupplierCode equals s.SupplierID
                //         where gs.MainGroupID == MainGroupID
                //         select new SupplierNonProduction
                //         {
                //             SupplierCode = gs.SupplierCode,
                //             SupplierName = s.SupplierName,
                //             ContactPerson = s.ContactPerson,
                //             Phone = s.Phone,
                //             Email = s.Email
                //         }
                //        ).ToList();
                //}
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        //SUPPLIER CRUD REPOSITORIES

        public List<Supplier_Types> getSupplierTypeList()
        {
            return new InventoryGenericRepository<Supplier_Types>().Find(s => s.IsActive == true).OrderBy(s => s.ID).ToList();
        }

        public List<Supplier_Categories> getSupplierCategoryList()
        {
            return new InventoryGenericRepository<Supplier_Categories>().Find(s => s.IsActive == true).OrderBy(s => s.ID).ToList();
        }

        public Supplier getLatestSupplier()
        {
            return new InventoryGenericRepository<Supplier>().FindOneUsingSP("getLatestSupplier");
        }

        public Supplier saveSupplier(Supplier supplier)
        {
            return new InventoryGenericRepository<Supplier>().Insert(supplier);
        }

        public Supplier updateSupplierGeneric(Supplier supplier)
        {
            return new InventoryGenericRepository<Supplier>().Update(supplier, i => i.ID == supplier.ID);
        }

        //SUPPLIER SETTING COMPONENT repo

        public List<Supplier> getSupplierListByTypeAndCategory(int? TypeID, int? CategoryID)
        {
            return new InventoryGenericRepository<Supplier>().FindUsingSP("getSupplierListByTypeAndCategoryID @TypeID, @CategoryID", new SqlParameter("@TypeID", TypeID), new SqlParameter("@CategoryID", CategoryID)).ToList();
        }

        //get item
        public Supplier_Categories getSupplierCategoryItem(int ID)
        {
            return new InventoryGenericRepository<Supplier_Categories>().Find(i => i.ID == ID && i.IsActive == true).FirstOrDefault();
        }

        public Supplier_Types getSupplierTypeItem(int ID)
        {
            return new InventoryGenericRepository<Supplier_Types>().Find(i => i.ID == ID && i.IsActive == true).FirstOrDefault();
        }

        //save new item
        public Supplier_Categories saveSupplierCategory(Supplier_Categories item)
        {
            return new InventoryGenericRepository<Supplier_Categories>().Insert(item);
        }

        public Supplier_Types saveSupplierType(Supplier_Types item)
        {
            return new InventoryGenericRepository<Supplier_Types>().Insert(item);
        }

        //update item
        public Supplier_Categories updateSupplierCategory(Supplier_Categories item)
        {
            return new InventoryGenericRepository<Supplier_Categories>().Update(item, i => i.ID == item.ID);
        }

        public Supplier_Types updateSupplierType(Supplier_Types item)
        {
            return new InventoryGenericRepository<Supplier_Types>().Update(item, i => i.ID == item.ID);
        }

        public List<SupplierListWithPOAndBillTotalDto> getSupplierListWithPOAndBillTotal()
        {
            return new InventoryGenericRepository<SupplierListWithPOAndBillTotalDto>().FindUsingSP("getSupplierListWithPOAndBillTotal");
        }
    }
}