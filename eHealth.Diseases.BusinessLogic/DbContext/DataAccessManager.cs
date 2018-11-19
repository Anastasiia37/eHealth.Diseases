using System;
using System.Collections.Generic;
using System.Linq;
using eHealth.Diseases.BusinessLogic.Contracts;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;
using Microsoft.EntityFrameworkCore;

namespace eHealth.Diseases.BusinessLogic.DbContext
{
    /// <summary>
    /// Manager for data access
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// <seealso cref="eHealth.Diseases.BusinessLogic.Contracts.IDataAccessManager" />
    public class DataAccessManager : Microsoft.EntityFrameworkCore.DbContext, IDataAccessManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessManager"/> class
        /// </summary>
        /// <param name="options">The options</param>
        public DataAccessManager(DbContextOptions<DataAccessManager> options)
            : base(options)
        {
        }

        #region Entities

        /// <summary>
        /// Gets or sets the diseases
        /// </summary>
        /// <value>
        /// The diseases
        /// </value>
        public DbSet<Disease> Diseases
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the disease categories
        /// </summary>
        /// <value>
        /// The disease categories
        /// </value>
        public DbSet<DiseaseCategory> DiseaseCategories
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the patient diseases
        /// </summary>
        /// <value>
        /// The patient diseases
        /// </value>
        public DbSet<PatientDisease> PatientDiseases
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the patient information
        /// </summary>
        /// <value>
        /// The patient information
        /// </value>
        public DbSet<PatientInfo> PatientInfo
        {
            get;
            set;
        }

        #endregion Entities

        #region PatientDiseasesDataManager

        /// <summary>
        /// Gets the disease of the specified patient
        /// </summary>
        /// <param name="patientId">The patient identifier</param>
        /// <returns>
        /// The enumeration of patient diseases with all it`s parameters
        /// </returns>
        public IEnumerable<PatientDisease> GetPatientDiseases(int patientId)
        {
            // Using linq
            // return this.PatientDiseases.Where(p => p.PatientId == patientId && p.IsDeleted == false);
            return this.Set<PatientDisease>().FromSql("[dbo].[GetPatientDiseases] @patientId = {0}", patientId);
        }

        /// <summary>
        /// Gets the extended description of patient disease
        /// </summary>
        /// <param name="patientDiseaseId">The patient disease identifier</param>
        /// <returns>
        /// The Disease
        /// </returns>
        public PatientDisease GetPatientDisease(int patientDiseaseId)
        {
            return this.PatientDiseases.FirstOrDefault(patientDisease =>
                patientDisease.PatientDiseaseId == patientDiseaseId && patientDisease.IsDeleted == false);
        }

        /// <summary>
        /// Gets the disease names of the specified patient
        /// </summary>
        /// <param name="patientId">The patient identifier</param>
        /// <returns>
        /// The enumeration of patient disease names
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<PatientDisease> GetPatientDiseaseNames(int patientId)
        {
            var patientDiseasesNames = this.PatientDiseases.Where(patientDisease =>
                patientDisease.PatientId == patientId && patientDisease.IsDeleted == false).
                Select(patientDisease => new PatientDisease
                {
                    PatientDiseaseId = patientDisease.PatientDiseaseId,
                    Disease = patientDisease.Disease
                });
            return (IEnumerable<PatientDisease>)patientDiseasesNames;
        }

        /// <summary>
        /// Adds the disease to the patient
        /// </summary>
        /// <param name="patientDisease">The new patient disease</param>
        /// <returns>
        /// The identifier of added patient disease
        /// </returns>
        public int AddDiseaseToPatient(PatientDisease patientDisease)
        {
            this.PatientDiseases.Add(patientDisease);
            this.SaveChanges();
            //this.Set<PatientDisease>().FromSql()
            return PatientDiseases.Last<PatientDisease>().PatientDiseaseId;
        }

        /// <summary>
        /// Updates patient disease
        /// </summary>
        /// <param name="patientDiseaseId"></param>
        /// <param name="patientDisease"></param>
        /// <returns>
        /// The identifier of updated patient disease
        /// or null if patient disease id does not exist
        /// </returns>
        public int UpdatePatientDisease(int patientDiseaseId, PatientDisease patientDisease)
        {
            PatientDisease patientDiseaseForUpdate = this.PatientDiseases.FirstOrDefault(pd =>
                pd.PatientDiseaseId == patientDiseaseId);
            patientDiseaseForUpdate.EndDate = patientDisease.EndDate;
            patientDiseaseForUpdate.Note = patientDisease.Note;
            patientDiseaseForUpdate.UserId = patientDisease.UserId;
            this.SaveChanges();
            return patientDiseaseForUpdate.PatientDiseaseId;
        }

        /// <summary>
        /// Deletes the disease from patient
        /// </summary>
        /// <param name="patientDiseaseId"></param>
        /// <returns>
        /// The identifier of deleted patient disease
        /// or null if patient disease id does not exist
        /// </returns>
        public int DeleteDiseaseFromPatient(int patientDiseaseId)
        {
            this.PatientDiseases.FirstOrDefault(pd => pd.PatientDiseaseId == patientDiseaseId).IsDeleted = true;
            this.SaveChanges();
            return patientDiseaseId;
        }

        #endregion PatientDiseasesDataManager

        #region DiseasesDataManager

        /// <summary>
        /// Gets the diseases
        /// </summary>
        /// <returns>
        /// The enumeration of diseases
        /// </returns>
        public IEnumerable<Disease> GetDiseases()
        {
            return Diseases.Where(d => d.IsDeleted == false);
        }

        /// <summary>
        /// Gets the diseases in category
        /// </summary>
        /// <param name="categoryId">The category identifier</param>
        /// <returns>
        /// The enumeration of diseases
        /// </returns>
        public IEnumerable<Disease> GetDiseasesInCategory(int categoryId)
        {
            return this.Diseases.Where(disease =>
                disease.CategoryId == categoryId && disease.IsDeleted == false);
        }

        /// <summary>
        /// Gets the disease
        /// </summary>
        /// <param name="diseaseId">The disease identifier</param>
        /// <returns>
        /// Disease
        /// </returns>
        public Disease GetDisease(int diseaseId)
        {
            return this.Diseases.FirstOrDefault(disease =>
                disease.DiseaseId == diseaseId && disease.IsDeleted == false);
        }

        /// <summary>
        /// Adds the disease
        /// </summary>
        /// <param name="disease">The disease</param>
        /// <returns>
        /// Disease id
        /// </returns>
        public int AddDisease(Disease disease)
        {
            this.Diseases.Add(disease);
            this.SaveChanges();
            return this.Diseases.FirstOrDefault(d => d.Name == disease.Name).DiseaseId;
        }

        /// <summary>
        /// Updates the disease
        /// </summary>
        /// <param name="diseaseId">The disease identifier</param>
        /// <param name="disease">The disease</param>
        /// <returns>
        /// Updated disease id
        /// </returns>
        public int UpdateDisease(int diseaseId, Disease disease)
        {
            Disease diseaseForUpdate = this.Diseases.FirstOrDefault(d => d.DiseaseId == diseaseId);
            diseaseForUpdate.Name = disease.Name;
            diseaseForUpdate.CategoryId = disease.CategoryId;
            diseaseForUpdate.Description = disease.Description;
            this.SaveChanges();
            return diseaseForUpdate.DiseaseId;
        }

        /// <summary>
        /// Deletes the disease
        /// </summary>
        /// <param name="diseaseId">The disease identifier</param>
        /// <returns>
        /// Deleted disease id
        /// </returns>
        public int DeleteDisease(int diseaseId)
        {
            this.Diseases.FirstOrDefault(disease => disease.DiseaseId == diseaseId).IsDeleted = true;
            this.SaveChanges();
            return diseaseId;
        }

        #endregion DiseasesDataManager

        #region DiseaseCategoriesManager

        /// <summary>
        /// Gets the enumeration of disease categories
        /// </summary>
        /// <returns>
        /// Enumeration of disease categories
        /// </returns>
        public IEnumerable<DiseaseCategory> GetDiseaseCategories()
        {
            return this.DiseaseCategories.Where(c => c.IsDeleted == false);
        }

        /// <summary>
        /// Adds the disease category
        /// </summary>
        /// <param name="category">The category</param>
        /// <returns>
        /// Id of added category
        /// </returns>
        public int AddDiseaseCategory(DiseaseCategory category)
        {
            this.DiseaseCategories.Add(category);
            this.SaveChanges();
            return this.DiseaseCategories.FirstOrDefault(c => c.Name == category.Name).CategoryId;
        }

        #endregion DiseaseCategoriesManager

        #region IsValidId

        /// <summary>
        /// Determines whether patient identifier is valid
        /// </summary>
        /// <param name="patientId">The patient identifier</param>
        /// <returns>
        ///   <c>true</c> if patient identifier is valid; otherwise, <c>false</c>
        /// </returns>
        public bool isValidPatientId(int patientId)
        {
            if (this.PatientInfo.Any(p => p.PatientId == patientId))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether patient disease identifier is valid
        /// </summary>
        /// <param name="patientDiseaseId">The patient disease identifier.</param>
        /// <returns>
        ///   <c>true</c> if patient disease identifier is valid; otherwise, <c>false</c>
        /// </returns>
        public bool isValidPatientDiseaseId(int patientDiseaseId)
        {
            if (this.PatientDiseases.Any(p => p.PatientDiseaseId == patientDiseaseId))
            {
                return true;
            }

            return false;
        }

        #endregion IsValidId
    }
}