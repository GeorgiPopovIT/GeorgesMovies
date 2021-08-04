using AutoMapper;

namespace GeorgesMovies.Services.Mapping
{
    public static class MapperCreator
    {
        public static IMapper InitializeMapper(IMapper mapper)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            mapper = config.CreateMapper();

            return mapper;
        }
    }
}
