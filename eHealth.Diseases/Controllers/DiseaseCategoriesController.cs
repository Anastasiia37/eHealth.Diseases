using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eHealth.Diseases.BusinessLogic.Contracts.Service;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;
using eHealth.Diseases.Models;
using Microsoft.AspNetCore.Mvc;

namespace eHealth.Diseases.Controllers
{
    /// <summary>
    /// Controller for dealing with Disease Categories
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseCategoriesController : ControllerBase
    {
        /// <summary>
        /// The interface link for disease category manager
        /// </summary>
        private IDiseaseCategoryManager diseaseCategoryManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiseaseCategoriesController"/> class
        /// </summary>
        /// <param name="diseaseCategoryManager">The disease category manager</param>
        public DiseaseCategoriesController(IDiseaseCategoryManager diseaseCategoryManager)
        {
            this.diseaseCategoryManager = diseaseCategoryManager;
        }

        /// <summary>
        /// Gets all categories of diseases
        /// GET: api/diseasecategories
        /// </summary>
        /// <returns>
        /// HTTP status code Ok() with the list of disease categories
        /// or HTTP status code NoContent() if there is not categories
        /// </returns>
        [HttpGet()]
        public IActionResult GetDiseaseCategories()
        {
            if (this.diseaseCategoryManager.GetAll().Any())
            {
                return Ok(Mapper.Map<IEnumerable<DiseaseCategoryView>>
                    (this.diseaseCategoryManager.GetAll()));
            }

            return NoContent();
        }

        /// <summary>
        /// Adds the disease category
        /// POST: api/diseasecategories
        /// </summary>
        /// <param name="diseaseCategory">The disease category</param>
        /// <returns>
        /// HTTP status code Created() with newDiseaseCategoryId
        /// or HTTP status code BadRequest() int there are mistakes in input data
        /// </returns>
        [HttpPost]
        public IActionResult AddDiseaseCategory([FromBody]DiseaseCategoryRequest diseaseCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid disease input");
            }

            try
            {
                int newDiseaseCategoryId = this.diseaseCategoryManager.
                    Add(Mapper.Map<DiseaseCategory>(diseaseCategory));
                return Created("diseasecategories/", newDiseaseCategoryId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}