using System.Collections.Generic;

namespace GeorgesMovies.Services.Models
{
    public class MovieDto
    {
        public MovieDto()
        {
            this.Genres = new List<string>();
        }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Time { get; set; }
        public string Overview { get; set; }
        public string PictureUrl { get; set; }
        public string DateRealease { get; set; }
        public string CountryRealease { get; set; }
        public decimal Rating { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Actors { get; set; }
    }
}
