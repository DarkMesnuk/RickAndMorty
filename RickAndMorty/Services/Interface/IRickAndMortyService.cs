using RickAndMorty.Models.Schema;

namespace RickAndMorty.Services.Interface
{
    public interface IRickAndMortyService
    {
        Task<CharacterSchema> GetCharacterByNameAsync(string name);

        Task<bool?> CheckPersonInEpisodeAsync(string personName, string episodeName);
    }
}
