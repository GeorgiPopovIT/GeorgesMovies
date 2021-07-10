using GeorgesMovies.Data;
using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Interfaces;
using System.Linq;

namespace GeorgesMovies.Services
{
    public class UserService : IUserService
    {
        private readonly GeorgesMoviesDbContext context;
        public UserService(GeorgesMoviesDbContext context)
        {
            this.context = context;
        }

        public User GetUserById(int id)
        {
            var user = this.context.Users
                .FirstOrDefault(u => u.Id == id);

            return user;
        }

        public void DeleteUser(int id)
        {
            var user = this.context.Users
                .FirstOrDefault(u => u.Id == id);

            this.context.Users.Remove(user);

            this.context.SaveChanges();
        }
    }
}
