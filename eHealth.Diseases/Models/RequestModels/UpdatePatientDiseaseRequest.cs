using System;
using System.ComponentModel.DataAnnotations;

namespace eHealth.Diseases.Models
{
    /// <summary>
    /// Model for updating Patient disease
    /// </summary>
    public class UpdatePatientDiseaseRequest
    {
        /// <summary>
        /// Gets or sets the end date of ilness
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
        [Required(ErrorMessage = "Please, add note about your updating!")]
        public string Note
        {
            get;
            set;
        }
    }
}