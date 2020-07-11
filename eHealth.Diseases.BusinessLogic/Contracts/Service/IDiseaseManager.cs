using System.Collections.Generic;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;

namespace eHealth.Diseases.BusinessLogic.Contracts.Service
{
    /// <summary>
    /// Interface for Disease manager
    /// </summary>
    /// <seealso cref="eHealth.Diseases.BusinessLogic.Contracts.Service.IDiseasesManager{eHealth.Diseases.BusinessLogic.DbContext.Entity.Disease}" />
    public interface IDiseaseManager : IDiseasesManager<Disease>
    {
        /// <summary>
        /// Gets the diseases of specified category
        /// </summary>
        /// <param name="categoryId">The category identifier</param>
        /// <returns>
        /// The list of diseases
        /// </returns>
        IEnumerable<Disease> GetDiseasesInCategory(int categoryId);
    }
}