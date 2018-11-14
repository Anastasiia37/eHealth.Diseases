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
    [TestClass]
    public class DiseaseManagerTests
    {
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Update_InCorrectInputDiseaseId_ReturnIdOfUpdatedDisease()
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Update_InCorrectInputCategoryId_ReturnIdOfUpdatedDisease()
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Update_InCorrectInputDiseaseNameAlreadyExists_ReturnIdOfUpdatedDisease()
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

        /*

         public int Update(int diseaseId, Disease disease)
         {
             if (this.dataAccessManager.GetDisease(diseaseId) == null)
             {
                 throw new ArgumentException("Not valid disease id!");
             }

             if (!this.dataAccessManager.GetDiseaseCategories().Any(category => category.CategoryId == disease.CategoryId))
             {
                 throw new ArgumentException("Not valid category id!");
             }

             if (this.dataAccessManager.GetDiseasesInCategory(disease.CategoryId).Any(d => d.Name == disease.Name))
             {
                 throw new ArgumentException("Disease name already exists!");
             }

             return this.dataAccessManager.UpdateDisease(diseaseId, disease);
         }*/
    }
}