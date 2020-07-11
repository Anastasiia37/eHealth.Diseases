using System.ComponentModel.DataAnnotations;

namespace eHealth.Diseases.BusinessLogic.DbContext.Entity
{
    /// <summary>
    /// Entity for disease categories
    /// </summary>
    public class DiseaseCategory
    {
        /// <summary>
        /// Gets or sets the category identifier
        /// </summary>
        /// <value>
        /// The category identifier
        /// </value>
        [Key]
        public int CategoryId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        /// <value>
        /// The name
        /// </value>
        [Required(ErrorMessage = "Disease category must have name!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid length of disease category name!")]
        public string Name
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