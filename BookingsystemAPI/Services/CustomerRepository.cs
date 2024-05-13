using AutoMapper;
using BookingsystemAPI.Data;
using BookingsystemAPI.DTOs;
using BookingsystemModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookingsystemAPI.Services
{
    public class CustomerRepository : ICustomer<Customer>
    {
        private readonly BookingsystemDbContext _dbContext;
        private readonly IMapper _mapper;
        public CustomerRepository(BookingsystemDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /*public async Task<Customer> Add(Customer entity)
        {
            if (entity != null)
            {
                await _dbContext.Customer.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            return null;
        }*/

        /*public async Task<Customer> Delete(int id)
        {
            var result = await _dbContext.Customer.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (result != null)
            {
                _dbContext.Customer.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }*/

        public async Task<ICollection<Customer>> GetAll()
        {
            return await _dbContext.Customer.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _dbContext.Customer.Include(c => c.Appointment).FirstOrDefaultAsync(c => c.CustomerId == id);
        }

       /* public async Task<Customer> Update(Customer entity)
        {
            var customerToUpdate = await _dbContext.Customer.FirstOrDefaultAsync(c => c.CustomerId == entity.CustomerId);
            if (customerToUpdate != null)
            {
                customerToUpdate.FirstName = entity.FirstName;
                customerToUpdate.LastName = entity.LastName;
                customerToUpdate.EmailAddress = entity.EmailAddress;
                customerToUpdate.PhoneNumber = entity.PhoneNumber;
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            return null;
        }*/

        public async Task<ICollection<Customer>> GetCustomersByDate(DateTime start, DateTime end)
        {
            var result = await _dbContext.Appointment
                .Where(a => a.AppointmentStart >= start && a.AppointmentEnd <= end)
                .Select(a => a.Customer).Distinct().ToListAsync();

            return result;
        }
    }
}
