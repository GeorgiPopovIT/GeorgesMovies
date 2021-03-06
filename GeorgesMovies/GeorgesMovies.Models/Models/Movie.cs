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
            this.Actors = new HashSet<Actor>();
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(MovieTitleMaxLength)]
        public string Title { get; set; }
       
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
        public DateTime ReleaseDate { get; set; }
        [Required]
        public decimal Rating { get; set; }

        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [Required]
        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public ICollection<Actor> Actors { get; set; }
        
        public ICollection<Comment> Comments { get; set; }
    }
}
