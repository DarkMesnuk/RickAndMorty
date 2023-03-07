using RickAndMorty.Models.Enums;

namespace RickAndMorty.Models.Server
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}