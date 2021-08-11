using GeorgesMovies.Services.Directors;
using Moq;

namespace GeorgesMovies.Tests.Mocks
{
    public static class DirectorServiceMock
    {
        public static  IDirectorService Instance
        {
            get
            {
                var mock = new Mock<DirectorService>();

                return mock.Object;
            }
        }
    }
}
