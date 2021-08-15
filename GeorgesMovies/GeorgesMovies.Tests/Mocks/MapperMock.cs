using AutoMapper;
using Moq;

namespace GeorgesMovies.Tests.Mocks
{
    public static class MapperMock
    {
        public static IMapper Instance
        {
            get
            {
                var mock = new Mock<IMapper>();

                return mock.Object;
            }
        }
    }
}
