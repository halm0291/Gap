using AppInfrastructure.Contracts;
using AppInfrastructure.DTO;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace ClinicalTemplateApi.Controllers
{
    public class PatientController : ApiController
    {
        private readonly IPatientService _patientService;
        public PatientController()
        {

        }
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllPatients")]
        public async Task<IHttpActionResult> GetAllPatients()
        {
            try
            {
                var employees = await _patientService.GetPatients();
                if (employees != null)
                    return Ok(employees);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Unexpected error");
            }
        }

        [Authorize]
        [HttpPost]
        [Route("AddPatient")]
        public async Task<IHttpActionResult> AddApointment([FromBody] NewPatient patient)
        {
            try
            {
                var successAdded = await _patientService.AddPatient(patient);
                if (successAdded)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Unexpected error");
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("DeletePatient/Id/{patientId}")]
        public async Task<IHttpActionResult> AddApointment(int patientId)
        {
            try
            {
                var successDeleted = await _patientService.DeletePatient(patientId);
                if (successDeleted)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Unexpected error");
            }
        }
    }
}
