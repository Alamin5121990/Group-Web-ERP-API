using System.Collections.Generic;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.Procurement;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.BusinessLogic.Interfaces
{
    public interface IRequisitionNP
    {
        Inventory_Items deleteInventoryItem(int itemid, string employeeid);

        Inventory_Requisition_Items deleteRequisitionItem(int requisitionid, int itemid, string employeeid);

        List<string> getItemUOM();

        object getRequisitionDetails(int RequisitionID);

        object getRequisitionReport(string RequisitionCode, int requisitionid);

        List<InventoryRequisitionDetails> getInventoryRequisitionDetails(int RequisitionID);

        List<RequistionSearchItems> getRequisitionsBySearch(int employeeid, int InventoryTypeID, string DateFrom, string DateTo, string SearchText);

        List<InventoryRequisitionsForApproval> getRequisitionsForApproval(int EmployeeID, int ActionID);

        List<Inventory_Requisition_Type> getRequisitionTypes();

        List<InventoryPrivilege> getInventoryPrivilege(int inventorytypeid, int userid);

        string getInventoryRequisitionForBrands(int RequisitionID);

        string getInventoryRequisitionForMonths(int RequisitionID);

        object getItemReport(int itemid, string itemcode);

        bool saveInventoryPrivilege(InventoryPrivilegeNew Data);

        Inventory_Requisitions createInventoryRequisition(InventoryRequisitionNew NewReq);

        // UPDATE
        Inventory_Requisitions updateInventoryRequisition(InventoryRequisitionNew NewReq);

        // VERIFY
        Inventory_Requisitions verifyInventoryRequisition(int ActionID, CommonDataEntryClass Data);
    }
}