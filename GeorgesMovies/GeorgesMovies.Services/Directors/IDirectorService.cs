using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Directors.DTO;

namespace GeorgesMovies.Services.Directors
{
    public interface IDirectorService
    {
        DirectorFullName GetMovieDirector(Movie currMovie);
    }
}
