using RickAndMorty.Models.DTO;

namespace RickAndMorty.Repository.Interface
{
    public interface IRickAndMortyRepository
    {
        Task<T> GetByNameAsync<T>(string name, string dtoType) where T : BaseDTO;

        Task<T> GetByUrl<T>(string url);
    }
}
