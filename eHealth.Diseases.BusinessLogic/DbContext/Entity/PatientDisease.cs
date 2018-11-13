using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eHealth.Diseases.BusinessLogic.DbContext.Entity
{
    public class PatientDisease
    {
        [Key]
        public int PatientDiseaseId
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please, input patient id!")]
        [ForeignKey("PatientInfo")]
        public int PatientId
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please, input disease id!")]
        [ForeignKey("Disease")]
        public int DiseaseId
        {
            get;
            set;
        }

        public virtual Disease Disease
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

        // ????
        [NotMapped]
        public bool IsFinished
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
    }
}