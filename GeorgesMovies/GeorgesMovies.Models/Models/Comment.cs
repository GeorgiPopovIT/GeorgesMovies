using System;
using System.ComponentModel.DataAnnotations;

namespace GeorgesMovies.Models.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
