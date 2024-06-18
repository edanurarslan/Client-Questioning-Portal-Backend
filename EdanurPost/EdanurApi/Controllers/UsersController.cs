using Abstract.Services;
using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EdanurApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UsersController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _userService.GetAll();
            return Ok(data);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UserDto userDto)
        {
            if (userDto == null )
            {
                return BadRequest();
            }

            var existingUser = _userService.GetByID(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            User user = new User() { Id = id, Name = userDto.Name, Email = userDto.Email, Job = userDto.Job };
            _userService.Update(user);

            return NoContent();
        }
    }
}
