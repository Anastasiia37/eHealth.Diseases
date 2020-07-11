using System;
using System.ComponentModel.DataAnnotations;

namespace eHealth.Diseases.BusinessLogic.Models
{
    /// <summary>
    /// Model for Adding PatientDisease
    /// </summary>
    public class AddPatientDiseaseRequest
    {
        /// <summary>
        /// Gets or sets the patient identifier
        /// </summary>
        /// <value>
        /// The patient identifier
        /// </value>
        [Required(ErrorMessage = "Please, input patient id!")]
        public int PatientId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the disease identifier
        /// </summary>
        /// <value>
        /// The disease identifier
        /// </value>
        [Required(ErrorMessage = "Please, input disease id!")]
        public int DiseaseId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user identifier
        /// </summary>
        /// <value>
        /// The user identifier
        /// </value>
        [Required(ErrorMessage = "Please, input doctor id!")]
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the start date
        /// </summary>
        /// <value>
        /// The start date
        /// </value>
        [Required(ErrorMessage = "Please, input start date of disease!")]
        public DateTime StartDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the end date
        /// </summary>
        /// <value>
        /// The end date
        /// </value>
        public DateTime? EndDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the note
        /// </summary>
        /// <value>
        /// The note
        /// </value>
        public string Note
        {
            get;
            set;
        }
    }
}