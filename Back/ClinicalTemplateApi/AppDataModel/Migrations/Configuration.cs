namespace AppDataModel.Migrations
{
    using AppInfrastructure.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDataModel.ClinicalTemplateContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppDataModel.ClinicalTemplateContext context)
        {

            var patient1 = new Patient() { Name = "Andres", LastName = "Johnson" };
            var patient2 = new Patient() { Name = "Andrea", LastName = "Williams" };
            var patient3 = new Patient() { Name = "Alejandro", LastName = "Jones" };

            context.Patients.AddRange(new List<Patient> { patient1, patient2 , patient3 });
            context.SaveChanges();

            List<Appointment> defaultAppointments = new List<Appointment>();
            defaultAppointments.Add(new Appointment() { Date = DateTime.Now.AddDays(2) , Hour = new TimeSpan(14,0,0), Type = AppointmentType.GeneralMedicine ,PatientId = patient1.Id});
            defaultAppointments.Add(new Appointment() { Date = DateTime.Now.AddDays(7), Hour = new TimeSpan(16, 0, 0), Type = AppointmentType.Neurology, PatientId = patient2.Id });
            defaultAppointments.Add(new Appointment() { Date = DateTime.Now.AddDays(23), Hour = new TimeSpan(18, 0, 0), Type = AppointmentType.Odontology, PatientId = patient3.Id });

            context.Appointments.AddRange(defaultAppointments);

            base.Seed(context);
        }
    }
}
