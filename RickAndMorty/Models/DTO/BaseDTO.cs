namespace RickAndMorty.Models.DTO
{
    public abstract class BaseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Created { get; set; }
    }
}
