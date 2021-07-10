using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeorgesMovies.Models.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Users = new HashSet<User>();
            this.Genres = new HashSet<Genre>();
            this.Actors = new HashSet<Actor>();
            this.Directors = new HashSet<Director>();
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        [Required]

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
        public string DateRelease { get; set; }
        public string MovieUrl { get; set; }
        [Required]
        public string CountryRelease { get; set; }
        [Required]
        public decimal Rating { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Director> Directors { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
