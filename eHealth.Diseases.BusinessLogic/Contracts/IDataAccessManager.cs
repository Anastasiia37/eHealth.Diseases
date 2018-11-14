using System.Collections.Generic;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;

namespace eHealth.Diseases.BusinessLogic.Contracts
{
    /// <summary>
    /// interface for Data Access Manager
    /// </summary>
    public interface IDataAccessManager
    {
        #region Disease
        /// <summary>
        /// Gets the diseases
        /// </summary>
        /// <returns>
        /// The enumeration of diseases
        /// </returns>
        IEnumerable<Disease> GetDiseases();

        /// <summary>
        /// Gets the diseases in category
        /// </summary>
        /// <param name="categoryId">The category identifier</param>
        /// <returns>
        /// The enumeration of diseases
        /// </returns>
        IEnumerable<Disease> GetDiseasesInCategory(int categoryId);

        /// <summary>
        /// Gets the disease
        /// </summary>
        /// <param name="diseaseId">The disease identifier</param>
        /// <returns>
        /// Disease
        /// </returns>
        Disease GetDisease(int diseaseId);

        /// <summary>
        /// Adds the disease
        /// </summary>
        /// <param name="disease">The disease</param>
        /// <returns>
        /// Disease id
        /// </returns>
        int AddDisease(Disease disease);

        /// <summary>
        /// Deletes the disease
        /// </summary>
        /// <param name="diseaseId">The disease identifier</param>
        /// <returns>
        /// Deleted disease id
        /// </returns>
        int DeleteDisease(int diseaseId);

        /// <summary>
        /// Updates the disease
        /// </summary>
        /// <param name="diseaseId">The disease identifier</param>
        /// <param name="disease">The disease</param>
        /// <returns>
        /// Updated disease id
        /// </returns>
        int UpdateDisease(int diseaseId, Disease disease);
        #endregion

        #region PatirntDisease
        /// <summary>
        /// Gets the disease names of the specified patient
        /// </summary>
        /// <param name="patientId">The patient identifier</param>
        /// <returns>
        /// The enumeration of patient disease names
        /// </returns>
        IEnumerable<PatientDisease> GetPatientDiseaseNames(int patientId);

        /// <summary>
        /// Gets the disease of the specified patient
        /// </summary>
        /// <param name="patientId">The patient identifier</param>
        /// <returns>
        /// The enumeration of patient diseases with all it`s parameters
        /// </returns>
        IEnumerable<PatientDisease> GetPatientDiseases(int patientId);

        /// <summary>
        /// Gets the extended description of patient disease
        /// </summary>
        /// <param name="patientDiseaseId">The patient disease identifier</param>
        /// <returns>
        /// The Disease
        /// </returns>
        PatientDisease GetPatientDisease(int patientDiseaseId);

        /// <summary>
        /// Adds the disease to the patient
        /// </summary>
        /// <param name="patientId">The patient identifier</param>
        /// <param name="patientDisease">The new patient disease</param>
        /// <returns>
        /// The identifier of added patient disease
        /// </returns>
        int AddDiseaseToPatient(PatientDisease patientDisease);

        /// <summary>
        /// Deletes the disease from patient
        /// </summary>
        /// <param name="patientId">The patient disease identifier</param>
        /// <returns>
        /// The identifier of deleted patient disease
        /// or null if patient disease id does not exist
        /// </returns>
        int DeleteDiseaseFromPatient(int patientDiseaseId);

        /// <summary>
        /// Updates patient disease
        /// </summary>
        /// <param name="patientId">The patient disease identifier</param>
        /// <returns>
        /// The identifier of updated patient disease
        /// or null if patient disease id does not exist
        /// </returns>
        int UpdatePatientDisease(int patientDiseaseId, PatientDisease patientDisease);
        #endregion

        /// <summary>
        /// Gets the enumeration of disease categories
        /// </summary>
        /// <returns>
        /// Enumeration of disease categories
        /// </returns>
        IEnumerable<DiseaseCategory> GetDiseaseCategories();

        /// <summary>
        /// Adds the disease category
        /// </summary>
        /// <param name="category">The category</param>
        /// <returns>
        /// Id of added category
        /// </returns>
        int AddDiseaseCategory(DiseaseCategory category);

        /// <summary>
        /// Determines whether patient identifier is valid
        /// </summary>
        /// <param name="patientId">The patient identifier</param>
        /// <returns>
        ///   <c>true</c> if patient identifier is valid; otherwise, <c>false</c>
        /// </returns>
        bool isValidPatientId(int patientId);

        /// <summary>
        /// Determines whether patient disease identifier is valid
        /// </summary>
        /// <param name="patientDiseaseId">The patient disease identifier.</param>
        /// <returns>
        ///   <c>true</c> if patient disease identifier is valid; otherwise, <c>false</c>
        /// </returns>
        bool isValidPatientDiseaseId(int patientDiseaseId);
    }
}