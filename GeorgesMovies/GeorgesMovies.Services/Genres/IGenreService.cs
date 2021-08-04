using GeorgesMovies.Services.Genres.DTO;
using System.Collections.Generic;

namespace GeorgesMovies.Services.Genres
{
    public interface IGenreService
    {
        IEnumerable<GenreServiceFormModel> GetGenres();
    }
}
