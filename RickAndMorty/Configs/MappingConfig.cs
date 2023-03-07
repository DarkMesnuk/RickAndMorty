using AutoMapper;
using RickAndMorty.Models.Schema;
using RickAndMorty.Models.DTO;

namespace RickAndMorty.Configs
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CharacterDTO, CharacterSchema>();
                config.CreateMap<CharacterLocationDTO, LocationSchema>();
                config.CreateMap<LocationDTO, LocationSchema>();
            });

            return mappingConfig;
        }
    }
}