using BookingsystemAPI.Services;
using BookingsystemModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingsystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IBookingsystem<Appointment> _bookingsystem;
        public AppointmentController(IBookingsystem<Appointment> bookingsystem)
        {
            _bookingsystem = bookingsystem;
        }

        [HttpGet]
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

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Appointment>> UpdateAppointment(int id, Appointment appointment)
        {
            try
            {
                if (id != appointment.AppointmentId)
                {
                    return BadRequest();
                }
                var appointmentToUpdate = _bookingsystem.GetById(id);
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
