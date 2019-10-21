using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppInfrastructure.Contracts
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Appointment> Appointmentss { get; set; }

    }
}
