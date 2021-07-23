using System.Collections.Generic;
using GeorgesMovies.Services.Actors;

namespace GeorgesMovies.Web.Models.Actors
{
    public class AllActorsViewModel
    {
        public List<ActorFullNameServiceModel> Actors { get; set; }
    }
}
