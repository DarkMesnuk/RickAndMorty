namespace RickAndMorty.Models.Schema
{
    public class CharacterSchema
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public string Species { get; set; }

        public string Type { get; set; }

        public string Gender { get; set; }

        public LocationSchema Origin { get; set; }
    }
}
