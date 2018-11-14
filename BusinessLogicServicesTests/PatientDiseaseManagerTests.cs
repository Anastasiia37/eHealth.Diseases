using System;
using eHealth.Diseases.BusinessLogic.Contracts;
using eHealth.Diseases.BusinessLogic.Managers.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicServicesTests
{
    [TestClass]
    public class PatientDiseaseManagerTests
    {
        [TestMethod]
        public void Add_CorrectPatientDisease()
        {
            // Arrange
            TestData testData = new TestData();
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.GetDisease(It.IsAny<int>())).Returns(testData.disease);
            mockDataProvider.Setup(mock => mock.isValidPatientId(It.IsAny<int>())).Returns(true);
            mockDataProvider.Setup(mock => mock.AddDiseaseToPatient(testData.patientDisease)).
                Returns(testData.patientDisease.PatientDiseaseId);
            var service = new PatientDiseaseManager(mockDataProvider.Object);

            // Act
            int addedPatientDiseaseId = service.Add(testData.patientDisease);

            // Assert
            Assert.AreEqual(testData.patientDisease.PatientDiseaseId, addedPatientDiseaseId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_InCorrectDiseaseId_ExpectedException()
        {
            // Arrange
            TestData testData = new TestData();
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.isValidPatientId(It.IsAny<int>())).Returns(true);
            mockDataProvider.Setup(mock => mock.AddDiseaseToPatient(testData.patientDisease)).
                Returns(testData.patientDisease.PatientDiseaseId);
            var service = new PatientDiseaseManager(mockDataProvider.Object);

            // Act
            int addedPatientDiseaseId = service.Add(testData.patientDisease);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_InCorrectPatientId_ExpectedException()
        {
            // Arrange
            TestData testData = new TestData();
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.GetDisease(It.IsAny<int>())).Returns(testData.disease);
            mockDataProvider.Setup(mock => mock.isValidPatientId(It.IsAny<int>())).Returns(false);
            mockDataProvider.Setup(mock => mock.AddDiseaseToPatient(testData.patientDisease)).
                Returns(testData.patientDisease.PatientDiseaseId);
            var service = new PatientDiseaseManager(mockDataProvider.Object);

            // Act
            int addedPatientDiseaseId = service.Add(testData.patientDisease);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_InCorrectStartDate_ExpectedException()
        {
            // Arrange
            TestData testData = new TestData();
            testData.patientDisease.StartDate = DateTime.Now.AddDays(1);
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.GetDisease(It.IsAny<int>())).Returns(testData.disease);
            mockDataProvider.Setup(mock => mock.isValidPatientId(It.IsAny<int>())).Returns(true);
            mockDataProvider.Setup(mock => mock.AddDiseaseToPatient(testData.patientDisease)).
                Returns(testData.patientDisease.PatientDiseaseId);
            var service = new PatientDiseaseManager(mockDataProvider.Object);

            // Act
            int addedPatientDiseaseId = service.Add(testData.patientDisease);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_InCorrectEndDate_ExpectedException()
        {
            // Arrange
            TestData testData = new TestData();
            testData.patientDisease.EndDate = testData.patientDisease.StartDate.AddDays(-1);
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.GetDisease(It.IsAny<int>())).Returns(testData.disease);
            mockDataProvider.Setup(mock => mock.isValidPatientId(It.IsAny<int>())).Returns(true);
            mockDataProvider.Setup(mock => mock.AddDiseaseToPatient(testData.patientDisease)).
                Returns(testData.patientDisease.PatientDiseaseId);
            var service = new PatientDiseaseManager(mockDataProvider.Object);

            // Act
            int addedPatientDiseaseId = service.Add(testData.patientDisease);
        }

        [TestMethod]
        public void Delete_CorrectPatientDiseaseId_ReturnedDeletedPatientId()
        {
            // Arrange
            TestData testData = new TestData();
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.GetPatientDisease(It.IsAny<int>())).Returns(testData.patientDisease);
            mockDataProvider.Setup(mock => mock.DeleteDiseaseFromPatient(testData.patientDisease.PatientDiseaseId)).
                Returns(testData.patientDisease.PatientDiseaseId);
            var service = new PatientDiseaseManager(mockDataProvider.Object);

            // Act
            int deletedPatientDiseaseId = service.Delete(testData.patientDisease.PatientDiseaseId);

            // Assert
            Assert.AreEqual(testData.patientDisease.PatientDiseaseId, deletedPatientDiseaseId);
        }

        [TestMethod]
        public void Update_CorrectInput_ReturnedUpdatedPatientDiseaseId()
        {
            // Arrange
            TestData testData = new TestData();
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.GetPatientDisease(It.IsAny<int>())).Returns(testData.patientDisease);
            mockDataProvider.Setup(mock => mock.UpdatePatientDisease(
                testData.patientDisease.PatientDiseaseId, testData.patientDisease)).
                Returns(testData.patientDisease.PatientDiseaseId);
            var service = new PatientDiseaseManager(mockDataProvider.Object);

            // Act
            int updatedPatientDiseaseId = service.Update(testData.patientDisease.PatientDiseaseId, testData.patientDisease);

            // Assert
            Assert.AreEqual(testData.patientDisease.PatientDiseaseId, updatedPatientDiseaseId);
        }
    }
}