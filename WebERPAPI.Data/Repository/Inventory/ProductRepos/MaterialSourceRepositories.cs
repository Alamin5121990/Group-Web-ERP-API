using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.Data.Repository.Inventory.ProductRepos
{
    public class MaterialSourceRepositories
    {
        public MaterialSourceApproval_ChangesHistory saveSourceApprovalChangesHistory(MaterialSourceApproval_ChangesHistory changesHistory)
        {
            return new InventoryGenericRepository<MaterialSourceApproval_ChangesHistory>().Insert(changesHistory);
        }

        public Supplier getMaterialSupplier(string suppliercode)
        {
            return new InventoryGenericRepository<Supplier>().Find(s => s.SupplierID == suppliercode).FirstOrDefault();
        }

        public MaterialSourceApproval updateSourceApproval(MaterialSourceApproval sourceApproval)
        {
            return new InventoryGenericRepository<MaterialSourceApproval>().Update(sourceApproval, s => s.ID == sourceApproval.ID);
        }

        public MaterialSourceApproval getSourceApproval(int id)
        {
            return new InventoryGenericRepository<MaterialSourceApproval>().Find(m => m.ID == id).FirstOrDefault();
        }

        public MaterialSourceApproval getLastSourceApproval(MaterialSourceApproval sourceApproval)
        {
            return new InventoryGenericRepository<MaterialSourceApproval>().Find(m => m.MaterialCode == sourceApproval.MaterialCode).OrderByDescending(i => i.ID).FirstOrDefault();
        }

        public MaterialSourceApproval saveSourceApproval(MaterialSourceApproval sourceApproval)
        {
            return new InventoryGenericRepository<MaterialSourceApproval>().Insert(sourceApproval);
        }

        public MaterialSourceApproval_Remarks saveMaterialSourceRemarks(MaterialSourceApproval_Remarks remark)
        {
            return new InventoryGenericRepository<MaterialSourceApproval_Remarks>().Insert(remark);
        }

      
        public MaterialSourceApproval_Remarks sourceApprovalRemarkRemove(int RemarkID)
        {
            var remark = new InventoryGenericRepository<MaterialSourceApproval_Remarks>().Find(r => r.ID == RemarkID).FirstOrDefault();

            remark.IsActive = false;
            remark.UpdatedByID = remark.CreatedByID;
            remark.UpdatedOn = DateTime.Now;

            return new InventoryGenericRepository<MaterialSourceApproval_Remarks>().Update(remark, r => r.ID == remark.ID);
        }

    }
}