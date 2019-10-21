using AppInfrastructure.Contracts;
using AppInfrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<Appointment> AddAppointment(NewAppointment newAppointment)
        {
            return await _appointmentRepository.AddAppointment(newAppointment);
        }

        public async Task<Appointment> DeleteAppointment(int appointmentId)
        {
            return await _appointmentRepository.DeleteAppointment(appointmentId);
        }

        public async Task<List<Appointment>> GetAppointmentsByPatient(int patientId)
        {
            return await _appointmentRepository.GetAppointmentsByPatient(patientId);
        }
    }
}
