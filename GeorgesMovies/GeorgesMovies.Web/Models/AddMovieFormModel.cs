using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeorgesMovies.Web.Models
{
    public class AddMovieFormModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        [StringLength(int.MaxValue,
            MinimumLength = 10,
            ErrorMessage ="Overview must be at least {2} length.")]
        public string Overview { get; set; }
        [Required]
        [Display(Name ="Picture Link")]
        [Url]
        public string PictureUrl { get; set; }
        [Required]
        [Display(Name ="Movie Link")]
        [Url]
        public string MovieUrl { get; set; }
        [Required]
        public string ReleaseInfo { get; set; }
        [Required]
        public decimal Rating { get; set; }
        //[Required]
        //public string Genre { get; set; }
        [Display(Name ="Genre")]
        public int GenreId { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Actors { get; set; }
        public IEnumerable<GenreFormViewModel> Genres { get; set; }
        
    }
}
