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
    ///  Controller for dealing with Diseases
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        /// <summary>
        /// The interface link for disease category manager
        /// </summary>
        private IDiseaseManager diseaseManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiseasesController"/> class
        /// </summary>
        /// <param name="diseaseManager">The disease manager.</param>
        public DiseasesController(IDiseaseManager diseaseManager)
        {
            this.diseaseManager = diseaseManager;
        }

        /// <summary>
        /// Gets all diseases
        /// GET: api/diseases
        /// </summary>
        /// <returns>
        /// All diseases
        /// </returns>
        [HttpGet]
        public IActionResult GetDiseases()
        {
            if (this.diseaseManager.GetAll().Any())
            {
                return Ok(Mapper.Map<IEnumerable<DiseaseView>>(this.diseaseManager.GetAll()));
            }

            return NoContent();
        }

        /// <summary>
        /// Gets the diseases in category
        /// GET: api/diseases/categoryid=2
        /// </summary>
        /// <param name="categoryId">The category identifier</param>
        /// <returns>
        /// All diseases from specified category
        /// </returns>
        [HttpGet("categoryid={categoryId}")]
        public IActionResult GetDiseasesInCategory(int categoryId)
        {
            try
            {
                if (this.diseaseManager.GetDiseasesInCategory(categoryId).Any())
                {
                    return Ok(Mapper.Map<IEnumerable<DiseaseView>>(this.diseaseManager.GetDiseasesInCategory(categoryId)));
                }

                return NoContent();
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Gets the disease
        /// GET: api/diseases/2
        /// </summary>
        /// <param name="diseaseId">The disease identifier</param>
        /// <returns>
        /// The disease with specified identifier
        /// </returns>
        [HttpGet("{diseaseId}")]
        public IActionResult GetDisease(int diseaseId)
        {
            if (this.diseaseManager.Get(diseaseId) != null)
            {
                return Ok(Mapper.Map<DiseaseView>(this.diseaseManager.Get(diseaseId)));
            }

            return BadRequest("Not valid disease id!");
        }

        /// <summary>
        /// Adds the disease
        /// POST: api/diseases
        /// </summary>
        /// <param name="disease">The disease</param>
        /// <returns>
        /// Id of added diseases
        /// </returns>
        [HttpPost]
        public IActionResult AddDisease([FromBody]DiseaseRequest disease)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid disease input");
            }

            try
            {
                int newDiseaseId = this.diseaseManager.Add(Mapper.Map<Disease>(disease));
                return Created("diseases/", newDiseaseId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Updates the disease
        /// PUT: api/diseases/5
        /// </summary>
        /// <param name="diseaseId">The disease identifier</param>
        /// <param name="disease">The disease</param>
        /// <returns>
        /// Id of updated disease
        /// </returns>
        [HttpPut("{diseaseId}")]
        public IActionResult UpdateDisease(int diseaseId, [FromBody]DiseaseRequest disease)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid disease input");
            }

            try
            {
                return Ok(this.diseaseManager.Update(diseaseId, Mapper.Map<Disease>(disease)));
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Deletes the disease
        /// DELETE: api/diseases/5
        /// </summary>
        /// <param name="diseaseId">The disease identifier</param>
        /// <returns>
        /// Id of deleted disease
        /// </returns>
        [HttpDelete("{diseaseId}")]
        public IActionResult DeleteDisease(int diseaseId)
        {
            try
            {
                return Ok(this.diseaseManager.Delete(diseaseId));
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}