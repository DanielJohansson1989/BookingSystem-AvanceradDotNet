

using BookingsystemAPI.DTOs;
using BookingsystemModels;

namespace BookingsystemAPI.Services
{
    public interface IAppointment
    {
        Task<ICollection<AppointmentDTO>> GetByCompanyAndDate(int companyId, DateTime startDate, DateTime endDate, string sortBy);
        Task<AppointmentDTO> GetById(int id);
        Task<AppointmentDTO> Add(AppointmentCreateDTO entity);
        Task<AppointmentDTO> Update(AppointmentDTO entity);
        Task<AppointmentDTO> Delete(int id);
        Task<ICollection<AppointmentDTO>> GetHours(DateTime start, DateTime end, int customerId);
    }
}
