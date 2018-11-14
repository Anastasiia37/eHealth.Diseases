using System;
using System.Collections.Generic;
using System.Text;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;

namespace BusinessLogicServicesTests
{
    public class TestData
    {
        public List<DiseaseCategory> Categories = new List<DiseaseCategory>
        {
            new DiseaseCategory
            {
                CategoryId = 1,
                Name = "Category1",
                IsDeleted = false
            },
            new DiseaseCategory
            {
                CategoryId = 2,
                Name = "Category2",
                IsDeleted = true
            },
            new DiseaseCategory
            {
                CategoryId = 3,
                Name = "Category3",
                IsDeleted = false
            }
        };

        public List<Disease> Diseases = new List<Disease>
        {
            new Disease
                {
                    DiseaseId = 1,
                    Name = "Test disease name 1",
                    CategoryId = 1,
                    Description = "Description 1",
                    IsDeleted = false
                }
        };

        public Disease disease = new Disease
        {
            DiseaseId = 1,
            Name = "Test disease name",
            CategoryId = 2,
            Description = "Description",
            IsDeleted = false
        };

        public PatientDisease patientDisease = new PatientDisease
        {
            PatientDiseaseId = 1,
            PatientId = 1,
            DiseaseId = 1,
            UserId = 1,
            StartDate = new DateTime(2015, 7, 20),
            EndDate = null,
            Note = "Test",
            IsDeleted = false
        };

        public List<PatientDisease> patientDiseases = new List<PatientDisease>
        {
            new PatientDisease
            {
                PatientDiseaseId = 2,
                PatientId = 1,
                DiseaseId = 1,
                UserId = 1,
                StartDate = new DateTime(2015, 7, 20),
                EndDate = null,
                Note = "Test",
                IsDeleted = false
            }
        };
    }
}
