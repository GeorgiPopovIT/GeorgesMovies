using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GeorgesMovies.Web.Models.ModelConstants;

namespace GeorgesMovies.Web.Models
{
    public class AddMovieFormModel
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }
        [Required]
        [MinLength(3)]
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
        //[MinLength(1)]
        [Range(0,10,
            ErrorMessage ="Rating must between {1} and {2}.")]
        public decimal Rating { get; set; }
        //[Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        [Required]
        [Range(typeof(DateTime),MovieMinReleaseDate, MovieMaxReleaseDate)]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [MinLength(8)]
        public string Director { get; set; }
        [Required]
        [StringLength(int.MaxValue,
            MinimumLength =15,
            ErrorMessage ="The review have to be minimum {2} characters length.")]
        public string Review { get; set; }
        public IEnumerable<GenreFormViewModel> Genres { get; set; }
        
    }
}
