using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using WebERPAPI.BusinessLogic.Interfaces;
using WebERPAPI.BusinessLogic.Map;
using WebERPAPI.BusinessLogic.User;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.InventoryNonProduction;
using WebERPAPI.DTO;
using WebERPAPI.DTO.InventoryNonProduction;
using WebERPAPI.Library;

namespace WebERPAPI.BusinessLogic.InventoryNonProduction
{
    public class ItemIssueService
    {
        public Exception Error = new Exception();
        private ConsumptionRequisitionRepository cRepo = new ConsumptionRequisitionRepository();

        private ItemStockRepository sRepo = new ItemStockRepository();
        private ItemReceiveRepository rRepo = new ItemReceiveRepository();

       
        private string checkItemIssue(ItemIssuesNewDto IssueData)
        {
            try
            {
                DateTime lastReceiveDate = DateTime.Now.AddHours(-(DateTime.Now.Hour + 2));

                if (string.IsNullOrEmpty(IssueData.Data)) return "Issue details not found.";
                if (string.IsNullOrEmpty(IssueData.CreatedByID)) return "CreatedByID not found";

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }


        private string checkItemReceive(ItemReceiveAcknowledgementNewDto ReceiveData)
        {
            try
            {
                if (string.IsNullOrEmpty(ReceiveData.Data)) return "Receive details not found.";
                if (string.IsNullOrEmpty(ReceiveData.CreatedByID)) return "CreatedByID not found";

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        //ITEM CONVERSION

      
        //check is in final approval item conversion list
        private bool isInconversionApproveItemList(List<ItemConversionDetailsReportDto> ConversionDetailList, int ItemID)
        {
            foreach (var item in ConversionDetailList)
            {
                if (item.ItemID == ItemID) return true;
            }

            return false;
        }

    }
}