using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eHealth.Diseases.BusinessLogic.Contracts.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using eHealth.Diseases.Models;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;

namespace eHealth.Diseases.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private IDiseaseManager diseaseManager;

        public DiseasesController(IDiseaseManager diseaseManager)
        {
            this.diseaseManager = diseaseManager;
        }

        [HttpGet("categories")]
        // GET: api/diseases/categories
        public IActionResult GetDiseaseCategories()
        {
            if (this.diseaseManager.GetDiseaseCategories().Any())
            {
                return Ok(Mapper.Map<IEnumerable<DiseaseCategoryView>>(this.diseaseManager.GetDiseaseCategories()));
            }

            return NoContent();
        }

        [HttpGet]
        // GET: api/diseases
        public IActionResult GetDiseases()
        {
            /*if (this.diseaseManager.Get().Any())
            {
                return Ok(this.diseaseManager.Get());
            }*/

            return NoContent();
        }

        [HttpGet("categoryid={categoryId}")]
        // GET: api/diseases/categoryid=2
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
                return NotFound(exception.Message);
            }
        }

        [HttpGet("{diseaseId}")]
        // GET: api/diseases/2
        public IActionResult GetDisease(int diseaseId)
        {
            if (this.diseaseManager.GetDisease(diseaseId) != null)
            {
                return Ok(Mapper.Map<DiseaseView>(this.diseaseManager.GetDisease(diseaseId)));
            }

            return NotFound("Not valid disease id!");
        }

        [HttpPost]
        // POST: api/diseases
        public IActionResult AddDisease([FromBody]DiseaseRequest disease)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid disease input");
            }

            try
            {
                int newDiseaseId = this.diseaseManager.AddDisease(Mapper.Map<Disease>(disease));
                return Created("diseases/", newDiseaseId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{diseaseId}")]
        // DELETE: api/diseases/5
        public IActionResult DeleteDisease(int diseaseId)
        {
            try
            {
                return Ok(this.diseaseManager.DeleteDisease(diseaseId));
            }
            catch (ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
        }

        // PUT: api/diseases/5
        [HttpPut("{diseaseId}")]
        public IActionResult UpdateAuthor(int diseaseId, [FromBody]DiseaseRequest disease)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid disease input");
            }

            try
            {
                return Ok(this.diseaseManager.UpdateDisease(diseaseId, Mapper.Map<Disease>(disease)));
            }
            catch (ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}