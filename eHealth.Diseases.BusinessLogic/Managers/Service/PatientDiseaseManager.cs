using System;
using System.Collections.Generic;
using System.Text;
using eHealth.Diseases.BusinessLogic.Contracts.Service;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;
using eHealth.Diseases.BusinessLogic.DbContext;
using eHealth.Diseases.BusinessLogic.Contracts;

namespace eHealth.Diseases.BusinessLogic.Managers.Service
{
    public class PatientDiseaseManager : IPatientDiseaseManager
    {
        private IDataAccessManager dataAccessManager;

        public PatientDiseaseManager(IDataAccessManager dataAccessManager)
        {
            this.dataAccessManager = dataAccessManager;
        }

        public int AddDiseaseToPatient(PatientDisease patientDisease)
        {
            if (this.GetDisease(patientDisease.DiseaseId) == null)
            {
                throw new ArgumentException("Not valid disease id!");
            }

            if (this.dataAccessManager.isValidPatientId(patientDisease.PatientId))
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

        public int DeleteDiseaseFromPatient(int patientDiseaseId)
        {
            if (this.dataAccessManager.GetPatientDisease(patientDiseaseId) != null)
            {
                return this.dataAccessManager.DeleteDiseaseFromPatient(patientDiseaseId);
            }

            throw new ArgumentException("Invalis patient`s disease id!");
        }

        public IEnumerable<Disease> GetDisease(int patientId)
        {
            throw new NotImplementedException();
        }

        public PatientDisease GetPatientDisease(int patientDiseaseId)
        {
            if (this.dataAccessManager.isValidPatientDiseaseId(patientDiseaseId))
            {
                return this.dataAccessManager.GetPatientDisease(patientDiseaseId);
            }

            throw new ArgumentException("Not valid patient`s disease id!");
        }

        public IEnumerable<PatientDisease> GetPatientDiseaseNames(int patientId)
        {
            if (this.dataAccessManager.isValidPatientId(patientId))
            {
                return this.dataAccessManager.GetPatientDiseaseNames(patientId);
            }

            throw new ArgumentException("Not valid patient id!");
        }

        public IEnumerable<PatientDisease> GetPatientDiseases(int patientId)
        {
            var a = this.dataAccessManager.GetPatientDiseases(patientId); ;
            return a;
            //return this.dataAccessManager.GetPatientDiseases(patientId);
        }

        public int? UpdateDisease(int patientId, int diseaseId, PatientDisease patientDisease)
        {
            throw new NotImplementedException();
        }
    }
}
