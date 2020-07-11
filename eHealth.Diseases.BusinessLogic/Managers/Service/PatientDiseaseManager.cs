using System;
using System.Collections.Generic;
using eHealth.Diseases.BusinessLogic.Contracts;
using eHealth.Diseases.BusinessLogic.Contracts.Service;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;

namespace eHealth.Diseases.BusinessLogic.Managers.Service
{
    /// <summary>
    /// Service for working with patient`s diseases
    /// </summary>
    /// <seealso cref="eHealth.Diseases.BusinessLogic.Contracts.Service.IPatientDiseaseManager" />
    public class PatientDiseaseManager : IPatientDiseaseManager
    {
        /// <summary>
        /// The data access manager
        /// </summary>
        private IDataAccessManager dataAccessManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientDiseaseManager"/> class
        /// </summary>
        /// <param name="dataAccessManager">The data access manager</param>
        public PatientDiseaseManager(IDataAccessManager dataAccessManager)
        {
            this.dataAccessManager = dataAccessManager;
        }

        /// <summary>
        /// Adds the specified patient disease
        /// </summary>
        /// <param name="patientDisease">The patient disease</param>
        /// <returns>
        /// Id of added entity
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Not valid disease id!
        /// or
        /// Not valid patient id!
        /// or
        /// Not valid start date!
        /// or
        /// Start date can`t be later end date!
        /// </exception>
        public int Add(PatientDisease patientDisease)
        {
            if (this.dataAccessManager.GetDisease(patientDisease.DiseaseId) == null)
            {
                throw new ArgumentException("Not valid disease id!");
            }

            if (!this.dataAccessManager.isValidPatientId(patientDisease.PatientId))
            {
                throw new ArgumentException("Not valid patient id!");
            }

            if (patientDisease.StartDate > DateTime.Now)
            {
                throw new ArgumentException("Not valid start date!");
            }

            if (patientDisease.StartDate > patientDisease.EndDate && patientDisease.EndDate != null)
            {
                throw new ArgumentException("Start date can`t be later end date!");
            }

            return this.dataAccessManager.AddDiseaseToPatient(patientDisease);
        }

        /// <summary>
        /// Deletes the patient disease with specified  identifier
        /// </summary>
        /// <param name="patientDiseaseId">The patient disease identifier</param>
        /// <returns>
        /// Id of deleted entity
        /// </returns>
        /// <exception cref="ArgumentException">Invalid patient`s disease id!</exception>
        public int Delete(int patientDiseaseId)
        {
            if (this.dataAccessManager.GetPatientDisease(patientDiseaseId) != null)
            {
                return this.dataAccessManager.DeleteDiseaseFromPatient(patientDiseaseId);
            }

            throw new ArgumentException("Invalid patient`s disease id!");
        }

        /// <summary>
        /// Gets the patient disease with specified identifier
        /// </summary>
        /// <param name="patientDiseaseId">The patient disease identifier</param>
        /// <returns>
        /// Patient disease
        /// </returns>
        /// <exception cref="ArgumentException">Not valid patient`s disease id!</exception>
        public PatientDisease Get(int patientDiseaseId)
        {
            if (this.dataAccessManager.isValidPatientDiseaseId(patientDiseaseId))
            {
                return this.dataAccessManager.GetPatientDisease(patientDiseaseId);
            }

            throw new ArgumentException("Not valid patient`s disease id!");
        }

        public IEnumerable<PatientDisease> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the disease names of the specified patient
        /// </summary>
        /// <param name="patientId">The patient identifier</param>
        /// <returns>
        /// The enumeration of patient disease names
        /// </returns>
        /// <exception cref="ArgumentException">Not valid patient id!</exception>
        public IEnumerable<PatientDisease> GetPatientDiseaseNames(int patientId)
        {
            if (this.dataAccessManager.isValidPatientId(patientId))
            {
                return this.dataAccessManager.GetPatientDiseaseNames(patientId);
            }

            throw new ArgumentException("Not valid patient id!");
        }

        /// <summary>
        /// Gets the patient diseases
        /// </summary>
        /// <param name="patientId">The patient identifier</param>
        /// <returns>
        /// The list of patient diseases
        /// </returns>
        public IEnumerable<PatientDisease> GetPatientDiseases(int patientId)
        {
            if (this.dataAccessManager.isValidPatientId(patientId))
            {
                return this.dataAccessManager.GetPatientDiseases(patientId);
            }

            throw new ArgumentException("Not valid patient id!");
        }

        /// <summary>
        /// Updates the patient disease with specified identifier
        /// </summary>
        /// <param name="patientDiseaseId">The patient disease identifier</param>
        /// <param name="patientDisease">The patient disease</param>
        /// <returns>
        /// Id of updated disease
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Not valid patient`s disease id!
        /// or
        /// Not valid end date!
        /// </exception>
        public int Update(int patientDiseaseId, PatientDisease patientDisease)
        {
            if (this.dataAccessManager.GetPatientDisease(patientDiseaseId) == null)
            {
                throw new ArgumentException("Not valid patient`s disease id!");
            }

            if (this.dataAccessManager.GetPatientDisease(patientDiseaseId).StartDate > patientDisease.EndDate)
            {
                throw new ArgumentException("End date can`t be less start day!");
            }

            if (patientDisease.EndDate > DateTime.Now)
            {
                throw new ArgumentException("End date can`t be after Now!");
            }

            return this.dataAccessManager.UpdatePatientDisease(patientDiseaseId, patientDisease);
        }
    }
}