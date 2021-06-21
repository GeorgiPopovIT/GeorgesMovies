
using System.Collections.Generic;

namespace GeorgesMovies.Models.Models
{
    public class User
    {
        public User()
        {
            this.Movies = new HashSet<Movie>();
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public ICollection<Movie> Movies { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
