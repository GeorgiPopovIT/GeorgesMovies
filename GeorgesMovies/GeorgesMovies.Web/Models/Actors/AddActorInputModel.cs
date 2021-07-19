using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GeorgesMovies.Web.Models.ModelConstants;

namespace GeorgesMovies.Web.Models.Actors
{
    public class AddActorInputModel
    {
        [Required]
        [MinLength(ActorMinLengthName)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(ActorMinLengthName)]
        public string LastName { get; set; }

        [Required]
        [MinLength(ActorMinLengthInformation)]
        public string Information { get; set; }

        [Display(Name = "Movie Title")]
        public int MovieId { get; set; }
        public IEnumerable<ActorMovieViewModel> Movies { get; set; }
    }
}
