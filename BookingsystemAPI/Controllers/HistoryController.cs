using BookingsystemAPI.Services;
using BookingsystemModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingsystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistory<History> _bookingsystem;
        public HistoryController(IHistory<History> bookingsystem)
        {
            _bookingsystem = bookingsystem;
        }
        [HttpGet("{appointmentId:int}")]
        public async Task<IActionResult> GetHistory(int appointmentId)
        {
            try
            {
                var result = await _bookingsystem.GetAsync(appointmentId);
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
    }
}
