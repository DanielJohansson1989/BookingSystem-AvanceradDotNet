using BookingsystemModels;
using System.ComponentModel.DataAnnotations;

namespace BookingsystemAPI.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number has to be 10 digits")]
        public string? PhoneNumber { get; set; }

        public ICollection<AppointmentDTO> Appointment { get; set; }
        
    }
}
