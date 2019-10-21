using AppInfrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInfrastructure.Contracts
{
    public interface IPatientService
    {
        Task<bool> AddPatient(NewPatient patient);
        Task<bool> UpdatePatient(Patient patient);
        Task<bool> DeletePatient(int patientId);
        Task<List<Patient>> GetPatients();
    }
}
