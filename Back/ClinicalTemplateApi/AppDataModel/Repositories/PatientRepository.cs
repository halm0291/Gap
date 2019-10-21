using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AppInfrastructure.Contracts;
using AppInfrastructure.DTO;

namespace AppDataModel.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        public async Task<bool> AddPatient(NewPatient newPatient)
        {
            using (var context = new ClinicalTemplateContext())
            {
                var patient = new Patient() { Name = newPatient.Name, LastName = newPatient.LastName };
                context.Patients.Add(patient);
                context.SaveChanges();
            }
            return true;
        }
        public async Task<bool> UpdatePatient(Patient patient)
        {
            using (var context = new ClinicalTemplateContext())
            {
                context.Patients.Attach(patient);
                context.Entry(patient).State = EntityState.Modified;
                context.SaveChanges();
            }
            return true;
        }

        public async Task<bool> DeletePatient(int patientId)
        {
            using (var context = new ClinicalTemplateContext())
            {
                Patient patient = new Patient() { Id = patientId };
                context.Patients.Attach(patient);
                context.Entry(patient).State = EntityState.Deleted;
                context.SaveChanges();
            }
            return true;
        }

        public async Task<List<Patient>> GetPatients()
        {
            using (var context = new ClinicalTemplateContext())
            {
                return await context.Patients.ToListAsync();
            }
        }
    }
}
