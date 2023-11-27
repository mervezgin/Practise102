using Microsoft.AspNetCore.Mvc;
using Practise102.Data.Entities;

namespace Practise102.Api.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserEntity>?> GetAllUsersAsync();
        Task<UserEntity?> GetSingleUser(int id);
        Task<List<UserEntity>?> AddUser([FromBody] UserEntity user);
        Task<List<UserEntity>?> UpdateUser(int id, UserEntity request);
        Task<List<UserEntity>?> DeleteUser(int id); 


    }
}
