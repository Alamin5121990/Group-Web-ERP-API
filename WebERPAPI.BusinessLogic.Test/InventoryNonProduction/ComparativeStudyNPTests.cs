using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using WebERPAPI.BusinessLogic.InventoryNonProduction;

namespace WebERPAPI.BusinessLogic.Test.InventoryNonProduction
{
    [TestClass]
    public class ComparativeStudyNPTests
    {
        [TestMethod]
        public void saveComparativeStudy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mocker = new AutoMoqer();
            var comparativeStudyNP = mocker.Create<ComparativeStudyNP>();
            CommonDataEntryClass CS = null;

            // Act
            var result = comparativeStudyNP.saveComparativeStudy(
                CS);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void getComparativeStudy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mocker = new AutoMoqer();
            var comparativeStudyNP = mocker.Create<ComparativeStudyNP>();
            string CSCode = null;
            int ActionGroupID = 0;

            // Act
            var result = comparativeStudyNP.getComparativeStudy(
                CSCode,
                ActionGroupID);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void getComparativeStudyReport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mocker = new AutoMoqer();
            var comparativeStudyNP = mocker.Create<ComparativeStudyNP>();
            string CSCode = null;
            int CSID = 0;

            // Act
            var result = comparativeStudyNP.getComparativeStudyReport(
                CSCode,
                CSID);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void cancelComparativeStudy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mocker = new AutoMoqer();
            var comparativeStudyNP = mocker.Create<ComparativeStudyNP>();
            CommonDataEntryClass Data = null;

            // Act
            var result = comparativeStudyNP.cancelComparativeStudy(
                Data);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void updateComparativeStudy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mocker = new AutoMoqer();
            var comparativeStudyNP = mocker.Create<ComparativeStudyNP>();
            CommonDataEntryClass CSData = null;

            // Act
            var result = comparativeStudyNP.updateComparativeStudy(
                CSData);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void getComparativeStudyStatusReport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mocker = new AutoMoqer();
            var comparativeStudyNP = mocker.Create<ComparativeStudyNP>();
            int MainGroupID = 0;

            // Act
            var result = comparativeStudyNP.getComparativeStudyStatusReport(
                MainGroupID);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void getComparativeStudy_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var mocker = new AutoMoqer();
            var comparativeStudyNP = mocker.Create<ComparativeStudyNP>();
            int RequisitionID = 0;
            int ItemID = 0;

            // Act
            var result = comparativeStudyNP.getComparativeStudy(
                RequisitionID,
                ItemID);

            // Assert
            Assert.Fail();
        }
    }
}
