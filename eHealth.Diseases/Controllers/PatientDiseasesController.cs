using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eHealth.Diseases.BusinessLogic.Contracts.Service;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;
using eHealth.Diseases.BusinessLogic.Models;
using eHealth.Diseases.Models;
using Microsoft.AspNetCore.Mvc;

namespace eHealth.Diseases.Controllers
{
    /// <summary>
    /// Controller for dealing with Patient Diseases
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDiseasesController : ControllerBase
    {
        /// <summary>
        /// The interface link for disease category manager
        /// </summary>
        private IPatientDiseaseManager patientDiseaseManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientDiseasesController"/> class
        /// </summary>
        /// <param name="patientDiseaseManager">The patient disease manager</param>
        public PatientDiseasesController(IPatientDiseaseManager patientDiseaseManager)
        {
            this.patientDiseaseManager = patientDiseaseManager;
        }

        /// <summary>
        /// Gets the patient diseases
        /// api/patientdiseases/patientid=5
        /// </summary>
        /// <param name="patientId">The patient identifier</param>
        /// <returns>
        /// Diseases of specified patient
        /// </returns>
        [HttpGet("patientId={patientId}")]
        public IActionResult GetPatientDiseases(int patientId)
        {
            try
            {
                if (this.patientDiseaseManager.GetPatientDiseases(patientId).Any())
                {
                    return Ok(Mapper.Map<IEnumerable<PatientDiseaseView>>
                    (this.patientDiseaseManager.GetPatientDiseases(patientId)));
                }

                return NoContent();
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Gets the patient diseases names
        /// GET: api/patientdiseases/names/5
        /// </summary>
        /// <param name="patientId">The patient identifier</param>
        /// <returns>
        /// Get names of patient diseases
        /// </returns>
        [HttpGet("names/{patientId}")]
        public IActionResult GetPatientDiseasesNames(int patientId)
        {
            try
            {
                if (this.patientDiseaseManager.GetPatientDiseaseNames(patientId).Any())
                {
                    return Ok(Mapper.Map<IEnumerable<PatientDiseaseNamesView>>
                        (this.patientDiseaseManager.GetPatientDiseaseNames(patientId)));
                }

                return NoContent();
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Gets the patient disease
        /// </summary>
        /// <param name="patientDiseaseId">The patient disease identifier</param>
        /// <returns>
        /// Patient disease with specified id
        /// </returns>
        [HttpGet("patientDiseaseId={patientDiseaseId}")]
        public IActionResult GetPatientDisease(int patientDiseaseId)
        {
            try
            {
                return Ok(this.patientDiseaseManager.Get(patientDiseaseId));
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Adds the disease to patient
        /// POST: api/patientdiseases
        /// </summary>
        /// <param name="patientDiseaseView">The patient disease view</param>
        /// <returns>
        /// The id of added new instance
        /// </returns>
        [HttpPost]
        public IActionResult AddDiseaseToPatient([FromBody]AddPatientDiseaseRequest patientDiseaseView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input data");
            }

            try
            {
                int newPatientDiseaseId = this.patientDiseaseManager.Add(
                    Mapper.Map<PatientDisease>(patientDiseaseView));
                return Created("patientdiseases/", newPatientDiseaseId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Updates the patient disease
        /// PUT: api/patientdiseases/5
        /// </summary>
        /// <param name="patientDiseaseId">The patient disease identifier</param>
        /// <param name="patientDisease">The patient disease</param>
        /// <returns>
        /// The id of updated entity
        /// </returns>
        [HttpPut("{patientDiseaseId}")]
        public IActionResult UpdatePatientDisease(int patientDiseaseId, [FromBody]UpdatePatientDiseaseRequest patientDisease)
        {
            try
            {
                return Ok(this.patientDiseaseManager.Update(patientDiseaseId,
                    Mapper.Map<PatientDisease>(patientDisease)));
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Deletes the disease from patient
        /// DELETE: api/patientdiseases/5
        /// </summary>
        /// <param name="patientDiseaseId">The patient disease identifier</param>
        /// <returns>
        /// The id of deleted entity
        /// </returns>
        [HttpDelete("{patientDiseaseId}")]
        public IActionResult DeleteDiseaseFromPatient(int patientDiseaseId)
        {
            try
            {
                return Ok(this.patientDiseaseManager.Delete(patientDiseaseId));
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}