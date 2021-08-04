using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static GeorgesMovies.Services.ModelConstants;

namespace GeorgesMovies.Services.Actors.DTO
{
    public class AddActorServiceModel
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
        public IEnumerable<ActorMovieServiceModel> Movies { get; set; }
    }
}