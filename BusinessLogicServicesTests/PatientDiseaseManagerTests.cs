using System;
using eHealth.Diseases.BusinessLogic.Contracts;
using eHealth.Diseases.BusinessLogic.Managers.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicServicesTests
{
    /// <summary>
    /// Tests for PatientDiseaseManager class
    /// </summary>
    [TestClass]
    public class PatientDiseaseManagerTests
    {
        /// <summary>
        /// Test for method Add
        /// Correct input - correct patient disease
        /// Returned id of added entity
        /// </summary>
        [TestMethod]
        public void Add_CorrectPatientDisease_ReturnedIdOfAddedEntity()
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

        /// <summary>
        /// Test for method Add
        /// IncCorrect input - Disease Id in patientDisease doesn`t exist
        /// Expected ArgumentException
        /// </summary>
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

        /// <summary>
        /// Test for method Add
        /// Incorrect input - Patient Id in patientDisease doesn`t exist
        /// Expected ArgumentException
        /// </summary>
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

        /// <summary>
        /// Test for method Add
        /// Incorrect input - StartDate is later than Now
        /// Expected ArgumentException
        /// </summary>
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

        /// <summary>
        /// Test for method Add
        /// Incorrect input - EndDate is earlier than StartDate
        /// Expected ArgumentException
        /// </summary>
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

        /// <summary>
        /// Test for method Delete
        /// Correct input - correct patientdisease id
        /// Returned Deleted PatientDiseaseId
        /// </summary>
        [TestMethod]
        public void Delete_CorrectPatientDiseaseId_ReturnedDeletedPatientDiseaseId()
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

        /// <summary>
        /// Test for method Update
        /// Correct input
        /// Returned updated PatientDiseaseId
        /// </summary>
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