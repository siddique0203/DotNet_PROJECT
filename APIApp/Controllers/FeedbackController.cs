using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        FeedbackService feedbackService;

        public FeedbackController(FeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        [HttpGet("all")]
        public ActionResult<List<FeedbackDTO>> Get()
        {
            return Ok(feedbackService.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<FeedbackDTO> Get(int id)
        {
            var data = feedbackService.Get(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost("create")]
        public ActionResult Create(FeedbackDTO feedback)
        {
            var result = feedbackService.Create(feedback);
            if (result) return Ok("Feedback added");
            return BadRequest("Failed");
        }

        [HttpPut("update")]
        public ActionResult Update(FeedbackDTO feedback)
        {
            var result = feedbackService.Update(feedback);
            if (result) return Ok("Feedback updated");
            return BadRequest("Update failed");
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var result = feedbackService.Delete(id);
            if (result) return Ok("Feedback deleted");
            return NotFound();
        }
    }
}
