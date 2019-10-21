using AppInfrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInfrastructure.Contracts
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAppointmentsByPatient(int patientId);
        Task<Appointment> AddAppointment(NewAppointment appointment);
        Task<Appointment> DeleteAppointment(int appointmentId);
    }
}
