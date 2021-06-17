using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgesMovies.Models.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public int RatingStars { get; set; }


        public Movie Movie { get; set; }
    }
}
