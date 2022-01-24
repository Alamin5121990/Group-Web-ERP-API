using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebERPAPI.BusinessLogic.Inventory.SCM;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory;

namespace WebERPAPI.BusinessLogic.Test
{
    [TestClass()]
    public class QuotationLocalTest
    {
        private QuotationLocal QL = new QuotationLocal();

        [TestMethod()]
        public void saveQuotationReceive()
        {
            QuotationReceiveData newQ = new QuotationReceiveData();

            newQ.QuotationInvitationID = 4221;
            newQ.EmployeeID = "LPL02693";
            newQ.QuotationReceivedOn = DateTime.Now.ToString("yyyy-MM-dd");
            newQ.Data = "W3siUmVxdWlzaXRpb25Db2RlIjoiUFItMDMyMTIiLCJNYXRlcmlhbENvZGUiOiJQUy1JUy0wMTMiLCJTdXBwbGllckNvZGUiOiJTLTAyNTAiLCJSZWNlaXZlZFF0eSI6NjAwMDAsIlJlY2VpdmVkUHJpY2UiOjIuNX0seyJSZXF1aXNpdGlvbkNvZGUiOiJQUi0wMzIxMiIsIk1hdGVyaWFsQ29kZSI6IlBTLUlTLTAxMyIsIlN1cHBsaWVyQ29kZSI6IlMtMDgyMSIsIlJlY2VpdmVkUXR5Ijo2MDAwMCwiUmVjZWl2ZWRQcmljZSI6Mi42fSx7IlJlcXVpc2l0aW9uQ29kZSI6IlBSLTAzMjEyIiwiTWF0ZXJpYWxDb2RlIjoiUFMtSVMtMDEzIiwiU3VwcGxpZXJDb2RlIjoiUy0xMDMwIiwiUmVjZWl2ZWRRdHkiOjYwMDAwLCJSZWNlaXZlZFByaWNlIjoyLjh9LHsiUmVxdWlzaXRpb25Db2RlIjoiUFItMDMyMTIiLCJNYXRlcmlhbENvZGUiOiJQUy1JUy0wMTMiLCJTdXBwbGllckNvZGUiOiJTLTA2MzEiLCJSZWNlaXZlZFF0eSI6NjAwMDAsIlJlY2VpdmVkUHJpY2UiOjIuNH0seyJSZXF1aXNpdGlvbkNvZGUiOiJQUi0wMzIxMiIsIk1hdGVyaWFsQ29kZSI6IlBTLUlTLTAxMyIsIlN1cHBsaWVyQ29kZSI6IlMtMDc2NSIsIlJlY2VpdmVkUXR5Ijo2MDAwMCwiUmVjZWl2ZWRQcmljZSI6MH0seyJSZXF1aXNpdGlvbkNvZGUiOiJQUi0wMzIxMiIsIk1hdGVyaWFsQ29kZSI6IlBTLUlTLTAxMyIsIlN1cHBsaWVyQ29kZSI6IlMtMDk3MyIsIlJlY2VpdmVkUXR5Ijo2MDAwMCwiUmVjZWl2ZWRQcmljZSI6MH0seyJSZXF1aXNpdGlvbkNvZGUiOiJQUi0wMzIxMiIsIk1hdGVyaWFsQ29kZSI6IlBTLUlTLTAxMyIsIlN1cHBsaWVyQ29kZSI6IlMtMDk2NCIsIlJlY2VpdmVkUXR5Ijo2MDAwMCwiUmVjZWl2ZWRQcmljZSI6MH0seyJSZXF1aXNpdGlvbkNvZGUiOiJQUi0wMzIxMiIsIk1hdGVyaWFsQ29kZSI6IlBTLUlTLTAxMyIsIlN1cHBsaWVyQ29kZSI6IlMtMDcyNCIsIlJlY2VpdmVkUXR5Ijo2MDAwMCwiUmVjZWl2ZWRQcmljZSI6MH0seyJSZXF1aXNpdGlvbkNvZGUiOiJQUi0wMzIxMiIsIk1hdGVyaWFsQ29kZSI6IlBTLUlTLTAxMyIsIlN1cHBsaWVyQ29kZSI6IlMtMTAzMyIsIlJlY2VpdmVkUXR5Ijo2MDAwMCwiUmVjZWl2ZWRQcmljZSI6MH0seyJSZXF1aXNpdGlvbkNvZGUiOiJQUi0wMzIxMiIsIk1hdGVyaWFsQ29kZSI6IlBTLUlTLTAxMyIsIlN1cHBsaWVyQ29kZSI6IlMtMDc5MCIsIlJlY2VpdmVkUXR5Ijo2MDAwMCwiUmVjZWl2ZWRQcmljZSI6MH0seyJSZXF1aXNpdGlvbkNvZGUiOiJQUi0wMzIxMiIsIk1hdGVyaWFsQ29kZSI6IlBTLUlTLTAxMyIsIlN1cHBsaWVyQ29kZSI6IlMtMDg4MiIsIlJlY2VpdmVkUXR5Ijo2MDAwMCwiUmVjZWl2ZWRQcmljZSI6MH0seyJSZXF1aXNpdGlvbkNvZGUiOiJQUi0wMzIxMiIsIk1hdGVyaWFsQ29kZSI6IlBTLUlTLTAxMyIsIlN1cHBsaWVyQ29kZSI6IlMtMDM5NyIsIlJlY2VpdmVkUXR5Ijo2MDAwMCwiUmVjZWl2ZWRQcmljZSI6MH0seyJSZXF1aXNpdGlvbkNvZGUiOiJQUi0wMzIxMiIsIk1hdGVyaWFsQ29kZSI6IlBTLUlTLTAxMyIsIlN1cHBsaWVyQ29kZSI6IlMtMDIxNiIsIlJlY2VpdmVkUXR5Ijo2MDAwMCwiUmVjZWl2ZWRQcmljZSI6MH0seyJSZXF1aXNpdGlvbkNvZGUiOiJQUi0wMzIxMiIsIk1hdGVyaWFsQ29kZSI6IlBTLUlTLTAxMyIsIlN1cHBsaWVyQ29kZSI6IlMtMDc2MSIsIlJlY2VpdmVkUXR5Ijo2MDAwMCwiUmVjZWl2ZWRQcmljZSI6MH1d";
            newQ.Remarks = "CREATED BY UNIT TEST";

            // Clean up
            QL.deleteQuotationReceive(newQ.QuotationInvitationID);

            var Quotation = QL.saveQuotationReceive(newQ);
            Assert.IsNotNull(Quotation);

            Assert.IsTrue(QL.deleteQuotationReceive(newQ.QuotationInvitationID));

            var result = QL.getQuotationReceiveDetails(newQ.QuotationInvitationID);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod()]
        public void cancelQuotation()
        {
            CommonDataEntryClass QData = new CommonDataEntryClass
            {
                EmployeeCode = "LPL02693",
                Code = "LPL-L-201810-010",
                Remarks = "Cancel Test"
            };

            // Quotation Invitation
            Assert.IsTrue(QL.cancelQuotation(QData));
            var quotation = QL.getQuotation(QData.Code);
            Assert.IsNotNull(quotation);
            if (quotation != null) Assert.IsTrue(quotation.IsCanceled.GetValueOrDefault());

            // Quotation Receive
            var quotationReceive = QL.getQuotationReceive(QData.Code);
            Assert.IsNotNull(quotationReceive);
            if (quotationReceive != null) Assert.IsTrue(quotationReceive.IsCanceled.GetValueOrDefault());
        }
    }
}