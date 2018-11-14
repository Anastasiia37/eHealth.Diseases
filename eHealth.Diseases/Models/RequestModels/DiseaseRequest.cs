using System.ComponentModel.DataAnnotations;

namespace eHealth.Diseases.Models
{
    /// <summary>
    /// Model for requesting disease
    /// </summary>
    public class DiseaseRequest
    {
        /// <summary>
        /// Gets or sets the name of disease
        /// </summary>
        /// <value>
        /// The name
        /// </value>
        [Required(ErrorMessage = "Disease must have name!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid length of disease name!")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the category identifier of disease
        /// </summary>
        /// <value>
        /// The category identifier
        /// </value>
        [Required(ErrorMessage = "Disease must have category!")]
        public int CategoryId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Required(ErrorMessage = "Disease must have description!")]
        public string Description
        {
            get;
            set;
        }
    }
}