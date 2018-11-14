using System;
using System.ComponentModel.DataAnnotations;

namespace eHealth.Diseases.Models
{
    /// <summary>
    /// Model for view of patient disease
    /// </summary>
    public class PatientDiseaseView
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
        public DiseaseView Disease
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