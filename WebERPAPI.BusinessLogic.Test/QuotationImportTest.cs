using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebERPAPI.BusinessLogic.Inventory.SCM;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Inventory;

namespace WebERPAPI.BusinessLogic.Test
{
    [TestClass()]
    public class QuotationImportTest
    {
        private QuotationImport QI = new QuotationImport();

        [TestMethod()]
        public void saveQuotationReceive()
        {
            QuotationImportReceiveData newQ = new QuotationImportReceiveData();

            newQ.QuotationInvitationID = 2020;
            newQ.EmployeeID = "LPL02693";
            //newQ.QuotationReceivedOn = DateTime.Now.ToString("yyyy-MM-dd");
            newQ.Data = "W3siUmVxdWlzaXRpb25Db2RlIjoiUFItMDMwMjUiLCJNYXRlcmlhbENvZGUiOiJQUC1QRC0wMTIiLCJJbmRlbnRvckNvZGUiOiJTLTA4MjYiLCJTdXBwbGllckNvZGUiOiJTLTA0MjQiLCJNYW51ZmFjdHVyZXJDb2RlIjoiUy0wNDI0IiwiUXVhbnRpdHkiOjUsIk9mZmVyZWRGT0JSYXRlIjowLCJPZmZlcmVkQ1BUUmF0ZSI6Mi4zLCJDdXJyZW5jeUlEIjoyLCJNb2RlT2ZTaGlwbWVudCI6IlJvYWQiLCJDdXJyZW5jeUNvbnZlcnNpb25SYXRlIjo4My44LCJQYWNrYWdpbmdJbmZvIjpudWxsLCJSZW1hcmtzIjpudWxsfSx7IlJlcXVpc2l0aW9uQ29kZSI6IlBSLTAzMDI1IiwiTWF0ZXJpYWxDb2RlIjoiUFAtUEQtMDEyIiwiSW5kZW50b3JDb2RlIjoiUy0wMDI3IiwiU3VwcGxpZXJDb2RlIjoiUy0wMTQwIiwiTWFudWZhY3R1cmVyQ29kZSI6IlMtMDE0MCIsIlF1YW50aXR5Ijo1LCJPZmZlcmVkRk9CUmF0ZSI6MCwiT2ZmZXJlZENQVFJhdGUiOjIuOCwiQ3VycmVuY3lJRCI6MiwiTW9kZU9mU2hpcG1lbnQiOiJSb2FkIiwiQ3VycmVuY3lDb252ZXJzaW9uUmF0ZSI6ODMuOCwiUGFja2FnaW5nSW5mbyI6bnVsbCwiUmVtYXJrcyI6bnVsbH1d";
            newQ.Remarks = "CREATED BY UNIT TEST";

            // For clean up
            QI.deleteQuotationReceive(newQ.QuotationInvitationID);

            var Quotation = QI.saveQuotationReceive(newQ);
            Assert.IsNotNull(Quotation);

            Assert.IsTrue(QI.deleteQuotationReceive(newQ.QuotationInvitationID));

            var result = QI.getQuotationReceiveDetails(newQ.QuotationInvitationID);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod()]
        public void cancelQuotation()
        {
            CommonDataEntryClass QData = new CommonDataEntryClass
            {
                EmployeeCode = "LPL02693",
                Code = "LPL-I-1905017",
                Remarks = "Cancel Test"
            };

            // Quotation Invitation
            Assert.IsTrue(QI.cancelQuotation(QData));
            var quotation = QI.getQuotation(QData.Code);
            Assert.IsNotNull(quotation);
            if (quotation != null) Assert.IsTrue(quotation.IsCanceled.GetValueOrDefault());

            // Quotation Receive
            var quotationReceive = QI.getQuotationReceive(QData.Code);
            Assert.IsNotNull(quotationReceive);
            if (quotationReceive != null) Assert.IsTrue(quotationReceive.IsCanceled.GetValueOrDefault());
        }
    }
}