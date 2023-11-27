using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practise102.Data;
using Practise102.Api.Services.UserService;
using Practise102.Data.Entities;

namespace Practise102.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly DataContext _dataContext;

        public UserController(IUserService userService, DataContext dataContext)
        {
            _userService = userService;
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserEntity>>> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntity>> GetSingleUser(int id)
        {
            var result = _userService.GetSingleUser(id);
            if (result is null)
            {
                return NotFound("Sorry, but this user doesn't exist.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<UserEntity>>> AddUser([FromBody]UserEntity user)
        {
            var result = _userService.AddUser(user);
            if (result is null)
            {
                return NotFound("Sorry, but this user doesn't exist.");
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<UserEntity>>> UpdateUser(int id, UserEntity request)
        {
            var result = _userService.UpdateUser(id, request);
            if (result is null)
            {
                return NotFound("Sorry, but this user doesn't exist.");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserEntity>>> DeleteUser(int id)
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
