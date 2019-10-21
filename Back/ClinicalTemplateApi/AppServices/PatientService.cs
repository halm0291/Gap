using AppInfrastructure.Contracts;
using AppInfrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<bool> AddPatient(NewPatient patient)
        {
            return await _patientRepository.AddPatient(patient);
        }
        public async Task<bool> UpdatePatient(Patient patient)
        {
            return await _patientRepository.UpdatePatient(patient);
        }
        public async Task<bool> DeletePatient(int patientId)
        {
            return await _patientRepository.DeletePatient(patientId);
        }
        public async Task<List<Patient>> GetPatients()
        {
            return await _patientRepository.GetPatients();
        }
    }
}
