namespace RickAndMorty.Models.Schema
{
    public class CheckPersonSchema
    {
        public string PersonName { get; set; } = string.Empty;
        public string EpisodeName { get; set; } = string.Empty;

        public override string ToString()
        {
            return PersonName + "&" + EpisodeName;
        }
    }
}