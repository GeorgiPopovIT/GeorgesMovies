using GeorgesMovies.Models.Models;

namespace GeorgesMovies.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        void DeleteUser(int id);
    }
}
