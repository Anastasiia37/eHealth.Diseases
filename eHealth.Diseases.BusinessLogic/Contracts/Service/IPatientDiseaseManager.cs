using System;
using System.Collections.Generic;
using System.Text;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;
namespace eHealth.Diseases.BusinessLogic.Contracts.Service
{
    /// <summary>
    /// Services for dealing with patient diseases
    /// </summary>
    public interface IPatientDiseaseManager
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
        /// Gets the disease of the specified patient
        /// </summary>
        /// <param name="patientId">The patient identifier</param>
        /// <returns>
        /// The enumeration of patient diseases with all it`s parameters
        /// </returns>
        IEnumerable<Disease> GetDisease(int patientId);

        IEnumerable<PatientDisease> GetPatientDiseases(int patientId);

        /// <summary>
        /// Gets the extended description of patient disease
        /// </summary>
        /// <param name="patientId">The patient disease identifier</param>
        /// <returns>
        /// The patient disease
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
        /// or null if patient id does not exist or disease id does not exist
        /// </returns>
        int DeleteDiseaseFromPatient(int patientDiseaseId);

        /// <summary>
        /// Updates the patient disease
        /// </summary>
        /// <param name="patientId">The patient identifier</param>
        /// <param name="diseaseId">The disease identifier</param>
        /// <param name="patientDisease">The updated patient disease</param>
        /// <returns>
        /// The identifier of updated patient disease
        /// or null if patient id does not exist or disease id does not exist
        /// </returns>
        int? UpdateDisease(int patientId, int diseaseId, PatientDisease patientDisease);
    }
}