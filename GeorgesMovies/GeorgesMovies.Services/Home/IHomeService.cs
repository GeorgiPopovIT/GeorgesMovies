using GeorgesMovies.Services.Movies;
using System.Collections.Generic;

namespace GeorgesMovies.Services.Home
{
    public interface IHomeService
    {
        List<IndexMovieViewModel> GetLastThreeMovies();
    }
}
