using System.Collections.Generic;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;

namespace eHealth.Diseases.BusinessLogic.Contracts.Service
{
    /// <summary>
    /// Interface of services for dealing with patient diseases
    /// </summary>
    public interface IPatientDiseaseManager : IDiseasesManager<PatientDisease>
    {
        /// <summary>
        /// Gets the disease names of the specified patient
        /// </summary>
        /// <param name="patientId">The patient identifier</param>
        /// <returns>
        /// The enumeration of patient disease names
        /// </returns>
        IEnumerable<PatientDisease> GetPatientDiseaseNames(int patientId);

        /// <summary>
        /// Gets the patient diseases
        /// </summary>
        /// <param name="patientId">The patient identifier</param>
        /// <returns>
        /// The list of patient diseases
        /// </returns>
        IEnumerable<PatientDisease> GetPatientDiseases(int patientId);
    }
}