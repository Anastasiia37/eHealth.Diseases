using eHealth.Diseases.BusinessLogic.DbContext.Entity;

namespace eHealth.Diseases.BusinessLogic.Contracts.Service
{
    /// <summary>
    /// Interface for DiseaseCategory manager
    /// </summary>
    /// <seealso cref="eHealth.Diseases.BusinessLogic.Contracts.Service.IDiseasesManager{eHealth.Diseases.BusinessLogic.DbContext.Entity.DiseaseCategory}" />
    public interface IDiseaseCategoryManager : IDiseasesManager<DiseaseCategory>
    {
    }
}