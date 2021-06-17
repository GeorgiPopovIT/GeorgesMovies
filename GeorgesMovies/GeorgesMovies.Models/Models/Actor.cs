﻿using System.Collections.Generic;


namespace GeorgesMovies.Models.Models
{
    public class Actor
    {
        public Actor()
        {
            this.Movies = new HashSet<Movie>();
        }
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }


        public ICollection<Movie> Movies { get; set; }
    }
}
