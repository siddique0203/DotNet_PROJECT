using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        PaymentService paymentService;

        public PaymentController(PaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        // GET: api/payment/all
        [HttpGet("all")]
        public ActionResult<List<PaymentDTO>> Get()
        {
            return Ok(paymentService.Get());
        }

        // GET: api/payment/5
        [HttpGet("Get/{id}")]
        public ActionResult<PaymentDTO> Get(int id)
        {
            var data = paymentService.Get(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        // GET: api/payment/booking/10
        [HttpGet("GetBooking/{bookingId}")]
        public ActionResult<PaymentDTO> GetByBooking(int bookingId)
        {
            var data = paymentService.GetByBooking(bookingId);
            if (data == null) return NotFound();
            return Ok(data);
        }

        // POST: api/payment/create
        [HttpPost("create")]
        public ActionResult Create(PaymentDTO payment)
        {
            var result = paymentService.Create(payment);
            if (result) return Ok("Payment successful");
            return BadRequest("Payment failed");
        }

        [HttpPut("update")]
        public ActionResult Update(PaymentDTO payment)
        {
            var result = paymentService.Update(payment);
            if (result) return Ok("Payment updated");
            return BadRequest("Update failed");
        }
    }
}
