namespace GeorgesMovies.Services.Movies.DTO
{
    public class AllMovieServiceModel
    {
        public int Id { get; set; }
        public string PictureUrl { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public int GenreId { get; set; }
    }
}
