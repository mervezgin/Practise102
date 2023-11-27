using Microsoft.AspNetCore.Mvc;

namespace Practise102.Api.Services.UserService
{
    public interface IUserService
    {
        List<User>? GetAllUsers();
        User? GetSingleUser(int id);
        List<User>? AddUser([FromBody] User user);
        List<User>? UpdateUser(int id, User request);
        List<User>? DeleteUser(int id); 


    }
}
