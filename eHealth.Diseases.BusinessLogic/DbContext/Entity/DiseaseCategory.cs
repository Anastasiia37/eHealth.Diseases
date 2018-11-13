using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eHealth.Diseases.BusinessLogic.DbContext.Entity
{
    public class DiseaseCategory
    {
        [Key]
        public int CategoryId
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Disease category must have name!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid length of disease category name!")]
        public string Name
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        //Lazy loading
        /*public virtual List<Disease> Diseases
        {
            get;
            set;
        }*/
    }
}