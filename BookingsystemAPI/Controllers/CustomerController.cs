﻿using BookingsystemAPI.DTOs;
using BookingsystemAPI.Services;
using BookingsystemModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingsystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer<Customer> _bookingsystem;
        public CustomerController(ICustomer<Customer> bookingsystem)
        {
            _bookingsystem = bookingsystem;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers(string sortBy = "CustomerId")
        {
            try
            {
                return Ok(await _bookingsystem.GetAll(sortBy));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerDTO>> GetSingleCustomer(int id)
        {
            try
            {
                var result = await _bookingsystem.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{startDate:datetime},{endDate:datetime}")]
        public async Task<ActionResult<Customer>> GetCustomersByAppointmentDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _bookingsystem.GetCustomersByDate(startDate, endDate);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /*[HttpPut("{id:int}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, Customer customer)
        {
            try
            {
                if (id != customer.CustomerId)
                {
                    return BadRequest();
                }
                var customerToUpdate = _bookingsystem.GetById(id);
                if (customerToUpdate == null)
                {
                    return NotFound();
                }
                return await _bookingsystem.Update(customer);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }*/

        /*[HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest();
                }
                var createdCustomer = await _bookingsystem.Add(customer);
                return CreatedAtAction(nameof(GetSingleCustomer), new {id = createdCustomer.CustomerId}, createdCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }*/

        /*[HttpDelete("{id:int}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            try
            {
                var customerToDelete = await _bookingsystem.GetById(id);
                if (customerToDelete == null)
                {
                    return NotFound();
                }
                return await _bookingsystem.Delete(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }*/
    }
}
