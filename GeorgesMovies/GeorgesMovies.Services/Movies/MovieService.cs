using AutoMapper;
using AutoMapper.QueryableExtensions;
using GeorgesMovies.Data;
using GeorgesMovies.Models.Models;
using GeorgesMovies.Services.Actors;
using GeorgesMovies.Services.Comments;
using GeorgesMovies.Services.Directors;
using GeorgesMovies.Services.Genres;
using GeorgesMovies.Services.Mapping;
using GeorgesMovies.Services.Movies.DTO;
using System.Collections.Generic;
using System.Linq;

namespace GeorgesMovies.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly ICommentService comment;
        private readonly IGenreService genres;
        private readonly IDirectorService directors;
        private readonly IActorService actors;
        private readonly GeorgesMoviesDbContext context;
        private readonly IMapper mapper;

        public MovieService(GeorgesMoviesDbContext context,
            IMapper mapper, IActorService actors
            , IDirectorService directors,
            IGenreService genres, ICommentService comment)
        {
            this.actors = actors;
            this.context = context;
            this.directors = directors;
            this.mapper = mapper;
            this.mapper = MapperCreator.InitializeMapper(mapper);
            this.genres = genres;
            this.comment = comment;
        }

        public void Add(MovieServiceFormModel movie)
        {
            var director = this.directors
                .CreateDirector(movie.Director.Split()[0], movie.Director.Split()[1]);

            //var movieData = this.mapper.Map<Movie>(movie);
            var movieData = new Movie
            {
                Title = movie.Title,
                Time = movie.Time,
                ReleaseDate = movie.ReleaseDate,
                Overview = movie.Overview,
                Review = movie.Review,
                GenreId = movie.GenreId,
                DirectorId = director.Id,
                MovieUrl = movie.MovieUrl,
                PictureUrl = movie.PictureUrl,
                Rating = movie.Rating
            };
            //movieData.DirectorId = director.Id;
            //this.context.Directors.Add(director);
            //movieData.Directors.Add(director);

            this.context.Movies.Add(movieData);
            this.context.SaveChanges();

        }

        public ManageServiceViewModel Manage()
        {
            return new ManageServiceViewModel
            {
                ManageList = ManageListing()
            };
        }

        public MoviesQueryServiceModel All(
            string searchItem,
            int currentPage,
            int moviesPerPage,
            int genreId)
        {
            var moviesQuery = GetMoviesListing();

            if (!string.IsNullOrWhiteSpace(searchItem))
            {
                moviesQuery = moviesQuery
                    .Where(m => m.Title.ToLower() == searchItem.ToLower()
                    || m.Title.ToLower().Contains(searchItem.ToLower()));
            }
            if (genreId != 0)
            {
                moviesQuery = moviesQuery
                    .Where(g => g.GenreId == genreId);
            }

            var totalMovies = moviesQuery.Count();

            var genres = this.genres.GetGenres();

            var movies = moviesQuery
                .Skip((currentPage - 1) * moviesPerPage)
                .Take(moviesPerPage)
                .ToList();


            return new MoviesQueryServiceModel
            {
                Genres = genres,
                CurrentPage = currentPage,
                TotalMovies = totalMovies,
                MoviesPerPage = moviesPerPage,
                Movies = movies,
            };
        }

        public DetailsServiceViewModel Details(int id)
        {
            var currMovie = this.context.Movies.FirstOrDefault(m => m.Id == id);

            var actors = this.actors.GetActorsInCurrentMovie(currMovie);


            var director = this.directors.GetMovieDirector(currMovie);

            var result = this.mapper.Map<DetailsServiceViewModel>(currMovie);

            result.Id = id;
            result.ActorNames = actors;
            result.DirectorName = director.FullName;
            result.AllComments = this.comment.All(id);
            return result;
        }
        public bool Edit(int id, MovieServiceFormModel model)
        {
            var movie = this.context.Movies.Find(id);

            if (movie == null)
            {
                return false;
            }
            var directorMovie = this.context.Directors
                .FirstOrDefault(d => d.FirstName + " " + d.LastName
                == model.Director);

            if (directorMovie == null)
            {
                directorMovie = new Director()
                {
                    FirstName = model.Director.Split()[0],
                    LastName = model.Director.Split()[1]
                };
                //movie.Directors.Add(directorMovie);
                this.context.Directors.Add(directorMovie);
            }

            //movie = this.mapper.Map<Movie>(model);
            movie.Title = model.Title;
            movie.Time = model.Time;
            movie.ReleaseDate = model.ReleaseDate;
            movie.Review = model.Review;
            movie.PictureUrl = model.PictureUrl;
            movie.MovieUrl = model.MovieUrl;
            movie.GenreId = model.GenreId;
            movie.Rating = model.Rating;
            movie.Overview = model.Overview;
            movie.DirectorId = directorMovie.Id;

            this.context.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            var movieToDelete = this.context.Movies
                .FirstOrDefault(m => m.Id == id);

            this.context.Remove(movieToDelete);

            this.context.SaveChanges();
        }

        public IQueryable<AllMovieServiceModel> GetMoviesListing()
        {
            var movies = this.context.Movies
               .ProjectTo<AllMovieServiceModel>(this.mapper.ConfigurationProvider)
               .OrderByDescending(m => m.Id)
               .AsQueryable();

            return movies;
        }

        public IEnumerable<ManageServiceViewModel> ManageListing()
        {
            var movies = this.context.Movies
                .ProjectTo<ManageServiceViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return movies;
        }

        public MovieServiceFormModel GetMovieById(int id)
        {
            var director = this.context.Directors
                .FirstOrDefault(d => d.Movies.Any(d => d.Id == id));

            var currMovie = this.context.Movies
                .Where(m => m.Id == id)
                .ProjectTo<MovieServiceFormModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

            currMovie.Director = director.FirstName + " " + director.LastName;

            return currMovie;
        }

        public bool IsMovieExist(MovieServiceFormModel movie)
        {
            return this.context.Movies.Any(m => m.Title == movie.Title);
        }


        //private void InitializeMapper()
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile<MappingProfile>();
        //    });
        //    this.mapper = config.CreateMapper();
        //}
    }
}
