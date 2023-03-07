namespace RickAndMorty.Models.DTO
{
    public class CharacterDTO : BaseDTO
    {
        public string Status { get; set; }

        public string Species { get; set; }

        public string Type { get; set; }

        public string Gender { get; set; }

        public CharacterLocationDTO Location { get; set; }

        public CharacterLocationDTO Origin { get; set; }

        public string Image { get; set; }

        public string[] Episode { get; set; }
    }
}
