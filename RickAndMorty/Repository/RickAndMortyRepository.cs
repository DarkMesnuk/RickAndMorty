using Newtonsoft.Json;
using RickAndMorty.Configs;
using RickAndMorty.Helpers;
using RickAndMorty.Models.DTO;
using RickAndMorty.Models.Enums;
using RickAndMorty.Models.Server;
using RickAndMorty.Repository.Interface;

namespace RickAndMorty.Repository
{
    public class RickAndMortyRepository : BaseRepository, IRickAndMortyRepository
    {
        public RickAndMortyRepository(IHttpClientFactory httpClient) : base(httpClient)
        {
        }

        public async Task<T> GetByNameAsync<T>(string name, string dtoType) where T : BaseDTO
        {
            var url = "/api/" + dtoType + "/".BuildFilterUrl(name);

            var dto = await getAllAsync<T>(url);

            return dto.Where(x => x.Name == name).FirstOrDefault();
        }

        public async Task<T> GetByUrl<T>(string url)
        {
            var response = await SendAsync(new ApiRequest
            {
                ApiType = ApiType.GET,
                Url = url.Remove(0, APIUrlConfig.RickAndMortyAPI.Length),
            });

            if (response == null || !response.IsSuccess)
                return JsonConvert.DeserializeObject<T>("");

            return JsonConvert.DeserializeObject<T>(response.Result.ToString());
        }

        private async Task<IEnumerable<T>> getAllAsync<T>(string url)
        {
            var results = new List<T>();
            var nextPage = -1;

            do
            {
                var response = await SendAsync(new ApiRequest
                {
                    ApiType = ApiType.GET,
                    Url = nextPage == -1 ? url : $"{url}{(url.Contains("?") ? "&" : "?")}page={nextPage}",
                });

                if (response == null || !response.IsSuccess)
                    return results;

                var result = JsonConvert.DeserializeObject<PageDTO<T>>(response.Result.ToString());

                if (result.Info == null || result.Results == null)
                    continue;

                results.AddRange(result.Results);

                nextPage = result.Info.Next.GetNextPageNumber();
            }
            while (nextPage != -1);

            return results;
        }
    }
}
