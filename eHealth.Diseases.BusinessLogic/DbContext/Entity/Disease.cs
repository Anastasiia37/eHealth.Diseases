using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eHealth.Diseases.BusinessLogic.DbContext.Entity
{
    public class Disease
    {
        [Key]
        public int DiseaseId
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Disease must have name!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid length of disease name!")]
        public string Name
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Disease must have category!")]
        [ForeignKey("DiseaseCategory")]
        public int CategoryId
        {
            get;
            set;
        }

        public virtual DiseaseCategory Category
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

        public bool IsDeleted
        {
            get;
            set;
        }
    }
}