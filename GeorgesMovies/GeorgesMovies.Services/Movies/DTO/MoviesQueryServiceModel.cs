using GeorgesMovies.Services.Genres.DTO;
using System.Collections.Generic;

namespace GeorgesMovies.Services.Movies.DTO
{
    public class MoviesQueryServiceModel
    {
        public int MoviesPerPage { get; set; }
        public IEnumerable<GenreServiceFormModel> Genres { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<AllMovieServiceModel> Movies { get; set; }
        public int TotalMovies { get; set; }
    }
}
