using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eHealth.Diseases.Models
{
    public class DiseaseRequest
    {
        [Required(ErrorMessage = "Disease must have name!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid length of disease name!")]
        public string Name
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Disease must have category!")]
        public int CategoryId
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Disease must have description!")]
        public string Description
        {
            get;
            set;
        }
    }
}