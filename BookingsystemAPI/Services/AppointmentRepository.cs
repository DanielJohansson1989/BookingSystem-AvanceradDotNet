using AutoMapper;
using BookingsystemAPI.Data;
using BookingsystemAPI.DTOs;
using BookingsystemModels;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace BookingsystemAPI.Services
{
    public class AppointmentRepository : IAppointment
    {
        private readonly BookingsystemDbContext _dbContext;
        private readonly IMapper _mapper;
        public AppointmentRepository(BookingsystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<AppointmentDTO> Add(AppointmentCreateDTO entity)
        {
            if (entity != null)
            {
                var appointment = _mapper.Map<Appointment>(entity);
                var createdEntity = await _dbContext.Appointment.AddAsync(appointment);
                await _dbContext.SaveChangesAsync();
                
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
                return _mapper.Map<AppointmentDTO>(createdEntity.Entity);
            }
            return null;
        }

        public async Task<AppointmentDTO> Delete(int id)
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
                return _mapper.Map<AppointmentDTO>(result);
            }
            return null;
        }

        public async Task<ICollection<AppointmentDTO>> GetByCompanyAndDate(int companyId, DateTime startDate, DateTime endDate, string sortBy = "startDate")
        {
            IQueryable<Appointment> query = _dbContext.Appointment
                .Where(a => a.CompanyId == companyId && a.AppointmentStart >= startDate && a.AppointmentEnd <= endDate);

            switch (sortBy.ToLower())
            {
                case "customerid":
                    query = query.OrderBy(a => a.CustomerId);
                    break;
                default:
                    query = query.OrderBy(a => a.AppointmentStart); 
                    break;
            }
            var result = await query.ToListAsync();
            if (result == null) return null;
            return _mapper.Map<ICollection<AppointmentDTO>>(result);
        }

        public async Task<AppointmentDTO> GetById(int id)
        {
            return _mapper.Map<AppointmentDTO>(await _dbContext.Appointment.Include(a => a.Customer).FirstOrDefaultAsync(a => a.AppointmentId == id));
        }

        public async Task<AppointmentDTO> Update(AppointmentDTO entityDTO)
        {
            Appointment entity = _mapper.Map<Appointment>(entityDTO);
            var appointmentToUpdate = await _dbContext.Appointment.FirstOrDefaultAsync(a => a.AppointmentId == entityDTO.AppointmentId);
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
                return entityDTO;
            }
            return null;
        }

        public async Task<ICollection<AppointmentDTO>> GetHours(DateTime start, DateTime end, int customerId)
        {
            var result = await _dbContext.Appointment
                .Where(a => a.AppointmentStart >= start && a.AppointmentEnd <= end && a.CustomerId == customerId)
                .OrderBy(a => a.AppointmentStart)
                .ToListAsync();

            /*double hours = 0;
            foreach (var item in result)
            {
                TimeSpan timeDifference = item.AppointmentEnd - item.AppointmentStart;
                hours += timeDifference.TotalHours;                
            }
            return hours;*/
            return _mapper.Map<ICollection<AppointmentDTO>>(result);
        }
    }
}
