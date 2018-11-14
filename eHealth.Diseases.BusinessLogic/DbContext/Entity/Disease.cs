using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eHealth.Diseases.BusinessLogic.DbContext.Entity
{
    /// <summary>
    /// Entity for diseases
    /// </summary>
    public class Disease
    {
        /// <summary>
        /// Gets or sets the disease identifier
        /// </summary>
        /// <value>
        /// The disease identifier
        /// </value>
        [Key]
        public int DiseaseId
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
        [Required(ErrorMessage = "Disease must have name!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid length of disease name!")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the category identifier
        /// </summary>
        /// <value>
        /// The category identifier
        /// </value>
        [Required(ErrorMessage = "Disease must have category!")]
        [ForeignKey("DiseaseCategory")]
        public int CategoryId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the category
        /// </summary>
        /// <value>
        /// The category
        /// </value>
        public virtual DiseaseCategory Category
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        /// <value>
        /// The description
        /// </value>
        [Required(ErrorMessage = "Disease must have description!")]
        public string Description
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