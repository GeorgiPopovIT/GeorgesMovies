using GeorgesMovies.Services.Home;
using Moq;

namespace GeorgesMovies.Tests.Mocks
{
    public static class HomeServiceMock
    {
        public static IHomeService Instance
        {
            get
            {
                var context = DatabaseMock.Instance;

                var mock = new Mock<HomeService>(context);

                return mock.Object;
            }
        }
    }
}
