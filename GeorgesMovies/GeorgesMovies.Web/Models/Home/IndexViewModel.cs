using GeorgesMovies.Services.Movies;
using System.Collections.Generic;

namespace GeorgesMovies.Web.Models.Home
{
    public class IndexViewModel
    {
        public List<IndexMovieViewModel> Movies { get; set; }
    }
}
