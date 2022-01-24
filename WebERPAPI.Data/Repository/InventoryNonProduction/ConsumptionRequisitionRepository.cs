using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.Data.GenericRepository;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO;
using WebERPAPI.DTO.InventoryNonProduction;

namespace WebERPAPI.Data.Repository.InventoryNonProduction
{
    public class ConsumptionRequisitionRepository
    {
       



        public List<ConsumptionRequisitionsApprovalPendingNPDto> getRequisitionsApprovalPending(string EmployeeID)
        {
            return new NonProductionGenericRepository<ConsumptionRequisitionsApprovalPendingNPDto>().FindUsingSP("getConsumptionRequisitionsApprovalPendingNP @EmployeeID",
                new SqlParameter("@EmployeeID", EmployeeID));
        }

        public List<ConsumptionRequisitionsApprovalPendingNPDto> getRequisitionList(string EmployeeID)
        {
            return new NonProductionGenericRepository<ConsumptionRequisitionsApprovalPendingNPDto>().FindUsingSP("getConsumptionRequisitionsList @EmployeeID",
                new SqlParameter("@EmployeeID", EmployeeID));
        }

      
        public ConsumptionRequisitionNPDto getRequisition(string RequisitionCode, int RequisitionID)
        {
            return new NonProductionGenericRepository<ConsumptionRequisitionNPDto>().FindOneUsingSP("getConsumptionRequisitionNP @RequisitionCode, @RequisitionID",
                new SqlParameter("@RequisitionCode", RequisitionCode), new SqlParameter("@RequisitionID", RequisitionID));
        }

        public List<ConsumptionRequisitionDetailsNPDto> getRequisitionDetails(int RequisitionID)
        {
            return new NonProductionGenericRepository<ConsumptionRequisitionDetailsNPDto>().FindUsingSP("getConsumptionRequisitionDetailsNP @RequisitionID",
                new SqlParameter("@RequisitionID", RequisitionID));
        }

        public List<ConsumptionRequisitionItemsInOtherReqNPDto> getRequisitionItemsInOtherReqNP(int RequisitionID, Boolean ApprovedOnly)
        {
            return new NonProductionGenericRepository<ConsumptionRequisitionItemsInOtherReqNPDto>().FindUsingSP("getConsumptionRequisitionItemsInOtherReqNP @RequisitionID, @ApprovedOnly",
                new SqlParameter("@RequisitionID", RequisitionID), new SqlParameter("@ApprovedOnly", ApprovedOnly));
        }

        public List<ConsumptionRequisitionForApprovalDto> getRequisitionForApprovalItemIssue(string EmployeeID)
        {
            return new NonProductionGenericRepository<ConsumptionRequisitionForApprovalDto>().FindUsingSP("getConsumptionRequisitionForApprovalItemList @EmployeeID",
                new SqlParameter("@EmployeeID", EmployeeID));
        }

        public List<ConsumptionRequisitionForItemIssueDto> getRequisitionForItemIssue(string EmployeeID)
        {
            return new NonProductionGenericRepository<ConsumptionRequisitionForItemIssueDto>().FindUsingSP("getConsumptionRequisitionForItemIssue @EmployeeID",
                new SqlParameter("@EmployeeID", EmployeeID));
        }

        public List<ConsumptionRequisitionStockDto> getConsumptionItemStockout(DateTime fromdate, DateTime todate)
        {
            return new NonProductionGenericRepository<ConsumptionRequisitionStockDto>().FindUsingSP("ConsumptionItemStockInOut @FromDate, @ToDate, @StockType",
                new SqlParameter("@FromDate", fromdate), new SqlParameter("@ToDate", todate), new SqlParameter("@StockType", "OUT"));
        }

        public List<ConsumptionRequisitionStockDto> getConsumptionItemStockin(DateTime fromdate, DateTime todate)
        {
            return new NonProductionGenericRepository<ConsumptionRequisitionStockDto>().FindUsingSP("ConsumptionItemStockInOut @FromDate, @ToDate, @StockType",
      new SqlParameter("@FromDate", fromdate), new SqlParameter("@ToDate", todate), new SqlParameter("@StockType", "IN"));
        }

        public List<EmployeeConsumptionRequisitionItemsNPDto> getEmployeeRequisitionItemsNP(string EmployeeID)
        {
            return new NonProductionGenericRepository<EmployeeConsumptionRequisitionItemsNPDto>().FindUsingSP("getEmployeeConsumptionRequisitionItemsNP @EmployeeID",
                new SqlParameter("@EmployeeID", EmployeeID));
        }

        public List<EmployeeInventoryItemsDto> getEmployeeInventoryItems(string EmployeeID, string SearchText1, string SearchText2)
        {
            return new NonProductionGenericRepository<EmployeeInventoryItemsDto>().FindUsingSP("getEmployeeInventoryItems @EmployeeID, @SearchText1, @SearchText2",
                new SqlParameter("@EmployeeID", EmployeeID), new SqlParameter("@SearchText1", SearchText1), new SqlParameter("@SearchText2", SearchText2));
        }
    }
}