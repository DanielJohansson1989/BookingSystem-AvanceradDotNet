using BookingsystemAPI.Services;
using BookingsystemModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BookingsystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointment<Appointment> _bookingsystem;
        public AppointmentController(IAppointment<Appointment> bookingsystem)
        {
            _bookingsystem = bookingsystem;
        }

        /*[HttpGet, Authorize]
        public async Task<IActionResult> GetAllAppointments()
        {
            try
            {
                return Ok(await _bookingsystem.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }*/
        [HttpGet("{companyId:int},{startDate:datetime},{endDate:datetime}")]
        public async Task<IActionResult> GetAppointmentsByCompany(int companyId, DateTime startDate, DateTime endDate, string sortBy = "startdate")
        {
            try
            {
                var result = await _bookingsystem.GetByCompanyAndDate(companyId, startDate, endDate, sortBy);
                if (result.IsNullOrEmpty()) return NotFound();
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Appointment>> GetSingleAppointment(int id)
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

        [HttpGet("{startDate:DateTime},{endDate:DateTime},{customerId:int}")]
        public async Task<IActionResult> GetHours(DateTime startDate, DateTime endDate, int customerId)
        {
            try
            {
                return Ok(await _bookingsystem.GetHours(startDate, endDate, customerId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Appointment>> UpdateAppointment(int id, Appointment appointment)
        {
            try
            {
                if (id != appointment.AppointmentId)
                {
                    return BadRequest();
                }
                var appointmentToUpdate = await _bookingsystem.GetById(id);
                if (appointmentToUpdate == null)
                {
                    return NotFound();
                }
                return await _bookingsystem.Update(appointment);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateAppointment(Appointment appointment)
        {
            try
            {
                if (appointment == null)
                {
                    return BadRequest();
                }
                var createdAppointment = await _bookingsystem.Add(appointment);
                return CreatedAtAction(nameof(GetSingleAppointment), new { id = createdAppointment.AppointmentId }, createdAppointment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Appointment>> DeleteAppointment(int id)
        {
            try
            {
                var appointmentToDelete = await _bookingsystem.GetById(id);
                if (appointmentToDelete == null)
                {
                    return NotFound();
                }
                return await _bookingsystem.Delete(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
