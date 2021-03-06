using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeorgesMovies.Models.Models
{
    public class Genre
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}