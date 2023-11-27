using Microsoft.AspNetCore.Mvc;
using Practise102.Data.Entities;

namespace Practise102.Api.Services.UserService
{
    public class UserService : IUserService
    {
        /*
        private static List<UserEntity> users = new List<UserEntity>
        {
            new UserEntity{Id = 1, Name = "Merve", LastName = "Azgın", Place = "Ankara"},
            new UserEntity{Id = 2, Name = "Yiğit", LastName = "Adaş", Place = "Ankara"}
        };
        */
        private readonly DataContext _dContext;

        public UserService(DataContext dContext)
        {
            _dContext = dContext;
        }

        public async Task<List<UserEntity>?> GetAllUsersAsync()
        {
            var usersAll = await _dContext.Users.ToListAsync();
            return usersAll;
        }

        public async Task<UserEntity?> GetSingleUser(int id)
        {
            var singleUser = await _dContext.Users.FindAsync(id);

            if (singleUser is null)
            {
                return null;
            }

            return singleUser;
        }

        public async Task<List<UserEntity>?> AddUser([FromBody] UserEntity user)
        {
            _dContext.Users.Add(user);
            await _dContext.SaveChangesAsync();

            return await _dContext.Users.ToListAsync();
        }

        public async Task<List<UserEntity>?> UpdateUser(int id, UserEntity request)
        {
            var user = await _dContext.Users.FindAsync(id);
            if (user is null)
            {
                return null;
            }

            user.Name = request.Name;
            user.LastName = request.LastName;
            user.Place = request.Place;

            await _dContext.SaveChangesAsync();

            return await _dContext.Users.ToListAsync();
        }

        public async Task<List<UserEntity>?> DeleteUser(int id)
        {
            var user = await _dContext.Users.FindAsync(id);
            if (user is null)
            {
                return null;
            }

            _dContext.Users.Remove(user);
            await _dContext.SaveChangesAsync();

            return await _dContext.Users.ToListAsync();
        }
    }
}
