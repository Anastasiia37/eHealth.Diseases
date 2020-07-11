using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eHealth.Diseases.BusinessLogic.DbContext.Entity
{
    /// <summary>
    /// Entity for patient`s diseases
    /// </summary>
    public class PatientDisease
    {
        /// <summary>
        /// Gets or sets the patient disease identifier
        /// </summary>
        /// <value>
        /// The patient disease identifier
        /// </value>
        [Key]
        public int PatientDiseaseId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the patient identifier
        /// </summary>
        /// <value>
        /// The patient identifier
        /// </value>
        [Required(ErrorMessage = "Please, input patient id!")]
        [ForeignKey("PatientInfo")]
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
        [ForeignKey("Disease")]
        public int DiseaseId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the disease
        /// </summary>
        /// <value>
        /// The disease
        /// </value>
        public virtual Disease Disease
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

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>
        /// </value>
        public bool IsDeleted
        {
            get;
            set;
        }
    }
}