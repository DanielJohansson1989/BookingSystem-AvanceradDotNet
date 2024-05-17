namespace BookingsystemAPI.DTOs
{
    public class AppointmentCreateDTO
    {
        public DateTime AppointmentStart { get; set; }
        public DateTime AppointmentEnd { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
    }
}
