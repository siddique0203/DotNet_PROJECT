using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService service;
        public ReportController(ReportService service)
        {
            this.service = service;
        }

        [HttpGet("bookings-per-month")]
        public IActionResult BookingsPerMonth()
            => Ok(service.TotalBookingsPerMonth());

        [HttpGet("total-revenue")]
        public IActionResult TotalRevenue()
            => Ok(service.TotalRevenue());

        [HttpGet("monthly-revenue")]
        public IActionResult MonthlyRevenue()
            => Ok(service.MonthlyRevenue());

        [HttpGet("daily-income")]
        public IActionResult DailyIncome()
            => Ok(service.DailyIncome());

        [HttpGet("most-booked-route")]
        public IActionResult MostBookedRoute()
            => Ok(service.MostBookedRoute());

        [HttpGet("agency-ratings")]
        public IActionResult AgencyRatings()
        {
            return Ok(service.AgencyRatings());
        }
    }
}
