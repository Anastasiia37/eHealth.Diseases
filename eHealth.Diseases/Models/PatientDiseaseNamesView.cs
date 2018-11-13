using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eHealth.Diseases.Models
{
    public class PatientDiseaseNamesView
    {
        public int PatientDiseaseId
        {
            get;
            set;
        }

        public string DiseaseName
        {
            get;
            set;
        }
    }
}
