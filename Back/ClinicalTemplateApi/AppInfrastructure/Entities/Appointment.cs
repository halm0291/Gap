using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppInfrastructure.Contracts
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public AppointmentType Type { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan Hour { get; set; }

    }
}
