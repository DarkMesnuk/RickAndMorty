using RickAndMorty.Models.Server;
using RickAndMorty.Models.Enums;
using Newtonsoft.Json;
using System.Text;
using RickAndMorty.Configs;

namespace RickAndMorty.Repository
{
    public abstract class BaseRepository : IDisposable
    {
        private readonly IHttpClientFactory _httpClient;

        protected BaseRepository(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<Response> SendAsync(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("RestaurantAPI");
                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(APIUrlConfig.RickAndMortyAPI + apiRequest.Url);
                client.DefaultRequestHeaders.Clear();

                if (apiRequest.Data != null)
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");

                switch (apiRequest.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                var apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                return new Response
                {
                    IsSuccess = true,
                    Result = apiContent
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { ex.Message.ToString() },
                    IsSuccess = false
                };
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
