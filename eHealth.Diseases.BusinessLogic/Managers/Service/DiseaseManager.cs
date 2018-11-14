using System;
using System.Collections.Generic;
using System.Linq;
using eHealth.Diseases.BusinessLogic.Contracts;
using eHealth.Diseases.BusinessLogic.Contracts.Service;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;

namespace eHealth.Diseases.BusinessLogic.Managers.Service
{
    /// <summary>
    /// Service for wirking with diseases
    /// </summary>
    /// <seealso cref="eHealth.Diseases.BusinessLogic.Contracts.Service.IDiseaseManager" />
    public class DiseaseManager : IDiseaseManager
    {
        /// <summary>
        /// The data access manager
        /// </summary>
        private IDataAccessManager dataAccessManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiseaseManager"/> class
        /// </summary>
        /// <param name="dataAccessManager">The data access manager</param>
        public DiseaseManager(IDataAccessManager dataAccessManager)
        {
            this.dataAccessManager = dataAccessManager;
        }

        /// <summary>
        /// Adds the specified disease
        /// </summary>
        /// <param name="disease">The disease</param>
        /// <returns>
        /// Id of added disease
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Not valid category id!
        /// or
        /// Disease name already exists!
        /// </exception>
        public int Add(Disease disease)
        {
            if (!this.dataAccessManager.GetDiseaseCategories().Any(category => category.CategoryId == disease.CategoryId))
            {
                throw new ArgumentException("Not valid category id!");
            }

            if (this.dataAccessManager.GetDiseasesInCategory(disease.CategoryId).Any(d => d.Name == disease.Name))
            {
                throw new ArgumentException("Disease name already exists!");
            }

            return this.dataAccessManager.AddDisease(disease);
        }

        /// <summary>
        /// Deletes the specified disease identifier
        /// </summary>
        /// <param name="diseaseId">The disease identifier</param>
        /// <returns>
        /// Id of deleted disease
        /// </returns>
        /// <exception cref="ArgumentException">Not valid disease id!</exception>
        public int Delete(int diseaseId)
        {
            if (this.dataAccessManager.GetDisease(diseaseId) == null)
            {
                throw new ArgumentException("Not valid disease id!");
            }

            return this.dataAccessManager.DeleteDisease(diseaseId);
        }

        /// <summary>
        /// Gets the specified disease identifier
        /// </summary>
        /// <param name="diseaseId">The disease identifier</param>
        /// <returns>
        /// Disease
        /// </returns>
        public Disease Get(int diseaseId)
        {
            return this.dataAccessManager.GetDisease(diseaseId);
        }

        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns>
        /// The list of all entities
        /// </returns>
        public IEnumerable<Disease> GetAll()
        {
            return dataAccessManager.GetDiseases();
        }

        /// <summary>
        /// Gets the diseases of specified category
        /// </summary>
        /// <param name="categoryId">The category identifier</param>
        /// <returns>
        /// The list of diseases
        /// </returns>
        /// <exception cref="ArgumentException">Not valid category id!</exception>
        public IEnumerable<Disease> GetDiseasesInCategory(int categoryId)
        {
            if (this.dataAccessManager.GetDiseaseCategories().Any(category => category.CategoryId == categoryId))
            {
                return this.dataAccessManager.GetDiseasesInCategory(categoryId);
            }

            throw new ArgumentException("Not valid category id!");
        }

        /// <summary>
        /// Updates the disease with specified  identifier
        /// </summary>
        /// <param name="diseaseId">The disease identifier</param>
        /// <param name="disease">The disease</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// Not valid disease id!
        /// or
        /// Not valid category id!
        /// or
        /// Disease name already exists!
        /// </exception>
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
        }
    }
}