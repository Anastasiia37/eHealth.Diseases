using System;
using System.Collections.Generic;
using System.Linq;
using eHealth.Diseases.BusinessLogic.Contracts;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;
using eHealth.Diseases.BusinessLogic.Managers.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicServicesTests
{
    /// <summary>
    /// Tests for DiseaseManager class
    /// </summary>
    [TestClass]
    public class DiseaseManagerTests
    {
        /// <summary>
        /// Tests method Add
        /// Correct Disease entity for input
        /// Return Id Of Added Disease
        /// </summary>
        [TestMethod]
        public void Add_CorrectInputDisease_ReturnIdOfAddedDisease()
        {
            // Arrange
            TestData testData = new TestData();
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.GetDiseaseCategories()).Returns(testData.Categories);
            mockDataProvider.Setup(mock => mock.GetDiseasesInCategory(It.IsAny<int>())).Returns(testData.Diseases);
            mockDataProvider.Setup(mock => mock.AddDisease(testData.disease)).Returns(testData.disease.DiseaseId);
            var service = new DiseaseManager(mockDataProvider.Object);

            // Act
            int addedDiseaseId = service.Add(testData.disease);

            // Assert
            Assert.AreEqual(testData.disease.DiseaseId, addedDiseaseId);
        }

        /// <summary>
        /// Tests method Add
        /// InCorrect input: disease name already exists
        /// Expected ArgumentException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_InorrectInputDiseaseName_ExceptionExpected()
        {
            // Arrange
            TestData testData = new TestData();
            testData.disease.Name = testData.Diseases[0].Name;
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.GetDiseaseCategories()).Returns(testData.Categories);
            mockDataProvider.Setup(mock => mock.GetDiseasesInCategory(It.IsAny<int>())).Returns(testData.Diseases);
            mockDataProvider.Setup(mock => mock.AddDisease(testData.disease)).Returns(testData.disease.DiseaseId);
            var service = new DiseaseManager(mockDataProvider.Object);

            // Act
            int addedDiseaseId = service.Add(testData.disease);
        }

        /// <summary>
        /// Tests method Delete
        /// Correct Disease id for input
        /// Return Id Of Deleted Disease
        /// </summary>
        [TestMethod]
        public void Delete_CorrectInputDiseaseId_ReturnIdOfDeletedDisease()
        {
            // Arrange
            TestData testData = new TestData();
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.GetDisease(It.IsAny<int>())).Returns(testData.disease);
            mockDataProvider.Setup(mock => mock.DeleteDisease(testData.disease.DiseaseId)).
                Returns(testData.disease.DiseaseId);
            var service = new DiseaseManager(mockDataProvider.Object);

            // Act
            int deletedDiseaseId = service.Delete(testData.disease.DiseaseId);

            // Assert
            Assert.AreEqual(testData.disease.DiseaseId, deletedDiseaseId);
        }

        /// <summary>
        /// Tests method Delete
        /// InCorrect input: Disease id doesn`t exist
        /// Exception ArgumentException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Delete_InCorrectInputDiseaseId_ExceptionExpected()
        {
            // Arrange
            TestData testData = new TestData();
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.DeleteDisease(testData.disease.DiseaseId)).
               Returns(testData.disease.DiseaseId);
            var service = new DiseaseManager(mockDataProvider.Object);

            // Act
            int deletedDiseaseId = service.Delete(testData.disease.DiseaseId);

            // Assert
            Assert.AreEqual(testData.disease.DiseaseId, deletedDiseaseId);
        }

        /// <summary>
        /// Tests method Get
        /// Correct Disease id for input
        /// Return Disease with specified Id
        /// </summary>
        [TestMethod]
        public void Get_CorrectInputDiseaseId_ReturnDisease()
        {
            // Arrange
            TestData testData = new TestData();
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.GetDisease(testData.disease.DiseaseId)).Returns(testData.disease);
            var service = new DiseaseManager(mockDataProvider.Object);

            // Act
            Disease disease = service.Get(testData.disease.DiseaseId);

            // Assert
            Assert.AreEqual(testData.disease, disease);
        }

        /// <summary>
        /// Tests method Get
        /// InCorrect input: Disease id doesn`t exist
        /// Return Null
        /// </summary>
        [TestMethod]
        public void Get_InCorrectInputDiseaseId_ReturnNull()
        {
            // Arrange
            TestData testData = new TestData();
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.GetDisease(testData.disease.DiseaseId)).Returns(testData.disease);
            var service = new DiseaseManager(mockDataProvider.Object);

            // Act
            Disease disease = service.Get(testData.disease.DiseaseId + 1);

            // Assert
            Assert.IsNull(disease);
        }

        /// <summary>
        /// Tests method GetDiseases
        /// Correct input
        /// Return list of all diseases
        /// </summary>
        [TestMethod]
        public void GetAll_CorrectInput_ReturnAllTestDiseases()
        {
            // Arrange
            TestData testData = new TestData();
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.GetDiseases()).Returns(testData.Diseases);
            var service = new DiseaseManager(mockDataProvider.Object);

            // Act
            List<Disease> diseases = service.GetAll().ToList();

            // Assert
            CollectionAssert.AreEqual(testData.Diseases, diseases);
        }

        /// <summary>
        /// Tests method GetDiseasesInCategory
        /// Correct input - correct category id
        /// Return list of all diseases with specified category
        /// </summary>
        [TestMethod]
        public void GetDiseasesInCategory_CorrectInputCategotyId_ListOfDiseases()
        {
            // Arrange
            TestData testData = new TestData();
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.GetDiseaseCategories()).Returns(testData.Categories);
            mockDataProvider.Setup(mock => mock.GetDiseasesInCategory(testData.disease.CategoryId)).
                Returns(testData.Diseases);
            var service = new DiseaseManager(mockDataProvider.Object);

            // Act
            List<Disease> diseases = service.GetDiseasesInCategory(testData.disease.CategoryId).ToList();

            // Assert
            CollectionAssert.AreEqual(testData.Diseases, diseases);
        }

        /// <summary>
        /// Tests method GetDiseasesInCategory
        /// Incorrect input - doesn`t have specified category id
        /// Expected ArgumentException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetDiseasesInCategory_InCorrectInputCategotyId_ExpectedException()
        {
            // Arrange
            TestData testData = new TestData();
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.GetDiseasesInCategory(testData.disease.CategoryId)).
                Returns(testData.Diseases);
            var service = new DiseaseManager(mockDataProvider.Object);

            // Act
            List<Disease> diseases = service.GetDiseasesInCategory(testData.disease.CategoryId).ToList();
        }

        /// <summary>
        /// Tests method Update
        /// Correct input
        /// Return id of updated disease
        /// </summary>
        [TestMethod]
        public void Update_CorrectInput_ReturnIdOfUpdatedDisease()
        {
            // Arrange
            TestData testData = new TestData();
            int expectedUpdatedDiseaseId = testData.disease.DiseaseId;
            var mockDataProvider = new Mock<IDataAccessManager>();
            mockDataProvider.Setup(mock => mock.GetDisease(testData.disease.DiseaseId)).Returns(testData.disease);
            mockDataProvider.Setup(mock => mock.GetDiseaseCategories()).Returns(testData.Categories);
            mockDataProvider.Setup(mock => mock.GetDiseasesInCategory(It.IsAny<int>())).Returns(testData.Diseases);
            mockDataProvider.Setup(mock => mock.UpdateDisease(expectedUpdatedDiseaseId, testData.disease)).
                Returns(expectedUpdatedDiseaseId);
            var service = new DiseaseManager(mockDataProvider.Object);

            // Act
            int actualUpdatedDiseaseId = service.Update(expectedUpdatedDiseaseId, testData.disease);

            // Assert
            Assert.AreEqual(expectedUpdatedDiseaseId, actualUpdatedDiseaseId);
        }

        /// <summary>
        /// Tests method Update
        /// InCorrect input - disease with such id doesn`t exists
        /// Expected ArgumentException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Update_InCorrectInputDiseaseId_ExpectedException()
        {
            // Arrange
            TestData testData = new TestData();
            int expectedUpdatedDiseaseId = testData.disease.DiseaseId;
            var mockDataProvider = new Mock<IDataAccessManager>();
            Disease nullDisease = null;
            mockDataProvider.Setup(mock => mock.GetDisease(testData.disease.DiseaseId)).Returns(nullDisease);
            mockDataProvider.Setup(mock => mock.GetDiseaseCategories()).Returns(testData.Categories);
            mockDataProvider.Setup(mock => mock.GetDiseasesInCategory(It.IsAny<int>())).Returns(testData.Diseases);
            mockDataProvider.Setup(mock => mock.UpdateDisease(expectedUpdatedDiseaseId, testData.disease)).
                Returns(expectedUpdatedDiseaseId);
            var service = new DiseaseManager(mockDataProvider.Object);

            // Act
            int actualUpdatedDiseaseId = service.Update(expectedUpdatedDiseaseId, testData.disease);

            // Assert
            Assert.AreEqual(expectedUpdatedDiseaseId, actualUpdatedDiseaseId);
        }

        /// <summary>
        /// Tests method Update
        /// InCorrect input - category id doesn`t exists
        /// Expected ArgumentException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Update_InCorrectInputCategoryId_ExpectedException()
        {
            // Arrange
            TestData testData = new TestData();
            int expectedUpdatedDiseaseId = testData.disease.DiseaseId;
            var mockDataProvider = new Mock<IDataAccessManager>();
            testData.disease.CategoryId = 5;
            mockDataProvider.Setup(mock => mock.GetDisease(testData.disease.DiseaseId)).Returns(testData.disease);
            mockDataProvider.Setup(mock => mock.GetDiseaseCategories()).Returns(testData.Categories);
            mockDataProvider.Setup(mock => mock.GetDiseasesInCategory(It.IsAny<int>())).Returns(testData.Diseases);
            mockDataProvider.Setup(mock => mock.UpdateDisease(expectedUpdatedDiseaseId, testData.disease)).
                Returns(expectedUpdatedDiseaseId);
            var service = new DiseaseManager(mockDataProvider.Object);

            // Act
            int actualUpdatedDiseaseId = service.Update(expectedUpdatedDiseaseId, testData.disease);

            // Assert
            Assert.AreEqual(expectedUpdatedDiseaseId, actualUpdatedDiseaseId);
        }

        /// <summary>
        /// Tests method Update
        /// InCorrect input - Disease name already exists
        /// Expected ArgumentException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Update_InCorrectInputDiseaseNameAlreadyExists_ExpectedException()
        {
            // Arrange
            TestData testData = new TestData();
            int expectedUpdatedDiseaseId = testData.disease.DiseaseId;
            var mockDataProvider = new Mock<IDataAccessManager>();
            testData.disease.Name = testData.Diseases[0].Name;
            mockDataProvider.Setup(mock => mock.GetDisease(testData.disease.DiseaseId)).Returns(testData.disease);
            mockDataProvider.Setup(mock => mock.GetDiseaseCategories()).Returns(testData.Categories);
            mockDataProvider.Setup(mock => mock.GetDiseasesInCategory(It.IsAny<int>())).Returns(testData.Diseases);
            mockDataProvider.Setup(mock => mock.UpdateDisease(expectedUpdatedDiseaseId, testData.disease)).
                Returns(expectedUpdatedDiseaseId);
            var service = new DiseaseManager(mockDataProvider.Object);

            // Act
            int actualUpdatedDiseaseId = service.Update(expectedUpdatedDiseaseId, testData.disease);

            // Assert
            Assert.AreEqual(expectedUpdatedDiseaseId, actualUpdatedDiseaseId);
        }
    }
}