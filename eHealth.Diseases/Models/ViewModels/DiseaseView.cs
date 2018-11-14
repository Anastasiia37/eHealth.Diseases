namespace eHealth.Diseases.Models
{
    /// <summary>
    /// Model for view of disease
    /// </summary>
    public class DiseaseView
    {
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
        /// Gets or sets the name
        /// </summary>
        /// <value>
        /// The name
        /// </value>
        public string Name
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
        public DiseaseCategoryView Category
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
        public string Description
        {
            get;
            set;
        }
    }
}