using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeorgesMovies.Web.Models.Movies
{
    public class AllMoviesViewModel
    {
        [Display(Name ="Search")]
        public string SearchItem { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public IEnumerable<ListMoviesViewModel> Movies { get; set; }
    }
}
