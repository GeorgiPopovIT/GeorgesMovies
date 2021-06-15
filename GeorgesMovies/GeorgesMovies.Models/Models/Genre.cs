using System.Collections.Generic;

namespace GeorgesMovies.Models.Models
{
    public class Genre
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}