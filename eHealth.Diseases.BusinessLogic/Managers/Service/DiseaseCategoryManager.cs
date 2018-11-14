using System;
using System.Collections.Generic;
using System.Linq;
using eHealth.Diseases.BusinessLogic.Contracts;
using eHealth.Diseases.BusinessLogic.Contracts.Service;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;

namespace eHealth.Diseases.BusinessLogic.Managers.Service
{
    /// <summary>
    /// Service for working with disease categories
    /// </summary>
    /// <seealso cref="eHealth.Diseases.BusinessLogic.Contracts.Service.IDiseaseCategoryManager" />
    public class DiseaseCategoryManager : IDiseaseCategoryManager
    {
        /// <summary>
        /// The data access manager
        /// </summary>
        private IDataAccessManager dataAccessManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiseaseCategoryManager"/> class
        /// </summary>
        /// <param name="dataAccessManager">The data access manager</param>
        public DiseaseCategoryManager(IDataAccessManager dataAccessManager)
        {
            this.dataAccessManager = dataAccessManager;
        }

        /// <summary>
        /// Adds the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <returns>
        /// Id of added category
        /// </returns>
        /// <exception cref="ArgumentException">Category name already exists!</exception>
        public int Add(DiseaseCategory category)
        {
            if (this.dataAccessManager.GetDiseaseCategories().Any(c => c.Name == category.Name))
            {
                throw new ArgumentException("Category name already exists!");
            }
            return this.dataAccessManager.AddDiseaseCategory(category);
        }

        /// <summary>
        /// Deletes the category with specified identifier
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the category with specified identifier
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public DiseaseCategory Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DiseaseCategory> GetAll()
        {
            return this.dataAccessManager.GetDiseaseCategories();
        }

        /// <summary>
        /// Updates the category with specified identifier
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <param name="item">The item</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Update(int id, DiseaseCategory item)
        {
            throw new NotImplementedException();
        }
    }
}