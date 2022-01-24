using System.Collections.Generic;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory.Procurement.CS;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.BusinessLogic.Interfaces
{
    public interface IComparativeStudyNP
    {
        Inventory_Comparative_Study saveComparativeStudy(CommonDataEntryClass Quotation);

        Inventory_Comparative_Study updateComparativeStudy(CommonDataEntryClass CSData);

        List<ComparativeStudyListNP> getComparativeStudy(int empid, string CSCode, int ActionGroupID);

        object getComparativeStudyReport(string CSCode, int CSID);

        Inventory_Comparative_Study cancelComparativeStudy(CommonDataEntryClass Data);

        List<ComparativeStudyListNP> getComparativeStudyStatusReport(int MainGroupID, int inventorytypeid);
    }
}