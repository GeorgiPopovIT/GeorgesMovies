using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GeorgesMovies.Models.DataConstants;

namespace GeorgesMovies.Models.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Users = new HashSet<User>();
            this.Actors = new HashSet<Actor>();
            this.Directors = new HashSet<Director>();
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(MovieTitleMaxLength)]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
       
        [Required]
        public string Time { get; set; }
        [Required]
        public string Overview { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string Review { get; set; }
        [Required]
        public string MovieUrl { get; set; }
        [Required]
        public string ReleaseInfo { get; set; }
        [Required]
        public decimal Rating { get; set; }
        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Director> Directors { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
