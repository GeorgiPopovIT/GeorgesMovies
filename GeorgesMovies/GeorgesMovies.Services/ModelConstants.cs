using System;

namespace GeorgesMovies.Services
{
    public class ModelConstants
    {
        public const int ActorMinLengthInformation = 20;
        public const int ActorMinLengthName = 3;


        public const int MovieTitleMinLength = 3;
        public const int MovieTimeMinLength = 3;
        public const int MovieOverviewMinLength = 10;
        public const int MovieMinRating = 0;
        public const int MovieMaxRating = 10;
        public const string MovieDateFormat = @"{0:dd\/MM\/yyyy}";
        public const string MovieMinReleaseDate = "1/1/1960";
        public const string MovieMaxReleaseDate = "1/1/2022";
        public const int MovieReviewMinLength = 10;
        public const int DirectorNameMinLength = 8;
    }
}
