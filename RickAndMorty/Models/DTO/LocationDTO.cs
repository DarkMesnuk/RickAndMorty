namespace RickAndMorty.Models.DTO
{
    public class LocationDTO : BaseDTO
    {
        public string Type { get; set; }

        public string Dimension { get; set; }

        public string[] Residents { get; set; }
    }
}
