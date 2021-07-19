using System.Collections.Generic;

namespace GeorgesMovies.Web.Models
{
    public class ManageListingViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        public IEnumerable<ManageListingViewModel> ManageList { get; set; }
    }
}
