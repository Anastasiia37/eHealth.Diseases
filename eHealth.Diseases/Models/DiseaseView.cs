using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;

namespace eHealth.Diseases.Models
{
    public class DiseaseView
    {
        public int DiseaseId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public DiseaseCategoryView Category
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}