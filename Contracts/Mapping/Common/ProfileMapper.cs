using AutoMapper;

namespace APPWEB_PracticePack.Contracts.Mapping.Çommon
{
    public static class ProfileMapper
    {
        public static readonly IMapper _mapper;

        static ProfileMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });

            _mapper = config.CreateMapper();
        }

        public static TDestination Map<TDestination, TSource>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
    }
}
