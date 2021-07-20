using GeorgesMovies.Services.Genres;
using GeorgesMovies.Services.Movies;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeorgesMovies.Web.Models.Movies
{
    public class AllMoviesViewModel
    {
        public const int MoviesPerPage = 3;

        [Display(Name = "Search")]
        public string SearchItem { get; set; }
        public IEnumerable<GenreServiceFormModel> Genres { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int GenreId { get; set; }
        public IEnumerable<MovieServiceModel> Movies { get; set; }
        public int TotalMovies { get; set; }
    }
}
