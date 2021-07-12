using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GeorgesMovies.Models.DataConstants;

namespace GeorgesMovies.Models.Models
{
    public class Actor
    {
        public Actor()
        {
            this.Movies = new HashSet<Movie>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(ActorNameMaxLength)]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
