using GeorgesMovies.Services.Movies.DTO;
using System.Collections.Generic;
using System.Linq;

namespace GeorgesMovies.Services.Movies
{
    public interface IMovieService
    {
        MoviesQueryServiceModel All(
            string searchItem,
            int currentPage,
            int moviesPerPage,
            int genreId);

        void Add(MovieServiceFormModel movie);

        ManageServiceViewModel Manage();

        DetailsServiceViewModel Details(int id);

        void Delete(int id);

        bool Edit(int id, MovieServiceFormModel model);

        MovieServiceFormModel GetMovieById(int id);

        IQueryable<AllMovieServiceModel> GetMoviesListing();

        IEnumerable<ManageServiceViewModel> ManageListing();

        bool IsMovieExist(MovieServiceFormModel movie);

    }
}
