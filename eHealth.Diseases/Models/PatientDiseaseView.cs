using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eHealth.Diseases.Models
{
    public class PatientDiseaseView
    {
        [Key]
        public int PatientDiseaseId
        {
            get;
            set;
        }

        public int PatientId
        {
            get;
            set;
        }

        public int DiseaseId
        {
            get;
            set;
        }

        /*public string DiseaseName
        {
            get;
            set;
        }

        public string DiseaseCategory
        {
            get;
            set;
        }

        public string DiseaseDescription
        {
            get;
            set;
        }*/

        public DiseaseView Disease
        {
            get;
            set;
        }

        /*public string DoctorName
        {
            get;
            set;
        }*/

        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime? EndDate
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }
    }
}