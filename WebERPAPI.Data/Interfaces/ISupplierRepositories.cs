using System.Collections.Generic;
using WebERPAPI.DTO.Inventory;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.Data.Repository.Inventory
{
    public interface ISupplierRepositories
    {
        Supplier getSupplierDetails(string SupplierID);

    }
}