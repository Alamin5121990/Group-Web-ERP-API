using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebERPAPI.BusinessLogic.Inventory.SCM;
using WebERPAPI.DTO.Inventory;
using WebERPAPI.DTO.Inventory.Quotation;

namespace WebERPAPI.BusinessLogic.Test
{
    [TestClass()]
    public class ComparativeStudyImportTest
    {
        private ComparativeStudyImportService CSI = new ComparativeStudyImportService();

        [TestMethod()]
        public void saveComparativeStudy()
        {
            ComparativeStudyImportData newCS = new ComparativeStudyImportData();

            newCS.CSID = 0;
            newCS.EmployeeID = "LPL02693";
            newCS.Data = "W3siTWF0ZXJpYWxDb2RlIjoiUFAtUEQtMDEyIiwiSW5kZW50b3JDb2RlIjoiUy0wODI2IiwiU3VwcGxpZXJDb2RlIjoiUy0wNDI0IiwiTWFudWZhY3R1cmVyQ29kZSI6IlMtMDQyNCIsIlF1YW50aXR5Ijo1LCJSYXRlIjoxLjIsIk1vZGVPZlNoaXBtZW50IjoiUm9hZCIsIkRlbGl2ZXJ5TW9kZSI6IkNQVCIsIkN1cnJlbmN5SUQiOjIsIkN1cnJlbmN5Q29udmVyc2lvblJhdGUiOjgzLjgsIlJlcXVpc2l0aW9uQ29kZSI6IlBSLTAzMDI1IiwiUmVtYXJrcyI6IiJ9XQ==";
            newCS.Remarks = "CREATED BY UNIT TEST";

            var CS = CSI.saveComparativeStudy(newCS);
            Assert.IsNotNull(CS);

            //Checking Delete Success Full
            Assert.IsTrue(CSI.deleteComparativeStudy(CS.ID));

            // Checking CS details is exists or not

            var CSDetails = CSI.getComparativeStudyByCSID(CS.ID);
            Assert.IsTrue(CSDetails.Count == 0);
        }

        [TestMethod()]
        public void getComparativeStudyReport()
        {
            object Report = CSI.getComparativeStudyReport("CS-I-1907027");

            object CS = Library.SystemCore.extractObject<ComparativeStudyImportSummary>(Report, "CS");
            Assert.IsNotNull(CS);
            //Assert.IsTrue(CS. > 0);
        }

        [TestMethod()]
        public void getComparativeStudyImport()
        {
            List<ComparativeStudyImportDTO> Report = CSI.getComparativeStudyImport("0", "0");
            Assert.IsNotNull(Report);
            Assert.IsTrue(Report.Count > 0);
        }

        // ACCOUNTS APPROVE
        [TestMethod()]
        public void comparativeStudyImportAccountsApprove()
        {
            ComparativeStudyImportApprovalData CSDetails = new ComparativeStudyImportApprovalData();

            CSDetails.EmployeeID = "LPL02693";
            CSDetails.Data = "W3siQ1NJRCI6Mjc0NCwiTWF0ZXJpYWxDb2RlIjoiUk1FMDAwOCIsIlJlcXVpc2l0aW9uQ29kZSI6IlBSLTAyNTU4IiwiUmVtYXJrcyI6IiJ9XQ==";

            Assert.IsTrue(CSI.comparativeStudyImportAccountsApprove(CSDetails));
        }

        // MANAGEMENT APPROVE
        [TestMethod()]
        public void comparativeStudyImportManagementApprove()
        {
            ComparativeStudyImportApprovalData CSDetails = new ComparativeStudyImportApprovalData();

            CSDetails.EmployeeID = "LPL02693";
            CSDetails.Data = "W3siQ1NJRCI6Mjc0MSwiTWF0ZXJpYWxDb2RlIjoiUk1BMDA1NSIsIlJlcXVpc2l0aW9uQ29kZSI6IlBSLTAzMjAyIiwiUmVtYXJrcyI6IiJ9XQ==";

            Assert.IsTrue(CSI.comparativeStudyImportManagementApprove(CSDetails));
        }

        [TestMethod()]
        public void getInternalApprovalIndentor()
        {
            List<InternalApprovalIndentor> Report = CSI.getInternalApprovalIndentor();
            Assert.IsNotNull(Report);
            Assert.IsTrue(Report.Count > 0);
        }
    }
}