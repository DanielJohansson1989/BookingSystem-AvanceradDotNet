﻿using AutoMapper;
using BookingsystemAPI.Data;
using BookingsystemAPI.DTOs;
using BookingsystemModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<ICollection<Customer>> GetAll(string sortBy = "CustomerId", string filterByFirstName = null, string filterByLastName = null, string filterByEmail = null, string filterByPhone = null)
        {
            IQueryable<Customer> query = _dbContext.Customer;

            switch (sortBy.ToLower())
            {
                case "firstname":
                    query = query.OrderBy(c => c.FirstName);
                    break;
                case "lastname":
                    query = query.OrderBy(c => c.LastName);
                    break;
                default:
                    query = query.OrderBy(c => c.CustomerId);
                    break;
            }

            if (!string.IsNullOrEmpty(filterByFirstName))
            {
                query = query.Where(c => c.FirstName.Contains(filterByFirstName));
            }
            if (!string.IsNullOrEmpty(filterByLastName))
            {
                query = query.Where(c => c.LastName.Contains(filterByLastName));
            }
            if (!string.IsNullOrEmpty(filterByEmail))
            {
                query = query.Where(c => c.EmailAddress.Contains(filterByEmail));
            }
            if (!string.IsNullOrEmpty(filterByPhone))
            {
                query = query.Where(c => c.PhoneNumber.Contains(filterByPhone));
            }
            
            var result = await query.ToListAsync();
            if (!result.IsNullOrEmpty())
            {
                return result;
            }
            return null;
        }

        public async Task<Customer> GetById(int id)
        {
            return await _dbContext.Customer.Include(c => c.Appointment.OrderBy(a => a.AppointmentStart)).FirstOrDefaultAsync(c => c.CustomerId == id);
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

        public async Task<ICollection<Customer>> GetCustomersByDate(DateTime start, DateTime end, string sortBy)
        {
            IQueryable<Customer> result = _dbContext.Appointment
                .Where(a => a.AppointmentStart >= start && a.AppointmentEnd <= end)
                .Select(a => a.Customer).Distinct();

            switch (sortBy.ToLower())
            {
                case "firstname":
                    result = result.OrderBy(x => x.FirstName);
                    break;
                case "lastname":
                    result = result.OrderBy(x => x.LastName);
                    break;
                default:
                    result = result.OrderBy(x => x.CustomerId);
                    break;
            }
            return await result.ToListAsync();
        }
    }
}
