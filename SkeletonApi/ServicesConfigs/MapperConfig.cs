using AutoMapper;

namespace SkeletonApi.ServicesConfigs
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var MappingConfig = new MapperConfiguration(config =>
            {
            });
            return MappingConfig;
        }
    }
}
