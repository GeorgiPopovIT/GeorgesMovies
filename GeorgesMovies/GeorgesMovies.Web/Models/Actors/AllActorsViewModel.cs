using System.Collections.Generic;
using GeorgesMovies.Services.Actors.DTO;

namespace GeorgesMovies.Web.Models.Actors
{
    public class AllActorsViewModel
    {
        public List<ActorFullNameServiceModel> Actors { get; set; }
    }
}
