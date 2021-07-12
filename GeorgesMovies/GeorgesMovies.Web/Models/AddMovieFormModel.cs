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
        [Range(1980,
            2021
            ,ErrorMessage ="The movie have to be between years {1} and {2}.")]
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
        [Range(0,10,
            ErrorMessage ="Rating must between {1} and {2}.")]
        public decimal Rating { get; set; }
        //[Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Actors { get; set; }
        [Required]
        [StringLength(int.MaxValue,
            MinimumLength =15,
            ErrorMessage ="The review have to be minimum {2} characters length.")]
        public string Review { get; set; }
        public IEnumerable<GenreFormViewModel> Genres { get; set; }
        
    }
}
