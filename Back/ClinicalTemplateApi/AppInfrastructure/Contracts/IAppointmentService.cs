using AppInfrastructure.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppInfrastructure.Contracts
{
    public interface IAppointmentService
    {
        Task<Appointment> AddAppointment(NewAppointment newAppointment);
        Task<Appointment> DeleteAppointment(int appointmentId);
        Task<List<Appointment>> GetAppointmentsByPatient(int patientId);
    }
}
