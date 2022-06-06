using AutoMapper;

namespace SkeletonApi.Configs
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
