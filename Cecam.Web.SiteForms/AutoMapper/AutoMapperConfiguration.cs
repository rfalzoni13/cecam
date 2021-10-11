using AutoMapper;

namespace Cecam.Web.SiteForms.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        private static IMapper Mapper;

        public static IMapper RegisterMappings()
        {
            var mapperConfiguration = new MapperConfiguration(
                config =>
                {
                    config.AddProfile<DomainToDTOProfileConfiguration>();
                    config.AddProfile<DTOToDomainProfileConfiguration>();
                });

            Mapper = mapperConfiguration.CreateMapper();

            return Mapper;
        }
    }
}