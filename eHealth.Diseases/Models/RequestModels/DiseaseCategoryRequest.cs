using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eHealth.Diseases.Models
{
    /// <summary>
    /// Model for requesting disease category
    /// </summary>
    public class DiseaseCategoryRequest
    {
        /// <summary>
        /// Gets or sets the name of category
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required(ErrorMessage = "Disease category must have name!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid length of disease category name!")]
        public string Name
        {
            get;
            set;
        }
    }
}