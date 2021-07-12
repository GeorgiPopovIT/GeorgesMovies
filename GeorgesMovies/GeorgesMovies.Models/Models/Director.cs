using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GeorgesMovies.Models.DataConstants;

namespace GeorgesMovies.Models.Models
{
   public class Director
    {
        public Director()
        {
            this.Movies = new HashSet<Movie>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(DirectorFistNameMaxLength)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(DirectorLastNameMaxLength)]
        public string LastName { get; set; }


        public ICollection<Movie> Movies { get; set; }
    }
}
