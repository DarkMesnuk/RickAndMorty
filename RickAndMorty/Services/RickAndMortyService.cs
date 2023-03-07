using AutoMapper;
using RickAndMorty.Models.DTO;
using RickAndMorty.Models.Enums;
using RickAndMorty.Models.Schema;
using RickAndMorty.Repository.Interface;
using RickAndMorty.Services.Interface;

namespace RickAndMorty.Service
{
    public class RickAndMortyService : IRickAndMortyService
    {
        private readonly IMapper _mapper;
        private readonly IRickAndMortyRepository _rickAndMortyRepository;

        public RickAndMortyService(IMapper mapper, IRickAndMortyRepository rickAndMortyRepository)
        {
            _mapper = mapper;
            _rickAndMortyRepository = rickAndMortyRepository;
        }

        public async Task<CharacterSchema> GetCharacterByNameAsync(string name)
        {
            if (String.IsNullOrEmpty(name))
                return null;

            var characterDTO = await _rickAndMortyRepository.GetByNameAsync<CharacterDTO>(name, DTOEnum.Character);

            if (characterDTO == null)
                return null;

            var locationDTO = await _rickAndMortyRepository.GetByUrl<LocationDTO>(characterDTO.Origin.Url);
            
            var character = _mapper.Map<CharacterSchema>(characterDTO);
            character.Origin = _mapper.Map<LocationSchema>(locationDTO);

            return character;
        }

        public async Task<bool?> CheckPersonInEpisodeAsync(string personName, string episodeName)
        {
            if (String.IsNullOrEmpty(personName) || String.IsNullOrEmpty(episodeName))
                return null;

            var episodeDTO = await _rickAndMortyRepository.GetByNameAsync<EpisodeDTO>(episodeName, DTOEnum.Episode);

            if (episodeDTO == null)
                return null;

            var characterDTO = await _rickAndMortyRepository.GetByNameAsync<CharacterDTO>(personName, DTOEnum.Character);

            if(characterDTO == null) 
                return null;

            return episodeDTO.Characters.Contains(characterDTO.Url);
        }
    }
}
