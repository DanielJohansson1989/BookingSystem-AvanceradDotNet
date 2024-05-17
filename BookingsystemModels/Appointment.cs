using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingsystemModels
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        //[StringLength(450)]
        //public string? OwnerId { get; set; } // ForeignKey from AspNetUser table
        [Required]
        public DateTime AppointmentStart { get; set; }
        [Required]
        public DateTime AppointmentEnd { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public Customer Customer { get; set; }
        public Company Company { get; set; }
    }
}
