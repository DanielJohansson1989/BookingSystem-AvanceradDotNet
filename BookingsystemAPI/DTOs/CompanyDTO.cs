using BookingsystemModels;
using System.ComponentModel.DataAnnotations;

namespace BookingsystemAPI.DTOs
{
    public class CompanyDTO
    {
        [Required]
        public string CompanyName { get; set; }
        public ICollection<AppointmentDTO> Appointments { get; set; }
    }
}
