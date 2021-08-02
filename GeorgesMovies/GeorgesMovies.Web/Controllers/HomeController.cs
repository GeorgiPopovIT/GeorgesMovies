using GeorgesMovies.Data;
using GeorgesMovies.Web.Models;
using GeorgesMovies.Web.Models.Home;
using GeorgesMovies.Web.Models.Movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GeorgesMovies.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly GeorgesMoviesDbContext context;
        public HomeController(GeorgesMoviesDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var movies = this.context.Movies
                 .OrderByDescending(m => m.Id)
                 .Select(m => new IndexMovieViewModel
                 {
                     PictuteUrl = m.PictureUrl,
                     Title = m.Title
                 })
                 .Take(3)
                 .ToList();

            return View(new IndexViewModel
            {
                Movies = movies
            });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
