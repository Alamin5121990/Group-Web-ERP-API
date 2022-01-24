using System.Collections.Generic;
using WebERPAPI.DTO.Inventory;
using WebERPAPI.Data;
using WebERPAPI.Data.Repository.Inventory;
using WebERPAPI.Data.Models.PROCESSERVER;
using System;
using WebERPAPI.DTO.Supplier;

namespace WebERPAPI.BusinessLogic.Inventory
{
    public class SupplierService 
    {
        private SupplierRepositories repo = new SupplierRepositories();
        private BillService service = new BillService();

        public new Exception Error = new Exception();

        public List<PurchaseOrderSupplier> getPurchaseOrderSupplier(string SupplierType)
        {
            return repo.getPurchaseOrderSupplier(SupplierType);
        }

        //SUPPLIER ADDING
        public List<Supplier_Types> getSupplierTypeList()
        {
            return repo.getSupplierTypeList();
        }

        public List<Supplier_Categories> getSupplierCategoryList()
        {
            return repo.getSupplierCategoryList();
        }

        public Supplier saveSupplier(Supplier supplier)
        {
            try
            {
                //updating supplier
                if (supplier.ID > 0 && supplier.IsCanceled == true)
                {
                    supplier.CanceledOn = DateTime.Now;
                    return repo.updateSupplierGeneric(supplier);
                }
                // cancelling supplier
                else if (supplier.ID > 0)
                {
                    supplier.DateUpdated = DateTime.Now;
                    return repo.updateSupplierGeneric(supplier);
                }

                //adding new supplier
                Supplier lastSupplier = repo.getLatestSupplier();
                string ExistingSupplierID = "", NewSupplierID = string.Empty;
                if (lastSupplier != null)
                {
                    ExistingSupplierID = lastSupplier.SupplierID;
                    int result = Convert.ToInt32(ExistingSupplierID.Substring(ExistingSupplierID.LastIndexOf('-') + 1));
                    result++;
                    NewSupplierID = "S-" + result.ToString();

                    supplier.SupplierID = NewSupplierID;

                    supplier.SupplierType = "";
                    supplier.SupplierCategory = "";
                    supplier.MachineNameIP = "";
                    supplier.Location = "HO";
                }

                return repo.saveSupplier(supplier);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        //SUPPLIER SETTING COMPONENT services

        public List<Supplier> getSupplierListByTypeAndCategory(int? TypeID, int? CategoryID)
        {
            try
            {
                return repo.getSupplierListByTypeAndCategory(TypeID, CategoryID);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Supplier_Categories saveSupplierCategory(Supplier_Categories item)
        {
            try
            {
                return repo.saveSupplierCategory(item);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Supplier_Types saveSupplierType(Supplier_Types item)
        {
            try
            {
                return repo.saveSupplierType(item);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Supplier_Categories updateSupplierCategory(Supplier_Categories item)
        {
            try
            {
                return repo.updateSupplierCategory(item);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Supplier_Types updateSupplierType(Supplier_Types item)
        {
            try
            {
                return repo.updateSupplierType(item);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Supplier_Categories removeSupplierCategory(Supplier_Categories item)
        {
            try
            {
                item = repo.getSupplierCategoryItem(item.ID);
                if (item == null)
                {
                    Error = new Exception("Not found.");
                    return null;
                }

                item.IsActive = false;
                return repo.updateSupplierCategory(item);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public Supplier_Types removeSupplierType(Supplier_Types item)
        {
            try
            {
                item = repo.getSupplierTypeItem(item.ID);
                if (item == null)
                {
                    Error = new Exception("Not found.");
                    return null;
                }

                item.IsActive = false;
                return repo.updateSupplierType(item);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public List<SupplierListWithPOAndBillTotalDto> getSupplierListWithPOAndBillTotal()
        {

            try
            {
                return  repo.getSupplierListWithPOAndBillTotal();

              
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }
    }
}