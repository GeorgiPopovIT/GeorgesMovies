using GeorgesMovies.Services.Directors;
using Moq;

namespace GeorgesMovies.Tests.Mocks
{
    public static class DirectorServiceMock
    {
        public static IDirectorService Instance
        {
            get
            {
                var context = DatabaseMock.Instance;

                var mock = new Mock<DirectorService>(context);
                return mock.Object;
            }
        }
    }
}
