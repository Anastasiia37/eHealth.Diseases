using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eHealth.Diseases.BusinessLogic.Contracts.Service;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;
using eHealth.Diseases.BusinessLogic.DbContext;
using eHealth.Diseases.BusinessLogic.Contracts;

namespace eHealth.Diseases.BusinessLogic.Managers.Service
{
    public class DiseaseManager : IDiseaseManager
    {
        private IDataAccessManager dataAccessManager;

        public DiseaseManager(IDataAccessManager dataAccessManager)
        {
            this.dataAccessManager = dataAccessManager;
        }

        public int AddDisease(Disease disease)
        {
            if (!this.GetDiseaseCategories().Any(category => category.CategoryId == disease.CategoryId))
            {
                throw new ArgumentException("Not valid category id!");
            }

            if (this.dataAccessManager.GetDiseasesInCategory(disease.CategoryId).Any(d => d.Name == disease.Name))
            {
                throw new ArgumentException("Disease name already exists!");
            }

            return this.dataAccessManager.AddDisease(disease);
        }

        public int DeleteDisease(int diseaseId)
        {
            if (this.dataAccessManager.GetDisease(diseaseId) == null)
            {
                throw new ArgumentException("Not valid disease id!");
            }

            return this.dataAccessManager.DeleteDisease(diseaseId);
        }

        public IEnumerable<Disease> Get()
        {
            return dataAccessManager.GetDeseases();
        }

        public Disease GetDisease(int diseaseId)
        {
            return this.dataAccessManager.GetDisease(diseaseId);
        }

        public IEnumerable<DiseaseCategory> GetDiseaseCategories()
        {
            return this.dataAccessManager.GetDiseaseCategories();
        }

        public IEnumerable<Disease> GetDiseasesInCategory(int categoryId)
        {
            if (this.GetDiseaseCategories().Any(category => category.CategoryId == categoryId))
            {
                var a = this.dataAccessManager.GetDiseasesInCategory(categoryId); ;
                return a;
                //return this.dataAccessManager.GetDiseasesInCategory(categoryId);
            }

            throw new ArgumentException("Not valid category id!");
        }

        public int UpdateDisease(int diseaseId, Disease disease)
        {
            if (this.dataAccessManager.GetDisease(diseaseId) == null)
            {
                throw new ArgumentException("Not valid disease id!");
            }

            if (!this.GetDiseaseCategories().Any(category => category.CategoryId == disease.CategoryId))
            {
                throw new ArgumentException("Not valid category id!");
            }

            if (this.dataAccessManager.GetDiseasesInCategory(disease.CategoryId).Any(d => d.Name == disease.Name))
            {
                throw new ArgumentException("Disease name already exists!");
            }

            return this.dataAccessManager.UpdateDisease(diseaseId, disease);
        }
    }
}