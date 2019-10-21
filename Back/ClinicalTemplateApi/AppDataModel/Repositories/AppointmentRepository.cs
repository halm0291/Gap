using AppInfrastructure.Contracts;
using AppInfrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDataModel.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public async Task<Appointment> AddAppointment(NewAppointment newAppointment)
        {
            using (var context = new ClinicalTemplateContext())
            {
                var appointment = new Appointment() { Type = newAppointment.Type, PatientId = newAppointment.PatientId, Date = newAppointment.Date, Hour = newAppointment.Hour };
                context.Appointments.Add(appointment);
                context.SaveChanges();
                return appointment;
            }
           
        }

        public async Task<Appointment> DeleteAppointment(int appointmentId)
        {
            using (var context = new ClinicalTemplateContext())
            {
                //Appointment appointment = new Appointment() { Id = appointmentId };
                var appointment = context.Appointments.Where(x => x.Id == appointmentId).FirstOrDefault();
                context.Appointments.Attach(appointment);
                var appointmentTime = new DateTime(appointment.Date.Year,
                                    appointment.Date.Month,
                                    appointment.Date.Day,
                                    appointment.Hour.Hours,
                                    appointment.Hour.Minutes,
                                    appointment.Hour.Seconds);
                var nextDay = DateTime.Now.AddDays(1);
                var diff = (nextDay - appointmentTime).TotalHours;
                if (diff < 24) return null;

                context.Entry(appointment).State = EntityState.Deleted;
                context.SaveChanges();
                return appointment;
            }
        }

        public async Task<List<Appointment>> GetAppointmentsByPatient(int patientId)
        {
            using (var context = new ClinicalTemplateContext())
            {
                return context.Appointments.Where(x => x.PatientId == patientId).ToList();
            }
        }
    }
}
