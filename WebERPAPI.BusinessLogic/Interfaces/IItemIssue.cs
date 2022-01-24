using System.Collections.Generic;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.BusinessLogic.Interfaces
{
    public interface IItemIssue
    {
        object getItemIssueNew(int RequisitionId);

        Inventory_ItemIssues saveItemIssue(ItemIssuesNewDto Data);

        bool closeRequisition(BaseEntityNew Data);

        List<InventoryItemIssuedDto> getInventoryItemIssued(int MainGroupID, string DateFrom, string DateTo);

        object getItemIssueReport(string IssueCode, int IssueID);

        bool cancelItemIssue(BaseEntityNew Data);

        List<EmployeeItemIssuedDto> getEmployeeItemIssued(string EmployeeID);

        Inventory_ItemReceive_Acknowledgement saveItemReceive(ItemReceiveAcknowledgementNewDto Data);
    }
}