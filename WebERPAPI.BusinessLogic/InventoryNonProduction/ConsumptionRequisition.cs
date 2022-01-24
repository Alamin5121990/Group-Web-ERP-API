using System;
using System.Collections.Generic;
using System.Linq;
using WebERPAPI.BusinessLogic.Interfaces;
using WebERPAPI.BusinessLogic.Map;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.Repository.InventoryNonProduction;
using WebERPAPI.DTO;
using WebERPAPI.DTO.InventoryNonProduction;
using WebERPAPI.Library;

namespace WebERPAPI.BusinessLogic.InventoryNonProduction
{
    public class ConsumptionRequisition 
    {
        public Exception Error = new Exception();
        private ConsumptionRequisitionRepository repo = new ConsumptionRequisitionRepository();

       
        private string checkRequisition(ConsumptionRequisitionNew RequisitionData)
        {
            try
            {
                DateTime lastReceiveDate = DateTime.Now.AddHours(-(DateTime.Now.Hour + 2));

                if (string.IsNullOrEmpty(RequisitionData.Data)) return "Requisition details not found.";
                if (string.IsNullOrEmpty(RequisitionData.CreatedByID)) return "Employee code not found";

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        private string checkRequisitionDetails(List<ConsumptionRequisitionNewItem> RequisitionItems, Boolean PreventDuplicate = false)
        {
            try
            {
                foreach (ConsumptionRequisitionNewItem item in RequisitionItems)
                {
                    if (item.ItemID <= 0) return "Item id not found";

                    //item.
                }

                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

   
        public List<ConsumptionRequisitionsApprovalPendingNPDto> getRequisitionsApprovalPending(string EmployeeID)
        {
            try
            {
                //return repo.getRequisitionsApprovalPending(EmployeeID);

                List<ConsumptionRequisitionsApprovalPendingNPDto> data = repo.getRequisitionsApprovalPending(EmployeeID);

                List<ConsumptionRequisitionsApprovalPendingNPDto> Filterdata = data.GroupBy(x => x.RequisitionCode).Select(x => x.FirstOrDefault()).ToList();

                return Filterdata;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<ConsumptionRequisitionsApprovalPendingNPDto> getRequisitionList(string EmployeeID)
        {
            try
            {
                List<ConsumptionRequisitionsApprovalPendingNPDto> data = repo.getRequisitionList(EmployeeID); ;

                List<ConsumptionRequisitionsApprovalPendingNPDto> Filterdata = data.GroupBy(x => x.RequisitionCode).Select(x => x.FirstOrDefault()).ToList();
                return Filterdata;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

   

        public ConsumptionRequisitionNPDto getRequisition(string RequisitionCode, int RequisitionID)
        {
            try
            {
                return repo.getRequisition(RequisitionCode, RequisitionID);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<ConsumptionRequisitionDetailsNPDto> getRequisitionDetails(int RequisitionID)
        {
            try
            {
                return repo.getRequisitionDetails(RequisitionID);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public object getRequisitionReport(string RequisitionCode, int RequisitionID)
        {
            try
            {
                ConsumptionRequisitionNPDto Requisition = repo.getRequisition(RequisitionCode, RequisitionID);
                if (Requisition == null) throw new Exception("Requisition master data not found");
                List<ConsumptionRequisitionDetailsNPDto> Details = repo.getRequisitionDetails(Requisition.ID.GetValueOrDefault());
                List<ConsumptionRequisitionItemsInOtherReqNPDto> OtherRequisitions = repo.getRequisitionItemsInOtherReqNP(Requisition.ID.GetValueOrDefault(), false);
                List<EmployeeConsumptionRequisitionItemsNPDto> PreviousRequisitions = repo.getEmployeeRequisitionItemsNP(Requisition.CreatedByID);

                return new { Requisition, Details, OtherRequisitions, PreviousRequisitions };
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<ConsumptionRequisitionForApprovalDto> getRequisitionForApprovalItemIssue(string EmployeeID)
        {
            try
            {
                return repo.getRequisitionForApprovalItemIssue(EmployeeID);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<ConsumptionRequisitionForItemIssueDto> getRequisitionForItemIssue(string EmployeeID)
        {
            try
            {
                return repo.getRequisitionForItemIssue(EmployeeID);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<ConsumptionRequisitionStockDto> getConsumptionItemStockout(DateTime fromdate, DateTime todate)
        {
            try
            {
                return repo.getConsumptionItemStockout(fromdate, todate);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<ConsumptionRequisitionStockDto> getConsumptionItemStockin(DateTime fromdate, DateTime todate)
        {
            try
            {
                return repo.getConsumptionItemStockin(fromdate, todate);
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<EmployeeInventoryItemsDto> getEmployeeInventoryItems(string EmployeeID, string SearchText1, string SearchText2)
        {
            try
            {
                return repo.getEmployeeInventoryItems(EmployeeID, SearchText1, SearchText2);
            }
            catch (Exception ex) { Error = ex; return null; }
        }
    }
}