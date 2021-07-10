using GeorgesMovies.Services.Interfaces;
using GeorgesMovies.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeorgesMovies.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService service;
        public MovieController(IMovieService service)
        {
            
        }
        public IActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Add(AddMovieFormModel movie)
        //{
        //    return null;
        //}
    }
}
