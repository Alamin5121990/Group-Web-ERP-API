using System;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.Data.Repository.Inventory
{
    public interface IRequisitionRepositories
    {
        bool deletePPICRequisition(string RequisitionID, string EmployeeID);

        POReqDetail getMaterialRequisitionDetails(string RequisitionCode, string MaterialCode);

        string saveNewRequisition(string EmployeeCode, string MaterialTypeCode, string Remarks);

        int saveRequisitionDetails(string RequisitionID, int SerialNo, string MaterialCode, decimal Quantity, string Version, DateTime DeliveryDate, string MaterialGrade, string ModeOfShipment);
    }
}