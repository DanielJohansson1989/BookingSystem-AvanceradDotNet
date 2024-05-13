using BookingsystemModels;
using System.ComponentModel.DataAnnotations;

namespace BookingsystemAPI.DTOs
{
    public class AppointmentDTO
    {
        [Required]
        public DateTime AppointmentStart { get; set; }
        [Required]
        public DateTime AppointmentEnd { get; set; }
        //public int CustomerId { get; set; }
        //public int CompanyId { get; set; }
        //public Customer Customer { get; set; }
        //public Company Company { get; set; }
    }
}
