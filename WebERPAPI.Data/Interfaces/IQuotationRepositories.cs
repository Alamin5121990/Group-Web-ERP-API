using System.Collections.Generic;
using WebERPAPI.DTO.Inventory;
using WebERPAPI.DTO.Inventory.Requisitions;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.Data.Repository.Inventory
{
    public interface IQuotationRepositories
    {
        bool approveComparativeStudy(ComparativeStudyData csData, int CSID, int ApprovalId = 1);

        bool deleteComparativeStudy(int CSID);

        bool deleteComparativeStudyMaterial(int CSID, string MaterialCode);

        bool deleteComparativeStudyMaterialSupplier(int CSID, string MaterialCode, string SupplierCode);

        bool deleteQuotation(int QuotationID);

        //List<ComparativeStudyDetailsForReview> getComparativeStudyDetailsForReview(string CSCode);
        //List<ComparativeStudyInternalApproval> getComparativeStudyInternalApproval(string DateFrom, string DateTo);
        //List<ComparativeStudyInternalApprovalReport> getComparativeStudyInternalApprovalReport(int InternalApprovalID);
        //List<ComparativeStudyList> getComparativeStudyList(int ReviewedStatus, string CSCode);
        //List<ComparativeStudyMaterialSupplier> getComparativeStudyMaterialSupplier(int CSID, string MaterialCode);
        List<ComparativeStudyReviewedMaterials> getComparativeStudyReviewedMaterials(int AccountsApproveStatus, int MarketingVerificationStatus, int ManagementApproveStatus);

        List<ComparativeStudySupplierPriceList> getComparativeStudySupplierPriceList(string CSCode);

        string getEmailFormat(string EmployeeCode, List<RequisitionAndMaterial> materials, string TemplatePath, string TemplateFilepath, string LastReceiveDate, string QuotationInvitationNumber, string Token);

        string getNewCSCode();

        string getNewInternalApprovalCode();

        string getNextQuotationInvitationNumber(string SourceType);

        List<QuotationDetailsForCS> getQuotationDetailsForCS(string QuotationID);

        string getQuotationEmailFormat(string EmployeeCode, MaterialSupplierDetails supplier, List<RequisitionDetails> materials, string TemplatePath, string TemplateFilepath, string LastReceiveDate, string QuotationInvitationNumber);

        List<QuotationMaterialList> getQuotationMaterialList(int QuotationID);

        List<QuotationMaterialsForCS> getQuotationMaterialsForCS(string QuotationID);

        List<QuotationDetailsForCS> getQuotationMaterialSupplier(string RequisitionCode, string MaterialCode, short ShowPriceOnly);

        List<QuotationPending> getQuotationLocalPending(int ReceiveStatus);

        List<QuotationReceiveDetails> getQuotationReceiveDetails(int QuotationID, string QuotationCode, int ReceiveStatus);

        List<RequisitionItemForCS> getRequisitionItemForCSList();

        List<Quotation_Invitations> getCSQuotations(int CSID);

        int saveComparativeStudy(string EmployeeID, string Remarks);

        bool saveComparativeStudyDetails(int CSID, ComparativeStudyDetails newCSD);

        int saveInternalApproval(string EmployeeID);

        bool saveInternalApprovalDetails(int InternalApprovalID, int CSID, string MaterialCode);

        int saveQuotationInvitation(string SentByID, string QuotationInvitationNumber, string SupplierID);

        bool saveQuotationInvitationDetails(int QuotationInvitationID, string SupplierID, string RequisitionID, string MaterialCode);

        int saveQuotationReceive(int QuotationInvitationID, string QuotationReceivedOn, string ReceivedById, string Remarks);

        bool saveQuotationReceivedDetails(int QuotationInvitationID, string RequisitionCode, QuotationReceivedDetails qrDetails, int QuotationReceiveID, string VendorRemarks);

        bool setQuotationCodeForRequisition(int QuotationInvitationID, string SupplierID, string RequisitionID, string MaterialCode);

        int updateComparativeStudyReview(int CSID, string EmployeeID, string Remarks);

        bool updateEmailSentRequisition();
    }
}