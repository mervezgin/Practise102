using Microsoft.AspNetCore.Mvc;

namespace Practise102.Api.Services.UserService
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>
        {
            new User{Id = 1, Name = "Merve", LastName = "Azgın", Place = "Ankara"},
            new User{Id = 2, Name = "Yiğit", LastName = "Adaş", Place = "Ankara"}
        };

        public List<User>? GetAllUsers()
        {
            return users;
        }

        public User? GetSingleUser(int id)
        {
            var singleUser = users.Find(x => x.Id == id);

            if (singleUser is null)
            {
                return null;
            }

            return singleUser;
        }

        public List<User>? AddUser([FromBody] User user)
        {
            users.Add(user);

            return users;
        }

        public List<User>? UpdateUser(int id, User request)
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

        public List<User>? DeleteUser(int id)
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
