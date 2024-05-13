using BookingsystemAPI.Data;
using BookingsystemModels;
using Microsoft.EntityFrameworkCore;

namespace BookingsystemAPI.Services
{
    public class AppointmentRepository : IAppointment<Appointment>
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
                var createdEntity = await _dbContext.Appointment.AddAsync(entity);
                //await _dbContext.SaveChangesAsync();
                
                await _dbContext.History.AddAsync(new History
                {
                    ChangeType = "Create",
                    ChangeTime = DateTime.Now,
                    AppointmentId = createdEntity.Entity.AppointmentId,
                    NewValueAppointmentStart = createdEntity.Entity.AppointmentStart,
                    NewValueAppointmentEnd = createdEntity.Entity.AppointmentEnd,
                    NewValueCustomerId = createdEntity.Entity.CustomerId,
                    NewValueCompanyId = createdEntity.Entity.CompanyId
                });
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
                await _dbContext.History.AddAsync(new History
                {
                    ChangeType = "Delete",
                    ChangeTime = DateTime.Now,
                    AppointmentId = result.AppointmentId,
                    OldValueAppointmentStart = result.AppointmentStart,
                    OldValueAppointmentEnd = result.AppointmentEnd,
                    OldValueCustomerId = result.CustomerId,
                    OldValueCompanyId = result.CompanyId
                });
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<ICollection<Appointment>> GetByCompanyAndDate(int companyId, DateTime startDate, DateTime endDate)
        {
            return await _dbContext.Appointment
                .Where(a => a.CompanyId == companyId && a.AppointmentStart >= startDate && a.AppointmentEnd <= endDate)
                .ToListAsync();
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
                await _dbContext.History.AddAsync(new History
                {
                    ChangeType = "Update",
                    ChangeTime = DateTime.Now,
                    AppointmentId = appointmentToUpdate.AppointmentId,
                    OldValueAppointmentStart = appointmentToUpdate.AppointmentStart,
                    OldValueAppointmentEnd = appointmentToUpdate.AppointmentEnd,
                    OldValueCustomerId = appointmentToUpdate.CustomerId,
                    OldValueCompanyId = appointmentToUpdate.CompanyId,
                    NewValueAppointmentStart = entity.AppointmentStart,
                    NewValueAppointmentEnd = entity.AppointmentEnd,
                    NewValueCustomerId = entity.CustomerId,
                    NewValueCompanyId = entity.CompanyId
                });
                appointmentToUpdate.AppointmentStart = entity.AppointmentStart;
                appointmentToUpdate.AppointmentEnd = entity.AppointmentEnd;
                appointmentToUpdate.CustomerId = entity.CustomerId;
                appointmentToUpdate.CompanyId = entity.CompanyId;

                await _dbContext.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<ICollection<Appointment>> GetHours(DateTime start, DateTime end, int customerId)
        {
            var result = await _dbContext.Appointment
                .Where(a => a.AppointmentStart >= start && a.AppointmentEnd <= end && a.CustomerId == customerId)
                .ToListAsync();

            /*double hours = 0;
            foreach (var item in result)
            {
                TimeSpan timeDifference = item.AppointmentEnd - item.AppointmentStart;
                hours += timeDifference.TotalHours;                
            }
            return hours;*/
            return result;
        }
    }
}
