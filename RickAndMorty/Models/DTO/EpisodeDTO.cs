namespace RickAndMorty.Models.DTO
{
    public class EpisodeDTO : BaseDTO
    {
        public string Air_date { get; set; }

        public string Episode { get; set; }

        public string[] Characters { get; set; }
    }
}
