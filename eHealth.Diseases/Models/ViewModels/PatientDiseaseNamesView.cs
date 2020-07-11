namespace eHealth.Diseases.Models
{
    /// <summary>
    /// Model for view of patient`s disease names
    /// </summary>
    public class PatientDiseaseNamesView
    {
        /// <summary>
        /// Gets or sets the patient disease identifier
        /// </summary>
        /// <value>
        /// The patient disease identifier
        /// </value>
        public int PatientDiseaseId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the disease
        /// </summary>
        /// <value>
        /// The name of the disease
        /// </value>
        public string DiseaseName
        {
            get;
            set;
        }
    }
}