
using System;
using System.Collections.Generic;

namespace GeorgesMovies.Models.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Genres = new HashSet<Genre>();
            this.Actors = new HashSet<Actor>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public int Time { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        public DateTime DateRelease { get; set; }

        public string CountryRelease { get; set; }


        public ICollection<Genre> Genres { get; set; }
        public ICollection<Actor> Actors { get; set; }
    }
}
