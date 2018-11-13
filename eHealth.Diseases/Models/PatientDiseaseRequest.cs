using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eHealth.Diseases.BusinessLogic.Models
{
    public class PatientDiseaseRequest
    {
        [Required(ErrorMessage = "Please, input patient id!")]
        public int PatientId
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please, input disease id!")]
        public int DiseaseId
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please, input doctor id!")]
        public int UserId
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please, input start date of disease!")]
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