using Microsoft.AspNetCore.Mvc;
using Practise102.Data.Entities;

namespace Practise102.Api.Services.UserService
{
    public interface IUserService
    {
        List<UserEntity>? GetAllUsers();
        UserEntity? GetSingleUser(int id);
        List<UserEntity>? AddUser([FromBody] UserEntity user);
        List<UserEntity>? UpdateUser(int id, UserEntity request);
        List<UserEntity>? DeleteUser(int id); 


    }
}
