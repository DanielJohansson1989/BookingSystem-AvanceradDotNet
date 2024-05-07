using BookingsystemAPI.Data;
using BookingsystemModels;
using Microsoft.EntityFrameworkCore;

namespace BookingsystemAPI.Services
{
    public class AppointmentRepository : IBookingsystem<Appointment>
    {
        private readonly BookingsystemDbContext _dbContext;
        public AppointmentRepository(BookingsystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Appointment> Add(Appointment entity)
        {
            if (entity != null)
            {
                await _dbContext.Appointment.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<Appointment> Delete(int id)
        {
            var result = await _dbContext.Appointment.FirstOrDefaultAsync(a => a.AppointmentId == id);
            if (result != null)
            {
                _dbContext.Appointment.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<ICollection<Appointment>> GetAll()
        {
            return await _dbContext.Appointment.ToListAsync();
        }

        public async Task<Appointment> GetById(int id)
        {
            return await _dbContext.Appointment.Include(a => a.Customer).FirstOrDefaultAsync(a => a.AppointmentId == id);
        }

        public async Task<Appointment> Update(Appointment entity)
        {
            var appointmentToUpdate = await _dbContext.Appointment.FirstOrDefaultAsync(a => a.AppointmentId == entity.AppointmentId);
            if (appointmentToUpdate != null)
            {
                appointmentToUpdate.AppointmentStart = entity.AppointmentStart;
                appointmentToUpdate.AppointmentEnd = entity.AppointmentEnd;
                appointmentToUpdate.CustomerId = entity.CustomerId;
                appointmentToUpdate.CompanyId = entity.CompanyId;
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            return null;
        }
    }
}
