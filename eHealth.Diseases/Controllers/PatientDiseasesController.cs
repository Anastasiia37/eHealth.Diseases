using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eHealth.Diseases.BusinessLogic.Contracts.Service;
using eHealth.Diseases.BusinessLogic.Models;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;
using eHealth.Diseases.Models;

namespace eHealth.Diseases.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDiseasesController : ControllerBase
    {
        private IPatientDiseaseManager patientDiseaseManager;

        public PatientDiseasesController(IPatientDiseaseManager patientDiseaseManager)
        {
            this.patientDiseaseManager = patientDiseaseManager;
        }

        [HttpGet("names/{patientId}")]
        // GET: api/patientdiseases/names/5
        public IActionResult GetDiseaseNames(int patientId)
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
                return NotFound(exception.Message);
            }
        }

        [HttpGet("patientId={patientId}")]
        // GET: api/patientdiseases/patientid=5
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
                return NotFound(exception.Message);
            }
        }

        [HttpGet("patientDiseaseId={patientDiseaseId}")]
        // GET: api/patientdiseases/names/5
        public IActionResult GetPatientDisease(int patientDiseaseId)
        {
            try
            {
                return Ok(this.patientDiseaseManager.GetPatientDisease(patientDiseaseId));
            }
            catch (ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost]
        // POST: api/patientdiseases
        public IActionResult AddDiseaseToPatient([FromBody]PatientDiseaseRequest patientDiseaseView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request");
            }

            try
            {
                int newPatientDiseaseId = this.patientDiseaseManager.AddDiseaseToPatient(
                    Mapper.Map<PatientDisease>(patientDiseaseView));
                return Created("patientdiseases/", newPatientDiseaseId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{patientDiseaseId}")]
        // DELETE: api/patientdiseases/5
        public IActionResult DeleteDiseaseFromPatient(int patientDiseaseId)
        {
            try
            {
                return Ok(this.patientDiseaseManager.DeleteDiseaseFromPatient(patientDiseaseId));
            }
            catch (ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}