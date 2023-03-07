namespace RickAndMorty.Models.DTO
{
    public class PageDTO<T>
    {
        public PageInfoDTO Info { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}
