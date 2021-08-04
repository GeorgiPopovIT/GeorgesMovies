using GeorgesMovies.Services.Genres.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static GeorgesMovies.Services.ModelConstants;

namespace GeorgesMovies.Services.Movies.DTO
{
    public class MovieServiceFormModel
    {

        [Required]
        [MinLength(MovieTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(MovieTimeMinLength)]
        public string Time { get; set; }

        [Required]
        [StringLength(int.MaxValue,
            MinimumLength = MovieOverviewMinLength,
            ErrorMessage = "Overview must be at least {2} length.")]
        public string Overview { get; set; }

        [Required]
        [Display(Name = "Picture Link")]
        [Url]
        public string PictureUrl { get; set; }

        [Required]
        [Display(Name = "Movie Link")]
        [Url]
        public string MovieUrl { get; set; }

        [Required]
        [Range(MovieMinRating, MovieMaxRating,
            ErrorMessage = "Rating must between {1} and {2}.")]
        public decimal Rating { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Required]
        [Range(typeof(DateTime), MovieMinReleaseDate, MovieMaxReleaseDate)]
        [DisplayFormat(DataFormatString = MovieDateFormat)]
        public DateTime ReleaseDate { get; set; } = DateTime.UtcNow.ToLocalTime();

        [Required]
        [MinLength(DirectorNameMinLength)]
        public string Director { get; set; }

        [Required]
        [StringLength(int.MaxValue,
            MinimumLength = MovieReviewMinLength,
            ErrorMessage = "The review have to be minimum {2} characters length.")]
        public string Review { get; set; }

        public IEnumerable<GenreServiceFormModel> Genres { get; set; }
    }
}
