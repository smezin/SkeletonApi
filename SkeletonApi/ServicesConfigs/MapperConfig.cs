using AutoMapper;
using SkeletonApi.Mapping;

namespace SkeletonApi.ServicesConfigs
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var MappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new EntityiesProfile());
            });
            return MappingConfig;
        }
    }
}
