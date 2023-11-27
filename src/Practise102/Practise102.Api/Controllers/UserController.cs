using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practise102.Api.Models;
using Practise102.Api.Services.UserService;

namespace Practise102.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingleUser(int id)
        {
            var result = _userService.GetSingleUser(id);
            if (result is null)
            {
                return NotFound("Sorry, but this user doesn't exist.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser([FromBody]User user)
        {
            var result = _userService.AddUser(user);
            if (result is null)
            {
                return NotFound("Sorry, but this user doesn't exist.");
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(int id, User request)
        {
            var result = _userService.UpdateUser(id, request);
            if (result is null)
            {
                return NotFound("Sorry, but this user doesn't exist.");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id);
            if (result is null)
            {
                return NotFound("Sorry, but this user doesn't exist.");
            }

            return Ok(result);
        }
    }
}
