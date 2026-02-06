using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        BookingService bookingService;

        public BookingController(BookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet("all")]
        public ActionResult<List<BookingDTO>> Get()
        {
            return Ok(bookingService.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<BookingDTO> Get(int id)
        {
            var data = bookingService.Get(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost("create")]
        public ActionResult Create(BookingDTO booking)
        {
            var result = bookingService.Create(booking);
            if (result) return Ok("Booking created");
            return BadRequest("Booking failed");
        }

        [HttpPut("update")]
        public ActionResult Update(BookingDTO booking)
        {
            var result = bookingService.Update(booking);
            if (result) return Ok("Booking updated");
            return BadRequest("Update failed");
        }
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var result = bookingService.Delete(id);
            if (result) return Ok("Booking deleted");
            return NotFound();
        }
    }
}
