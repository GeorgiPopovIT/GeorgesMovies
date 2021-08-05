using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Directors.DTO;

namespace GeorgesMovies.Services.Directors
{
    public interface IDirectorService
    {
        Director CreateDirector(string firstName, string lastName);

        DirectorFullName GetMovieDirector(Movie currMovie);
    }
}
