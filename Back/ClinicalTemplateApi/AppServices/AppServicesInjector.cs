using AppDataModel.Repositories;
using AppInfrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class AppServicesInjector
    {
        public void RegisterComponents(IDependencyFactory dependencyFactory)
        {
            dependencyFactory.RegisterType<IPatientRepository, PatientRepository>();
            dependencyFactory.RegisterType<IAppointmentRepository, AppointmentRepository>();
            dependencyFactory.RegisterType<IPatientService, PatientService>();
            dependencyFactory.RegisterType<IAppointmentService, AppointmentService>();
        }
    }
}
