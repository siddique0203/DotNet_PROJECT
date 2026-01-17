using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("all")]
        public ActionResult<List<UserDTO>> Get()
        {
            return Ok(userService.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            var data = userService.Get(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost("create")]
        public ActionResult Create(UserDTO user)
        {
            var result = userService.Create(user);
            if (result) 
            { 
                return Ok("User created"); 
            }
            return BadRequest("User creation failed");
        }

        [HttpPut("update")]
        public ActionResult Update(UserDTO user)
        {
            var result = userService.Update(user);
            if (result) return Ok("User updated");
            return BadRequest("Update failed");
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var result = userService.Delete(id);
            if (result) return Ok("User deleted");
            return NotFound();
        }
    }
}
