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
        public string Overview { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string MovieUrl { get; set; }
        [Required]
        public string CountryRealease { get; set; }
        [Required]
        public decimal Rating { get; set; }
        [Required]
        public string Genre { get; set; }

    }
}
