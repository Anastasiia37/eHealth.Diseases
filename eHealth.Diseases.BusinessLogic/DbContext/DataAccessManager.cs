using System;
using System.Collections.Generic;
using System.Text;
using eHealth.Diseases.BusinessLogic.Contracts;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eHealth.Diseases.BusinessLogic.DbContext
{
    public class DataAccessManager : Microsoft.EntityFrameworkCore.DbContext, IDataAccessManager
    {
        public DataAccessManager(DbContextOptions<DataAccessManager> options)
            : base(options)
        {
        }

        public DbSet<Disease> Diseases
        {
            get;
            set;
        }

        public DbSet<DiseaseCategory> DiseaseCategories
        {
            get;
            set;
        }

        public DbSet<PatientDisease> PatientDiseases
        {
            get;
            set;
        }

        public DbSet<PatientInfo> PatientInfo
        {
            get;
            set;
        }

        public int AddDiseaseToPatient(PatientDisease patientDisease)
        {
            this.PatientDiseases.Add(patientDisease);
            this.SaveChanges();
            return PatientDiseases.Last<PatientDisease>().PatientDiseaseId;
        }

        public int DeleteDiseaseFromPatient(int patientDiseaseId)
        {
            this.PatientDiseases.FirstOrDefault(pd => pd.PatientDiseaseId == patientDiseaseId).IsDeleted = true;
            this.SaveChanges();
            return patientDiseaseId;
        }

        public IEnumerable<Disease> GetDeseases()
        {
            return Diseases;
        }

        public IEnumerable<PatientDisease> GetPatientDiseases(int patientId)
        {
            IEnumerable<PatientDisease> a = this.PatientDiseases.Where(p => p.PatientId == patientId);
            return a;
           // return this.PatientDiseases.Where(p => p.PatientId == patientId);
        }

        public PatientDisease GetPatientDisease(int patientDiseaseId)
        {
            return this.PatientDiseases.FirstOrDefault(patientDisease =>
                patientDisease.PatientDiseaseId == patientDiseaseId);
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
                patientDisease.PatientId == patientId).Select(patientDisease => new PatientDisease
                {
                    PatientDiseaseId = patientDisease.PatientDiseaseId,
                    //DiseaseId = patientDisease.DiseaseId,
                    //Disease = Diseases.FirstOrDefault(d => d.DiseaseId == patientDisease.DiseaseId)
                    Disease = patientDisease.Disease
                });
            return (IEnumerable<PatientDisease>)patientDiseasesNames;
        }

        public int? UpdateDisease(int patientId, int diseaseId, PatientDisease patientDisease)
        {
            throw new NotImplementedException();
        }

        public string GetDiseaseName(int diseaseId)
        {
            return this.Diseases.FirstOrDefault(d => d.DiseaseId == diseaseId).Name;
        }

        public bool isValidPatientId(int patientId)
        {
            if (this.PatientInfo.Any(p => p.PatientId == patientId))
            {
                return true;
            }

            return false;
        }

        public bool isValidPatientDiseaseId(int patientDiseaseId)
        {
            if (this.PatientDiseases.Any(p => p.PatientDiseaseId == patientDiseaseId))
            {
                return true;
            }

            return false;
        }

        public IEnumerable<DiseaseCategory> GetDiseaseCategories()
        {
            return this.DiseaseCategories;
        }

        public IEnumerable<Disease> GetDiseasesInCategory(int categoryId)
        {
            return this.Diseases.Where(disease => disease.CategoryId == categoryId);
        }

        public Disease GetDisease(int diseaseId)
        {
            return this.Diseases.FirstOrDefault(disease => disease.DiseaseId == diseaseId);
        }

        public int AddDisease(Disease disease)
        {
            this.Diseases.Add(disease);
            this.SaveChanges();
            return this.Diseases.FirstOrDefault(d => d.Name == disease.Name).DiseaseId;
        }

        public int DeleteDisease(int diseaseId)
        {
            this.Diseases.FirstOrDefault(disease => disease.DiseaseId == diseaseId).IsDeleted = true;
            this.SaveChanges();
            return diseaseId;
        }

        public int UpdateDisease(int diseaseId, Disease disease)
        {
            Disease diseaseForUpdate = this.Diseases.FirstOrDefault(d => d.DiseaseId == diseaseId);
            diseaseForUpdate.Name = disease.Name;
            diseaseForUpdate.CategoryId = disease.CategoryId;
            diseaseForUpdate.Description = disease.Description;
            this.SaveChanges();
            return disease.DiseaseId;
        }
    }
}