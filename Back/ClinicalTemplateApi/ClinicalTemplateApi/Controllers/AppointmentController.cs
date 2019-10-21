using AppInfrastructure.Contracts;
using AppInfrastructure.DTO;
using AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ClinicalTemplateApi.Controllers
{
    public class AppointmentController : ApiController
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public AppointmentController()
        {

        }

        [Authorize]
        [HttpGet]
        [Route("GetAppointmentsByPatientId/Id/{patientId}")]
        public async Task<IHttpActionResult> GetAllAppointments(int patientId)
        {
            try
            {
                var appointments = await _appointmentService.GetAppointmentsByPatient(patientId);
                if (appointments != null)
                    return Ok(appointments);
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
        [Route("AddApointment")]
        public async Task<IHttpActionResult> AddApointment([FromBody] NewAppointment appointment)
        {
            try
            {
                var newAppointment = await _appointmentService.AddAppointment(appointment);
                if (newAppointment != null)
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
        [Route("CancelApointment/Id/{appointmentId}")]
        public async Task<IHttpActionResult> AddApointment(int appointmentId)
        {
            try
            {
                var deletedAppointment = await _appointmentService.DeleteAppointment(appointmentId);
                if (deletedAppointment != null)
                    return Ok(deletedAppointment);
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Unexpected error");
            }
        }
    }
}
