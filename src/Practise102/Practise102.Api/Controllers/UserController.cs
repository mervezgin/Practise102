using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practise102.Api.Models;
using System.Runtime.CompilerServices;

namespace Practise102.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User> 
        {
            new User{Id = 1, Name = "Merve", LastName = "Azgın", Place = "Ankara"},
            new User{Id = 2, Name = "Yiğit", LastName = "Adaş", Place = "Ankara"}
        };
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleUser(int id)
        {
            var singleUser = users.Find(x => x.Id == id);
            if(singleUser is null)
            {
                return NotFound("Sorry, but this user doesn't exist.");
            }
            return Ok(singleUser);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]User user)
        {
            users.Add(user);
            return Ok(users);
        }
    }
}
