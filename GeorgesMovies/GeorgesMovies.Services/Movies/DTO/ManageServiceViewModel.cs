using System.Collections.Generic;

namespace GeorgesMovies.Services.Movies.DTO
{
    public class ManageServiceViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        public IEnumerable<ManageServiceViewModel> ManageList { get; set; }
    }
}
