using System.Collections.Generic;

namespace GeorgesMovies.Web.Models.Actors
{
    public class AllActorsViewModel
    {
        public IEnumerable<ActorsNamesViewModel> Actors { get; set; }
    }
}
