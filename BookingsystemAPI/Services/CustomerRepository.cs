using AutoMapper;
using BookingsystemAPI.Data;
using BookingsystemAPI.DTOs;
using BookingsystemModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookingsystemAPI.Services
{
    public class CustomerRepository : IBookingsystem<Customer>
    {
        private readonly BookingsystemDbContext _dbContext;
        
        public CustomerRepository(BookingsystemDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> Add(Customer entity)
        {
            if (entity != null)
            {
                await _dbContext.Customer.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<Customer> Delete(int id)
        {
            var result = await _dbContext.Customer.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (result != null)
            {
                _dbContext.Customer.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<ICollection<Customer>> GetAll()
        {
            return await _dbContext.Customer.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _dbContext.Customer.Include(c => c.Appointment).FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task<Customer> Update(Customer entity)
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
        }
    }
}
