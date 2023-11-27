using Microsoft.AspNetCore.Mvc;
using Practise102.Data.Entities;

namespace Practise102.Api.Services.UserService
{
    public class UserService : IUserService
    {
        private static List<UserEntity> users = new List<UserEntity>
        {
            new UserEntity{Id = 1, Name = "Merve", LastName = "Azgın", Place = "Ankara"},
            new UserEntity{Id = 2, Name = "Yiğit", LastName = "Adaş", Place = "Ankara"}
        };

        public List<UserEntity>? GetAllUsers()
        {
            return users;
        }

        public UserEntity? GetSingleUser(int id)
        {
            var singleUser = users.Find(x => x.Id == id);

            if (singleUser is null)
            {
                return null;
            }

            return singleUser;
        }

        public List<UserEntity>? AddUser([FromBody] UserEntity user)
        {
            users.Add(user);

            return users;
        }

        public List<UserEntity>? UpdateUser(int id, UserEntity request)
        {
            var user = users.Find(x => x.Id == id);
            if (user is null)
            {
                return null;
            }

            user.Name = request.Name;
            user.LastName = request.LastName;
            user.Place = request.Place;

            return users;
        }

        public List<UserEntity>? DeleteUser(int id)
        {
            var user = users.Find(x => x.Id == id);
            if (user is null)
            {
                return null;
            }

            users.Remove(user);

            return users;
        }
    }
}
